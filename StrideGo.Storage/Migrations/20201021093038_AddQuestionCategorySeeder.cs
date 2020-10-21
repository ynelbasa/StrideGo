using Microsoft.EntityFrameworkCore.Migrations;

namespace StrideGo.Storage.Migrations
{
    public partial class AddQuestionCategorySeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "StrideGo",
                table: "QuestionCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Training" },
                    { 2, "Injury / Recovery" },
                    { 3, "Running Gears" },
                    { 4, "Nutrition" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "StrideGo",
                table: "QuestionCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "StrideGo",
                table: "QuestionCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "StrideGo",
                table: "QuestionCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "StrideGo",
                table: "QuestionCategory",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
