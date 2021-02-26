using Microsoft.EntityFrameworkCore.Migrations;

namespace WESTDemo.Infrastracture.Migrations
{
    public partial class RevertLearnerStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "LearnerStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LearnerStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
