using Microsoft.EntityFrameworkCore.Migrations;

namespace Prologue.Migrations
{
    public partial class UpdateAuthorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullNmae",
                table: "Authors",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Authors",
                newName: "FullNmae");
        }
    }
}
