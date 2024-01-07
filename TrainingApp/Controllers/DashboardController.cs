using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Security.Claims;
using TrainingApp.Data;
using TrainingApp.Models;
using TrainingApp.Service;

namespace TrainingApp.Controllers
{
    [ReturnToHome]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWorkoutPlanService _workoutPlanService; // Assuming you have a service to handle workout plans
        private readonly AppDbContext _dbContext;
        public DashboardController(UserManager<AppUser> userManager, IWorkoutPlanService workoutPlanService, AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _workoutPlanService = workoutPlanService;
        }

        public async Task<IActionResult> Index()
        {
                var user = await _userManager.GetUserAsync(User);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var workoutPlans = _workoutPlanService.GetWorkoutPlansForUser(user.Id);
                var achievements = _dbContext.Achievements.Where(c => c.AppUserId == userId).ToList();

                var viewModel = new DashboardVM
                {
                    UserName = user.UserName,
                    WorkoutPlans = workoutPlans,
                    Achievements = achievements,
                };

                return View(viewModel);
        }

        public IActionResult Details(int id)
        {

            var workoutPlan = _dbContext.WorkoutPlans.Include(wp => wp.Exercises).FirstOrDefault(wp => wp.WorkoutPlanId == id);

            var exercises = _dbContext.ExercisesInPlans.Where(e => e.WorkoutPlanId == workoutPlan.WorkoutPlanId).ToList();

            workoutPlan.Exercises = exercises;

            if (workoutPlan == null)
            {
                return NotFound();
            }

            var viewModel = new WorkoutPlanDetailsVM
            {
                WorkoutPlan = workoutPlan
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateAchievement(string achievementName)
        {
            if (!string.IsNullOrEmpty(achievementName))
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var achievement = new Achievement
                {
                    Name = achievementName,
                    CompletionDate = DateTime.Now,
                    AppUserId = userId
                };

                _dbContext.Achievements.Add(achievement);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index"); // Redirect to the dashboard or any other desired page
        }
    }
}
