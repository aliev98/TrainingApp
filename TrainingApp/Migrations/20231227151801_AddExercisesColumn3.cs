using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingApp.Migrations
{
    public partial class AddExercisesColumn3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
    name: "IX_Exercises_WorkoutPlanId",
    table: "Exercises",
    column: "WorkoutPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_WorkoutPlans_WorkoutPlanId",
                table: "Exercises",
                column: "WorkoutPlanId",
                principalTable: "WorkoutPlans",
                principalColumn: "WorkoutPlanId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
