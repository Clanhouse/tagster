using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tagster.Infrastructure.EF.Migrations;

public partial class Init : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "tagster");

        migrationBuilder.CreateTable(
            name: "Profiles",
            schema: "tagster",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Href = table.Column<string>(type: "text", nullable: true),
                Name = table.Column<string>(type: "text", nullable: true),
                LastName = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Profiles", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "RefreshTokens",
            schema: "tagster",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Token = table.Column<string>(type: "text", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                RevokedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                UserId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RefreshTokens", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            schema: "tagster",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Email = table.Column<string>(type: "text", nullable: true),
                Password = table.Column<string>(type: "text", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Tags",
            schema: "tagster",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "text", nullable: true),
                ProfileId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tags", x => x.Id);
                table.ForeignKey(
                    name: "FK_Tags_Profiles_ProfileId",
                    column: x => x.ProfileId,
                    principalSchema: "tagster",
                    principalTable: "Profiles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Tags_ProfileId",
            schema: "tagster",
            table: "Tags",
            column: "ProfileId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "RefreshTokens",
            schema: "tagster");

        migrationBuilder.DropTable(
            name: "Tags",
            schema: "tagster");

        migrationBuilder.DropTable(
            name: "Users",
            schema: "tagster");

        migrationBuilder.DropTable(
            name: "Profiles",
            schema: "tagster");
    }
}
