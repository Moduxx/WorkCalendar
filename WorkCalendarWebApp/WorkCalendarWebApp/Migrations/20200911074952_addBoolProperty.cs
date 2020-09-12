using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkCalendarWebApp.Migrations
{
    public partial class addBoolProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMainUser",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMainUser",
                table: "AspNetUsers");
        }
    }
}
