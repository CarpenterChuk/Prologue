using Microsoft.EntityFrameworkCore.Migrations;

namespace Prologue.Migrations
{
    public partial class LogTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Lods",
                table: "Lods");

            migrationBuilder.RenameTable(
                name: "Lods",
                newName: "Logs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "Lods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lods",
                table: "Lods",
                column: "Id");
        }
    }
}
