using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.Entity;
using System.Security.Claims;
using TrainingApp.Data;
using TrainingApp.Models;
using TrainingApp.Service;

namespace TrainingApp.Controllers
{
    public class WorkoutPlanController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWorkoutPlanService _workoutPlanService;

        public WorkoutPlanController(AppDbContext dbContext, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;

        }

        [HttpGet]
        public IActionResult Create()
        {
            var VM = new CreateWorkoutPlanVM();
            VM.SelectedExercises = new List<string>();
            return View(VM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkoutPlanVM viewModel)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                var workoutPlan = new WorkoutPlan
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    DurationInDays = viewModel.DurationInDays,
                    StartDate = viewModel.StartDate,
                    AppUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
                };

                var data = string.Concat(viewModel.SelectedExercises);

                var secondData = JsonConvert.DeserializeObject<List<ExerciseInPlan>>(data);

                foreach (var item in secondData)
                {
                    workoutPlan.Exercises.Add(new ExerciseInPlan { Name = item.Name, Sets = item.Sets, Reps = item.Reps });
                }

               await _dbContext.WorkoutPlans.AddAsync(workoutPlan);
               await _dbContext.SaveChangesAsync();

                return RedirectToAction("Details", "Dashboard",new { id = workoutPlan.WorkoutPlanId});
            }

            // If the model state is not valid, redisplay the form with errors
            return View(viewModel);
        }

        //public void CreateWorkoutPlan(WorkoutPlan workoutPlan, List<string> selectedExercises, List<int> sets, List<int> reps)
        //{
        //    List<ExerciseInPlan> exercises = CreateExercises(selectedExercises, sets, reps);

        //    // Associate the exercises with the workout plan
        //    workoutPlan.Exercises = exercises;

        //    _dbContext.WorkoutPlans.Add(workoutPlan);
        //    _dbContext.SaveChanges();
        //}
        //private List<ExerciseInPlan> CreateExercises(List<string> selectedExercises, List<int> sets, List<int> reps)
        //{
        //    List<ExerciseInPlan> exercises = new List<ExerciseInPlan>();

        //    for (int i = 0; i < selectedExercises.Count; i++)
        //    {
        //        ExerciseInPlan exercise = new ExerciseInPlan
        //        {
        //            Name = selectedExercises[i],
        //            Sets = sets[i],
        //            Reps = reps[i]
        //        };

        //        exercises.Add(exercise);
        //    }

        //    return exercises;
        //}

        [HttpPost]
        public IActionResult AddExercise([FromBody]string exercise, [FromServices] CreateWorkoutPlanVM vm)
        {
            // Use the service to add the exercise to the SelectedExercises list

            // Return a response if needed
            // vm.SelectedExercises.Add(exercise);
            vm.SelectedExercises = new List<string>();
            _workoutPlanService.AddExercise(vm, exercise);
            return Ok();
        }

        public IActionResult GetSelectedExercises([FromServices] CreateWorkoutPlanVM viewModel)
        {
            // Get the list of selected exercises from the viewModel
            var selectedExercises = _workoutPlanService.GetSelectedExercises(viewModel);

            // Return the list as JSON
            return Json(selectedExercises);
        }

        [HttpGet]
        public IActionResult ViewPlan(int id)
        {
            // Display details of a specific workout plan
            var workoutPlan = _dbContext.WorkoutPlans
                .Include(wp => wp.Exercises)
                .FirstOrDefault(wp => wp.WorkoutPlanId == id);

            if (workoutPlan == null)
            {
                return NotFound();
            }

            return View(workoutPlan);
        }
    }
}
