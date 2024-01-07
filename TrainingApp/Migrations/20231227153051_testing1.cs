using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingApp.Migrations
{
    public partial class testing1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "exercise",
                table: "WorkoutPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "exercise",
                table: "WorkoutPlans");
        }
    }
}
