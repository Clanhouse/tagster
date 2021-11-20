using Microsoft.EntityFrameworkCore.Migrations;

namespace Tagster.DataAccess.Migrations
{
    public partial class AddHrefToProfileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Href",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Href",
                table: "Profiles");
        }
    }
}
