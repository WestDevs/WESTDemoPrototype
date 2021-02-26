using Microsoft.EntityFrameworkCore.Migrations;

namespace WESTDemo.Infrastracture.Migrations
{
    public partial class ModifyLearnerStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LearnerStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "LearnerStatus");
        }
    }
}
