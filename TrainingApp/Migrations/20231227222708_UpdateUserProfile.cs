using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingApp.Migrations
{
    public partial class UpdateUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "exercise",
                table: "WorkoutPlans");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "exercise",
                table: "WorkoutPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
