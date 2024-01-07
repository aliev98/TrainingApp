using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingApp.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "ExerciseInPlan");

            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "ExerciseInPlan");

            migrationBuilder.RenameColumn(
                name: "RestSeconds",
                table: "ExerciseInPlan",
                newName: "Reps");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "WorkoutPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "WorkoutPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ExerciseInPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "WorkoutPlans");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "WorkoutPlans");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ExerciseInPlan");

            migrationBuilder.RenameColumn(
                name: "Reps",
                table: "ExerciseInPlan",
                newName: "RestSeconds");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "ExerciseInPlan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "ExerciseInPlan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
