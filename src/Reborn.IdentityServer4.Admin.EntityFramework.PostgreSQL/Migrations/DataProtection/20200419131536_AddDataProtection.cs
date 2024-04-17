using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Reborn.IdentityServer4.Admin.EntityFramework.PostgreSQL.Migrations.DataProtection;

public partial class AddDataProtection : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "DataProtectionKeys",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                FriendlyName = table.Column<string>(nullable: true),
                Xml = table.Column<string>(nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_DataProtectionKeys", x => x.Id); });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "DataProtectionKeys");
    }
}