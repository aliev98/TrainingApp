namespace TrainingApp.Models
{
    public class Achievement
    {
        public int AchievementId { get; set; }
        public string Name { get; set; }
        public DateTime CompletionDate { get; set; }
        
        //User navigation
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
