using TrainingApp.Data;
using TrainingApp.Models;

namespace TrainingApp.Service
{
    public class WorkoutPlanService : IWorkoutPlanService
    {
        private readonly AppDbContext _dbContext;

        public WorkoutPlanService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public WorkoutPlan GetWorkoutPlanById(int id)
        {
            return _dbContext.WorkoutPlans.FirstOrDefault(wp => wp.WorkoutPlanId == id);
        }

        public List<WorkoutPlan> GetWorkoutPlansForUser(string userId)
        {
            return _dbContext.WorkoutPlans.Where(wp => wp.AppUserId == userId).ToList();
        }

        public void CreateWorkoutPlan(WorkoutPlan workoutPlan)
        {
            _dbContext.WorkoutPlans.Add(workoutPlan);
            _dbContext.SaveChanges();
        }

        public void AddExercise(CreateWorkoutPlanVM viewModel, string exercise)
        {
            if (exercise != null)
            {
                // Assuming SelectedExercises is a list in the ViewModel
                // Add the exercise to the list
                viewModel.SelectedExercises.Add(exercise);
            }
        }
        public List<string> GetSelectedExercises(CreateWorkoutPlanVM viewModel)
        {
            // Assuming SelectedExercises is a list property in CreateWorkoutPlanViewModel
            return viewModel.SelectedExercises;
        }
    }
}