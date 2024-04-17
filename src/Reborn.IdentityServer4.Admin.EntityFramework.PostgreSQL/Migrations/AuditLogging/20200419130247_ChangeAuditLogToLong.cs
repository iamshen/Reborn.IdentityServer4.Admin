using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Reborn.IdentityServer4.Admin.EntityFramework.PostgreSQL.Migrations.AuditLogging;

public partial class ChangeAuditLogToLong : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey("PK_AuditLog", "AuditLog");

        migrationBuilder.AlterColumn<long>(
                "Id",
                "AuditLog",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
            .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        migrationBuilder.AddPrimaryKey("PK_AuditLog", "AuditLog", "Id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey("PK_AuditLog", "AuditLog");

        migrationBuilder.AlterColumn<int>(
                "Id",
                "AuditLog",
                "integer",
                nullable: false,
                oldClrType: typeof(long))
            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
            .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);


        migrationBuilder.AddPrimaryKey("PK_AuditLog", "AuditLog", "Id");
    }
}