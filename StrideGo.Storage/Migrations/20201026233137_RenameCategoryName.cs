using Microsoft.EntityFrameworkCore.Migrations;

namespace StrideGo.Storage.Migrations
{
    public partial class RenameCategoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "StrideGo",
                table: "QuestionCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Injury & Recovery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "StrideGo",
                table: "QuestionCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Injury / Recovery");
        }
    }
}
