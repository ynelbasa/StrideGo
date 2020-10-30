using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StrideGo.Storage.Migrations
{
    public partial class AddTimestampsAndRelationshipForAnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "StrideGo",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "StrideGo",
                table: "Answer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "StrideGo",
                table: "Answer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Answer_UserId",
                schema: "StrideGo",
                table: "Answer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_User_UserId",
                schema: "StrideGo",
                table: "Answer",
                column: "UserId",
                principalSchema: "StrideGo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_User_UserId",
                schema: "StrideGo",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_UserId",
                schema: "StrideGo",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "StrideGo",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "StrideGo",
                table: "Answer");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "StrideGo",
                table: "Answer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
