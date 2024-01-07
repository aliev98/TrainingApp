using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingApp.Migrations
{
    public partial class UpdateAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Goals",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "WorkoutPlans",
                columns: table => new
                {
                    WorkoutPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlans", x => x.WorkoutPlanId);
                    table.ForeignKey(
                        name: "FK_WorkoutPlans_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseInPlan",
                columns: table => new
                {
                    ExerciseInPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Repetitions = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    RestSeconds = table.Column<int>(type: "int", nullable: false),
                    WorkoutPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseInPlan", x => x.ExerciseInPlanId);
                    table.ForeignKey(
                        name: "FK_ExerciseInPlan_WorkoutPlans_WorkoutPlanId",
                        column: x => x.WorkoutPlanId,
                        principalTable: "WorkoutPlans",
                        principalColumn: "WorkoutPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseInPlan_WorkoutPlanId",
                table: "ExerciseInPlan",
                column: "WorkoutPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_AppUserId",
                table: "WorkoutPlans",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseInPlan");

            migrationBuilder.DropTable(
                name: "WorkoutPlans");

            migrationBuilder.AlterColumn<string>(
                name: "Goals",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
