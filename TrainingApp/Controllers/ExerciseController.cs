using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Data;
using TrainingApp.Models;

namespace TrainingApp.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        public ExerciseController(AppDbContext dbContext, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var exercises = _dbContext.Exercises.ToList();
            return View(exercises);
        }

        [HttpPost]
        public async Task<IActionResult> ChooseExercises(List<int> selectedExerciseIds)
        {
            // Retrieve the current user
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                
                // Assuming you have a navigation property in AppUser for selected exercises
                user.SelectedExercises = _dbContext.Exercises.Where(e => selectedExerciseIds.Contains(e.ExerciseId)).ToList();
                await _userManager.UpdateAsync(user);
            }

            return RedirectToAction("Index", "Home"); // Redirect to a relevant page
        }
    }
}
