using Microsoft.EntityFrameworkCore.Migrations;

namespace StrideGo.Storage.Migrations
{
    public partial class AddIsActiveToAnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "StrideGo",
                table: "Answer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "StrideGo",
                table: "Answer");
        }
    }
}
