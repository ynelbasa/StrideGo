using Microsoft.EntityFrameworkCore.Migrations;

namespace StrideGo.Storage.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "StrideGo",
                table: "User",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "StrideGo",
                table: "User",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_User_UserId",
                schema: "StrideGo",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_UserId",
                schema: "StrideGo",
                table: "Question");

            migrationBuilder.AlterColumn<int>(
                name: "LastName",
                schema: "StrideGo",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FirstName",
                schema: "StrideGo",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
