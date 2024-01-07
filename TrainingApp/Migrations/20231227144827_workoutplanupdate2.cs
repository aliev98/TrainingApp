using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingApp.Migrations
{
    public partial class workoutplanupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseInPlan_WorkoutPlans_WorkoutPlanId",
                table: "ExerciseInPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseInPlan",
                table: "ExerciseInPlan");

            migrationBuilder.RenameTable(
                name: "ExerciseInPlan",
                newName: "ExercisesInPlan");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseInPlan_WorkoutPlanId",
                table: "ExercisesInPlan",
                newName: "IX_ExercisesInPlan_WorkoutPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExercisesInPlan",
                table: "ExercisesInPlan",
                column: "ExerciseInPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesInPlan_WorkoutPlans_WorkoutPlanId",
                table: "ExercisesInPlan",
                column: "WorkoutPlanId",
                principalTable: "WorkoutPlans",
                principalColumn: "WorkoutPlanId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesInPlan_WorkoutPlans_WorkoutPlanId",
                table: "ExercisesInPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExercisesInPlan",
                table: "ExercisesInPlan");

            migrationBuilder.RenameTable(
                name: "ExercisesInPlan",
                newName: "ExerciseInPlan");

            migrationBuilder.RenameIndex(
                name: "IX_ExercisesInPlan_WorkoutPlanId",
                table: "ExerciseInPlan",
                newName: "IX_ExerciseInPlan_WorkoutPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseInPlan",
                table: "ExerciseInPlan",
                column: "ExerciseInPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseInPlan_WorkoutPlans_WorkoutPlanId",
                table: "ExerciseInPlan",
                column: "WorkoutPlanId",
                principalTable: "WorkoutPlans",
                principalColumn: "WorkoutPlanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
