using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Models
{
    public class UserProfileVM
    {
        public string? UserName { get; set; }
        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last name is required")]
        public string LastName { get; set; }
        public string? Goals { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }

    }
}
