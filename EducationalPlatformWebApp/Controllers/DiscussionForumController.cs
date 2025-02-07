using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducationalPlatformWebApp.Models;

namespace GPEP1.Controllers
{
    public class DiscussionForumController : Controller
    {
        private readonly MyProjectDbContext _context;

        public DiscussionForumController(MyProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var forums = await _context.DiscussionForums.Include(f => f.LearnerDiscussions).ToListAsync();
            return View(forums);
        }

        public IActionResult CreateForum()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateForum(string froumTitles, string forumDescription)
        {
            if (string.IsNullOrEmpty(froumTitles) || string.IsNullOrEmpty(forumDescription))
            {
                ModelState.AddModelError("", "Title and description are required.");
                return View();
            }

            var forum = new DiscussionForum
            {
                FroumTitles = froumTitles,
                ForumDescription = forumDescription,
                ForumTimestamp = DateTime.UtcNow
            };

            _context.Add(forum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddPost(int forumId)
        {
            ViewData["ForumId"] = forumId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(int forumId, string postContent, int learnerId)
        {
            if (string.IsNullOrEmpty(postContent))
            {
                ModelState.AddModelError("", "Content is required.");
                ViewData["ForumId"] = forumId;
                return View();
            }

            var learner = await _context.Learners.FindAsync(learnerId);
            if (learner == null)
            {
                ModelState.AddModelError("", "Invalid Learner ID.");
                ViewData["ForumId"] = forumId;
                return View();
            }

            var post = new LearnerDiscussion
            {
                ForumId = forumId,
                Post = postContent,
                DiscussionTime = TimeOnly.FromDateTime(DateTime.UtcNow),
                LearnerId = learnerId
            };

            _context.Add(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = forumId });
        }

        public async Task<IActionResult> Details(int id)
        {
            var forum = await _context.DiscussionForums
                .Include(f => f.LearnerDiscussions)
                .ThenInclude(ld => ld.Learner) // Include Learner details
                .FirstOrDefaultAsync(f => f.ForumId == id);

            if (forum == null)
            {
                return NotFound();
            }

            return View(forum);
        }
    }
}