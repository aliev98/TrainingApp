using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Models
{
    [JsonObject]
    public class ExerciseInPlan
    {
        public int ExerciseInPlanId { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }

        // Foreign key to reference the associated workout plan
        [ForeignKey("WorkoutPlan")]
        public int WorkoutPlanId { get; set; }

        // Navigation property to represent the associated workout plan
        public WorkoutPlan WorkoutPlan { get; set; }
    }
}
