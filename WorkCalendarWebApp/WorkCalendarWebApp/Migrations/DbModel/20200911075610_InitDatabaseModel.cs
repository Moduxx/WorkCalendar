using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkCalendarWebApp.Migrations.DbModel
{
    public partial class InitDatabaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    TeamName = table.Column<string>(nullable: false),
                    WorkerID = table.Column<string>(nullable: false),
                    TopicName = table.Column<string>(nullable: false),
                    SubtopicName = table.Column<string>(nullable: false),
                    AdditionalInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => new { x.StartDateTime, x.EndDateTime, x.TeamName, x.WorkerID, x.TopicName, x.SubtopicName });
                });

            migrationBuilder.CreateTable(
                name: "Limit",
                columns: table => new
                {
                    TeamName = table.Column<string>(nullable: false),
                    MaxDaysInARow = table.Column<int>(nullable: false),
                    MaxDaysPerMonth = table.Column<int>(nullable: false),
                    MaxDaysPerYear = table.Column<int>(nullable: false),
                    MaxTopicsPerDay = table.Column<int>(nullable: false),
                    MaxDaysPerQuarter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limit", x => x.TeamName);
                });

            migrationBuilder.CreateTable(
                name: "Objective",
                columns: table => new
                {
                    TeamName = table.Column<string>(nullable: false),
                    WorkerID = table.Column<string>(nullable: false),
                    TopicName = table.Column<string>(nullable: false),
                    SubtopicName = table.Column<string>(nullable: false),
                    IsLearnt = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objective", x => new { x.TeamName, x.WorkerID, x.TopicName, x.SubtopicName });
                });

            migrationBuilder.CreateTable(
                name: "Subtopic",
                columns: table => new
                {
                    TopicName = table.Column<string>(nullable: false),
                    SubtopicName = table.Column<string>(nullable: false),
                    AdditionalInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtopic", x => new { x.TopicName, x.SubtopicName });
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamName = table.Column<string>(nullable: false),
                    WorkerID = table.Column<string>(nullable: false),
                    IsTeamLeader = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => new { x.TeamName, x.WorkerID });
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    TopicName = table.Column<string>(nullable: false),
                    AdditionalInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.TopicName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Limit");

            migrationBuilder.DropTable(
                name: "Objective");

            migrationBuilder.DropTable(
                name: "Subtopic");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
