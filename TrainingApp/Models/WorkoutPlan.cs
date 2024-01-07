using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Models
{

    public class WorkoutPlan
    {
        public int WorkoutPlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationInDays { get; set; }
        //AppUser navigation
        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate => StartDate.AddDays(DurationInDays);

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        //ExerciseInPlan navigation
        public List<ExerciseInPlan> Exercises { get; set; } = new List<ExerciseInPlan>();
    }
}
