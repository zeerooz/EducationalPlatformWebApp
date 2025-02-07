using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; // Add ILogger namespace
using EducationalPlatformWebApp.Models;

namespace MyWeb.Controllers
{
    public class AssessmentsController : Controller
    {
        private readonly MyProjectDbContext _context;
        private readonly ILogger<AssessmentsController> _logger; // Add logger

        public AssessmentsController(MyProjectDbContext context, ILogger<AssessmentsController> logger)
        {
            _context = context;
            _logger = logger; // Initialize logger
        }

        // GET: Assessments
        public async Task<IActionResult> Index()
        {
            var omarContext = _context.Assessments.Include(a => a.Module);
            return View(await omarContext.ToListAsync());
        }

        // GET: Assessments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Details: No ID provided.");
                return NotFound();
            }

            var assessment = await _context.Assessments
                .Include(a => a.Module)
                .FirstOrDefaultAsync(m => m.AssessmentsId == id);
            if (assessment == null)
            {
                _logger.LogWarning("Details: Assessment with ID {id} not found.", id);
                return NotFound();
            }

            return View(assessment);
        }

        // GET: Assessments/Create
        public IActionResult Create()
        {
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId");
            return View();
        }

        // POST: Assessments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssessmentsId,CourseId,ModuleId,AssessmentsType,TotalMarks,PassingMarks,AssessmentsCriteria,Weightage,AssessmentsDescriptioin,AssessmentsTitle")] Assessment assessment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assessment);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Assessment created successfully.");
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", assessment.ModuleId);
            return View(assessment);
        }

        // GET: Assessments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Edit: No ID provided.");
                return NotFound();
            }

            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment == null)
            {
                _logger.LogWarning("Edit: Assessment with ID {id} not found.", id);
                return NotFound();
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", assessment.ModuleId);
            return View(assessment);
        }

        // POST: Assessments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssessmentsId,CourseId,ModuleId,AssessmentsType,TotalMarks,PassingMarks,AssessmentsCriteria,Weightage,AssessmentsDescriptioin,AssessmentsTitle")] Assessment assessment)
        {
            if (id != assessment.AssessmentsId)
            {
                _logger.LogError("Edit: Assessment ID mismatch.");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assessment);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Assessment with ID {id} updated successfully.", id);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssessmentExists(assessment.AssessmentsId))
                    {
                        _logger.LogError("Edit: Assessment with ID {id} not found during concurrency check.", id);
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "ModuleId", "ModuleId", assessment.ModuleId);
            return View(assessment);
        }

        // GET: Assessments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Delete: No ID provided.");
                return NotFound();
            }

            var assessment = await _context.Assessments
                .Include(a => a.Module)
                .FirstOrDefaultAsync(m => m.AssessmentsId == id);
            if (assessment == null)
            {
                _logger.LogWarning("Delete: Assessment with ID {id} not found.", id);
                return NotFound();
            }

            return View(assessment);
        }

        // POST: Assessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment != null)
            {
                _context.Assessments.Remove(assessment);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Assessment with ID {id} deleted successfully.", id);
            }
            else
            {
                _logger.LogWarning("DeleteConfirmed: Assessment with ID {id} not found.", id);
            }

            return RedirectToAction(nameof(Index));
        }

        // Assessments with Highest Credit Points
        public IActionResult AssessmentsWithHighestCreditPoints()
        {
            var highestAssessments = new List<AssessmentWithCreditPointsModel>();

            try
            {
                int maxCreditPoints = 0;

                using (SqlConnection connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    // Step 1: Call the Highestgrade procedure to get the max credit points
                    using (var cmd = new SqlCommand("Highestgrade", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        maxCreditPoints = Convert.ToInt32(cmd.ExecuteScalar());
                        _logger.LogInformation($"Max credit points retrieved: {maxCreditPoints}");
                    }

                    // Step 2: Fetch courses and assessments with the max credit points
                    using (var cmd = new SqlCommand(@"
                SELECT C.CourseID, C.Course_Title, A.AssessmentsID, A.AssessmentsTitle, A.TotalMarks, C.credit_points 
                FROM Courses C 
                INNER JOIN Assessments A ON C.CourseID = A.CourseId 
                WHERE C.credit_points = @MaxCreditPoints", connection))
                    {
                        cmd.Parameters.AddWithValue("@MaxCreditPoints", maxCreditPoints);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                highestAssessments.Add(new AssessmentWithCreditPointsModel
                                {
                                    CourseID = (int)reader["CourseID"],
                                    CourseTitle = reader["Course_Title"].ToString(),
                                    AssessmentID = (int)reader["AssessmentsID"],
                                    AssessmentTitle = reader["AssessmentsTitle"].ToString(),
                                    TotalMarks = (int)reader["TotalMarks"],
                                    CreditPoints = (int)reader["credit_points"]
                                });
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving assessments with highest credit points.");
                TempData["ErrorMessage"] = $"Failed to retrieve assessments. Error: {ex.Message}";
            }

            return View("AssessmentsWithHighestCreditPoints", highestAssessments);
        }



        private bool AssessmentExists(int id)
        {
            return _context.Assessments.Any(e => e.AssessmentsId == id);
        }
    }
}

