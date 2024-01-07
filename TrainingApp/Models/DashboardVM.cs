namespace TrainingApp.Models
{
    public class DashboardVM
    {
        public string UserName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public List<WorkoutPlan> WorkoutPlans { get; set; }
        public List<Achievement> Achievements { get; set; }
    }
}
