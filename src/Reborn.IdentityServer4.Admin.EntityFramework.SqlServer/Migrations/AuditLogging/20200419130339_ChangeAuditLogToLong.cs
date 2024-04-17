using Microsoft.EntityFrameworkCore.Migrations;

namespace Reborn.IdentityServer4.Admin.EntityFramework.SqlServer.Migrations.AuditLogging;

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
                oldType: "int")
            .Annotation("SqlServer:Identity", "1, 1")
            .OldAnnotation("SqlServer:Identity", "1, 1");

        migrationBuilder.AddPrimaryKey("PK_AuditLog", "AuditLog", "Id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey("PK_AuditLog", "AuditLog");

        migrationBuilder.AlterColumn<int>(
                "Id",
                "AuditLog",
                "int",
                nullable: false,
                oldClrType: typeof(long))
            .Annotation("SqlServer:Identity", "1, 1")
            .OldAnnotation("SqlServer:Identity", "1, 1");

        migrationBuilder.AddPrimaryKey("PK_AuditLog", "AuditLog", "Id");
    }
}