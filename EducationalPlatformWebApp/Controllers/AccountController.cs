using Microsoft.AspNetCore.Mvc;
using EducationalPlatformWebApp.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatformWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyProjectDbContext _dbContext;

        public AccountController(MyProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(
            string email,
            string password,
            string confirmPassword,
            string role,
            string adminName,
            string firstName,
            string lastName,
            string gender,
            DateTime? birthDate,
            string country,
            string culturalBackground,
            string instructorName,
            string qualification,
            string expertise)
        {
            // Clear all model state errors to ensure only relevant errors are shown
            ModelState.Clear();

            // Validate password confirmation
            if (password != confirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");
            }

            // Role-specific validations
            if (role == "Admin")
            {
                // Check if email already exists
                if (_dbContext.Admins.Any(a => a.Email == email))
                {
                    ModelState.AddModelError("Email", "This email is already registered.");
                }

                if (string.IsNullOrEmpty(adminName))
                {
                    ModelState.AddModelError("AdminName", "The admin name field is required for Admin.");
                }
            }
            else if (role == "Learner")
            {
                // Check if email already exists
                if (_dbContext.Learners.Any(a => a.Email == email))
                {
                    ModelState.AddModelError("Email", "This email is already registered.");
                }
                if (string.IsNullOrEmpty(firstName))
                {
                    ModelState.AddModelError("FirstName", "The first name field is required for Learner.");
                }
                if (string.IsNullOrEmpty(lastName))
                {
                    ModelState.AddModelError("LastName", "The last name field is required for Learner.");
                }
                if (string.IsNullOrEmpty(gender))
                {
                    ModelState.AddModelError("Gender", "The gender field is required for Learner.");
                }
                if (!birthDate.HasValue)
                {
                    ModelState.AddModelError("BirthDate", "The birth date field is required for Learner.");
                }
                if (string.IsNullOrEmpty(country))
                {
                    ModelState.AddModelError("Country", "The country field is required for Learner.");
                }
                if (string.IsNullOrEmpty(culturalBackground))
                {
                    ModelState.AddModelError("CulturalBackground", "The cultural background field is required for Learner.");
                }
            }
            else if (role == "Instructor")
            {
                // Check if email already exists
                if (_dbContext.Instructors.Any(a => a.Email == email))
                {
                    ModelState.AddModelError("Email", "This email is already registered.");
                }

                if (string.IsNullOrEmpty(instructorName))
                {
                    ModelState.AddModelError("InstructorName", "The instructor name field is required for Instructor.");
                }
                if (string.IsNullOrEmpty(qualification))
                {
                    ModelState.AddModelError("Qualification", "The qualification field is required for Instructor.");
                }
                if (string.IsNullOrEmpty(expertise))
                {
                    ModelState.AddModelError("Expertise", "The expertise field is required for Instructor.");
                }
            }
            else
            {
                ModelState.AddModelError("Role", "Invalid role selected.");
            }

            // If validation fails, return the view
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Hash the password for security
            string hashedPassword = HashPassword(password);

            // Add user based on the role
            if (role == "Admin")
            {
                var admin = new Admin
                {
                    Email = email,
                    UserPassword = hashedPassword,
                    FirstName = adminName
                };
                _dbContext.Admins.Add(admin);
            }
            else if (role == "Learner")
            {
                var learner = new Learner
                {
                    Email = email,
                    UserPassword = hashedPassword,
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = gender,
                    BirthDate = birthDate.Value,
                    Country = country,
                    CulturalBackground = culturalBackground
                };
                _dbContext.Learners.Add(learner);
            }
            else if (role == "Instructor")
            {
                var instructor = new Instructor
                {
                    Email = email,
                    UserPassword = hashedPassword,
                    InstructorName = instructorName,
                    LatestQualification = qualification,
                    ExpertiseArea = expertise
                };
                _dbContext.Instructors.Add(instructor);
            }

            _dbContext.SaveChanges();

            ViewBag.ShowSuccessMessage = true; // Pass flag to show success modal
            return View();
        }






        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password, string role)
        {
            string hashedPassword = HashPassword(password);

            bool isAuthenticated = false;

            if (role == "Admin")
            {
                isAuthenticated = _dbContext.Admins.Any(a => a.Email == email && a.UserPassword == hashedPassword);
            }
            else if (role == "Learner")
            {
                isAuthenticated = _dbContext.Learners.Any(l => l.Email == email && l.UserPassword == hashedPassword);
            }
            else if (role == "Instructor")
            {
                isAuthenticated = _dbContext.Instructors.Any(i => i.Email == email && i.UserPassword == hashedPassword);
            }

            if (!isAuthenticated)
            {
                TempData["ErrorMessage"] = "Invalid email or password. Please check your credentials and try again.";
                return View();
            }

            TempData["SuccessMessage"] = "Login successful!";
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("Index", "Learners");

        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
