using Microsoft.EntityFrameworkCore.Migrations;

namespace StrideGo.Storage.Migrations
{
    public partial class AddQuestionCategoryRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionCategoryId",
                schema: "StrideGo",
                table: "Question",
                column: "QuestionCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_QuestionCategory_QuestionCategoryId",
                schema: "StrideGo",
                table: "Question",
                column: "QuestionCategoryId",
                principalSchema: "StrideGo",
                principalTable: "QuestionCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_QuestionCategory_QuestionCategoryId",
                schema: "StrideGo",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_QuestionCategoryId",
                schema: "StrideGo",
                table: "Question");
        }
    }
}
