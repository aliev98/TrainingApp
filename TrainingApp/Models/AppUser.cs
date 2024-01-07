using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Models
{
    public class AppUser : IdentityUser
    {
     //   public string UserName { get; set; }
      //  public int AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Goals { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public ICollection<WorkoutPlan> WorkoutPlans { get; set; }
        public List<Exercise> SelectedExercises { get; set; }
    }
}
