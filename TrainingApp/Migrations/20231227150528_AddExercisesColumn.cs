using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingApp.Migrations
{
    public partial class AddExercisesColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesInPlan_WorkoutPlans_WorkoutPlanId",
                table: "ExercisesInPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExercisesInPlan",
                table: "ExercisesInPlan");

            migrationBuilder.RenameTable(
                name: "ExercisesInPlan",
                newName: "ExercisesInPlans");

            migrationBuilder.RenameIndex(
                name: "IX_ExercisesInPlan_WorkoutPlanId",
                table: "ExercisesInPlans",
                newName: "IX_ExercisesInPlans_WorkoutPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExercisesInPlans",
                table: "ExercisesInPlans",
                column: "ExerciseInPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisesInPlans_WorkoutPlans_WorkoutPlanId",
                table: "ExercisesInPlans",
                column: "WorkoutPlanId",
                principalTable: "WorkoutPlans",
                principalColumn: "WorkoutPlanId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisesInPlans_WorkoutPlans_WorkoutPlanId",
                table: "ExercisesInPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExercisesInPlans",
                table: "ExercisesInPlans");

            migrationBuilder.RenameTable(
                name: "ExercisesInPlans",
                newName: "ExercisesInPlan");

            migrationBuilder.RenameIndex(
                name: "IX_ExercisesInPlans_WorkoutPlanId",
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
    }
}
