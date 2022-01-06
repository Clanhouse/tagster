using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tagster.Infrastructure.EF.Migrations;

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
            values: new object[] { 1, new DateTime(2022, 1, 6, 20, 26, 41, 443, DateTimeKind.Utc).AddTicks(8126), "admin@admin.com", "AQAAAAEAACcQAAAAEN7Q97rdcoKZ9+bM9iSC5Md+ry5oycxrN/Jvyfs7u0RARKav687ggnAEaqxdH4ooSw==", "Admin" });
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
