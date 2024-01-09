using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Models
{
    public class CreateWorkoutPlanVM
    {

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Duration in days is required")]
        public int DurationInDays { get; set; } = 1;

        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Today;
        
        // Property for user input to add exercises
        public string? ExerciseInput { get; set; }

        // Selected exercise names for the workout plan
       // [Required(ErrorMessage = "At least one exercise must be selected")]
        public List<string> SelectedExercises { get; set; }

        //public List<int> ?Sets { get; set; }

        // New property to represent reps for each exercise
        //public List<int>? Reps { get; set; }

    }
}
