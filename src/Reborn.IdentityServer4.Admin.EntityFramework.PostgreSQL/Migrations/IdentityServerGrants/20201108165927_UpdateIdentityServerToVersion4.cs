using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reborn.IdentityServer4.Admin.EntityFramework.PostgreSQL.Migrations.IdentityServerGrants;

public partial class UpdateIdentityServerToVersion4 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<DateTime>(
            "ConsumedTime",
            "PersistedGrants",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            "Description",
            "PersistedGrants",
            maxLength: 200,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            "SessionId",
            "PersistedGrants",
            maxLength: 100,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            "Description",
            "DeviceCodes",
            maxLength: 200,
            nullable: true);

        migrationBuilder.AddColumn<string>(
            "SessionId",
            "DeviceCodes",
            maxLength: 100,
            nullable: true);

        migrationBuilder.CreateIndex(
            "IX_PersistedGrants_SubjectId_SessionId_Type",
            "PersistedGrants",
            new[] { "SubjectId", "SessionId", "Type" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            "IX_PersistedGrants_SubjectId_SessionId_Type",
            "PersistedGrants");

        migrationBuilder.DropColumn(
            "ConsumedTime",
            "PersistedGrants");

        migrationBuilder.DropColumn(
            "Description",
            "PersistedGrants");

        migrationBuilder.DropColumn(
            "SessionId",
            "PersistedGrants");

        migrationBuilder.DropColumn(
            "Description",
            "DeviceCodes");

        migrationBuilder.DropColumn(
            "SessionId",
            "DeviceCodes");
    }
}