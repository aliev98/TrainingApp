using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingApp.Migrations
{
    public partial class UpdateAppUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "AppUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AppUsers_AppUserId",
                table: "Exercises",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutPlans_AppUsers_AppUserId",
                table: "WorkoutPlans",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AppUsers_AppUserId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutPlans_AppUsers_AppUserId",
                table: "WorkoutPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "AppUser");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
