using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Models;

namespace TrainingApp.Data
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        //  public DbSet<AppUser> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<ExerciseInPlan> ExercisesInPlans { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkoutPlan>()
                .HasMany(wp => wp.Exercises)
                .WithOne(e => e.WorkoutPlan)
                .HasForeignKey(e => e.WorkoutPlanId);

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
