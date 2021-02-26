using Microsoft.EntityFrameworkCore.Migrations;

namespace WESTDemo.Infrastracture.Migrations
{
    public partial class ModifyLearnerRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearnerGroup");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Learner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Learner_GroupId",
                table: "Learner",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Learner_Groups_GroupId",
                table: "Learner",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Learner_Groups_GroupId",
                table: "Learner");

            migrationBuilder.DropIndex(
                name: "IX_Learner_GroupId",
                table: "Learner");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Learner");

            migrationBuilder.CreateTable(
                name: "LearnerGroup",
                columns: table => new
                {
                    LearnerId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearnerGroup", x => new { x.LearnerId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_LearnerGroup_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LearnerGroup_Learner_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "Learner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearnerGroup_GroupId",
                table: "LearnerGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerGroup_LearnerId",
                table: "LearnerGroup",
                column: "LearnerId",
                unique: true);
        }
    }
}
