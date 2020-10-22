using Microsoft.EntityFrameworkCore.Migrations;

namespace StrideGo.Storage.Migrations
{
    public partial class DropUserIdentityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_User_UserId",
                schema: "StrideGo",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionVote_Question_QuestionId",
                schema: "StrideGo",
                table: "QuestionVote");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionVote_User_UserId",
                schema: "StrideGo",
                table: "QuestionVote");

            migrationBuilder.DropTable(
                name: "User",
                schema: "StrideGo");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "StrideGo");

            migrationBuilder.DropIndex(
                name: "IX_QuestionVote_QuestionId",
                schema: "StrideGo",
                table: "QuestionVote");

            migrationBuilder.DropIndex(
                name: "IX_QuestionVote_UserId",
                schema: "StrideGo",
                table: "QuestionVote");

            migrationBuilder.DropIndex(
                name: "IX_Question_UserId",
                schema: "StrideGo",
                table: "Question");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                schema: "StrideGo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "StrideGo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Question_UserId",
                schema: "StrideGo",
                table: "Question",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_User_UserId",
                schema: "StrideGo",
                table: "Question",
                column: "UserId",
                principalSchema: "StrideGo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
