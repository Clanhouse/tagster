using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tagster.Infrastructure.EF.Migrations
{
    public partial class AddRoleToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                schema: "tagster",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "tagster",
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Role" },
                values: new object[] { 1, new DateTime(2022, 1, 6, 17, 56, 2, 321, DateTimeKind.Utc).AddTicks(6509), "admin@admin.com", "secret", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "tagster",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Role",
                schema: "tagster",
                table: "Users");
        }
    }
}
