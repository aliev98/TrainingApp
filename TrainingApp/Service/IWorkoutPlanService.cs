using TrainingApp.Models;

namespace TrainingApp.Service
{
    public interface IWorkoutPlanService
    {
        WorkoutPlan GetWorkoutPlanById(int id);
        List<WorkoutPlan> GetWorkoutPlansForUser(string userId);
        void CreateWorkoutPlan(WorkoutPlan workoutPlan);
        void AddExercise(CreateWorkoutPlanVM viewModel, string exercise);
        List<string> GetSelectedExercises(CreateWorkoutPlanVM viewModel);

    }
}