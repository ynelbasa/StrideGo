using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StrideGo.Storage.Migrations
{
    public partial class CreateIdentitySchema : Migration
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

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "StrideGo",
                table: "User",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                schema: "StrideGo",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "StrideGo",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "StrideGo",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                schema: "StrideGo",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                schema: "StrideGo",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                schema: "StrideGo",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                schema: "StrideGo",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                schema: "StrideGo",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                schema: "StrideGo",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "StrideGo",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                schema: "StrideGo",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                schema: "StrideGo",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                schema: "StrideGo",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "StrideGo",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "StrideGo",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "StrideGo",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "StrideGo",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "StrideGo",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

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
