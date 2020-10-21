using Microsoft.EntityFrameworkCore.Migrations;

namespace StrideGo.Storage.Migrations
{
    public partial class AddForeignEntitiesToQuestionVoteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                schema: "StrideGo",
                table: "QuestionVote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionVote_QuestionId",
                schema: "StrideGo",
                table: "QuestionVote",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionVote_UserId",
                schema: "StrideGo",
                table: "QuestionVote",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionVote_Question_QuestionId",
                schema: "StrideGo",
                table: "QuestionVote",
                column: "QuestionId",
                principalSchema: "StrideGo",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionVote_User_UserId",
                schema: "StrideGo",
                table: "QuestionVote",
                column: "UserId",
                principalSchema: "StrideGo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionVote_Question_QuestionId",
                schema: "StrideGo",
                table: "QuestionVote");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionVote_User_UserId",
                schema: "StrideGo",
                table: "QuestionVote");

            migrationBuilder.DropIndex(
                name: "IX_QuestionVote_QuestionId",
                schema: "StrideGo",
                table: "QuestionVote");

            migrationBuilder.DropIndex(
                name: "IX_QuestionVote_UserId",
                schema: "StrideGo",
                table: "QuestionVote");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                schema: "StrideGo",
                table: "QuestionVote");
        }
    }
}
