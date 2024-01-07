using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingApp.Migrations
{
    public partial class UpdateAppUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Users_AppUserId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlans_Users_AppUserId",
                table: "WorkoutPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AppUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AppUser_AppUserId",
                table: "Exercises",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlans_AppUser_AppUserId",
                table: "WorkoutPlans",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AppUser_AppUserId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlans_AppUser_AppUserId",
                table: "WorkoutPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser");

            migrationBuilder.RenameTable(
                name: "AppUser",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Users_AppUserId",
                table: "Exercises",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlans_Users_AppUserId",
                table: "WorkoutPlans",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
