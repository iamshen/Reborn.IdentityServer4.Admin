using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reborn.IdentityServer4.Admin.EntityFramework.MySql.Migrations.IdentityServerGrants;

public partial class DbInit : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "DeviceCodes",
            table => new
            {
                UserCode = table.Column<string>(maxLength: 200, nullable: false),
                DeviceCode = table.Column<string>(maxLength: 200, nullable: false),
                SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                ClientId = table.Column<string>(maxLength: 200, nullable: false),
                CreationTime = table.Column<DateTime>(nullable: false),
                Expiration = table.Column<DateTime>(nullable: false),
                Data = table.Column<string>(maxLength: 50000, nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_DeviceCodes", x => x.UserCode); });

        migrationBuilder.CreateTable(
            "PersistedGrants",
            table => new
            {
                Key = table.Column<string>(maxLength: 200, nullable: false),
                Type = table.Column<string>(maxLength: 50, nullable: false),
                SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                ClientId = table.Column<string>(maxLength: 200, nullable: false),
                CreationTime = table.Column<DateTime>(nullable: false),
                Expiration = table.Column<DateTime>(nullable: true),
                Data = table.Column<string>(maxLength: 50000, nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_PersistedGrants", x => x.Key); });

        migrationBuilder.CreateIndex(
            "IX_DeviceCodes_DeviceCode",
            "DeviceCodes",
            "DeviceCode",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_DeviceCodes_Expiration",
            "DeviceCodes",
            "Expiration");

        migrationBuilder.CreateIndex(
            "IX_PersistedGrants_Expiration",
            "PersistedGrants",
            "Expiration");

        migrationBuilder.CreateIndex(
            "IX_PersistedGrants_SubjectId_ClientId_Type",
            "PersistedGrants",
            new[] { "SubjectId", "ClientId", "Type" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "DeviceCodes");

        migrationBuilder.DropTable(
            "PersistedGrants");
    }
}