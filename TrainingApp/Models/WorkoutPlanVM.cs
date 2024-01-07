using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Models
{
    public class WorkoutPlanVM
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int DurationInDays { get; set; } = 1;
        public DateTime StartDate { get; set; }

        //[DataType(DataType.Date)]
        public DateTime EndDate => StartDate.AddDays(DurationInDays);

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // AppUser navigation
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<ExerciseInPlanVM> Exercises { get; set; }
    }
}