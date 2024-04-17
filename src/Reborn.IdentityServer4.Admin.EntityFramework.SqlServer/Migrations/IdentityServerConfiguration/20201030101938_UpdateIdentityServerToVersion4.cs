// Original SQL scripts for database migration come from: https://github.com/RockSolidKnowledge/IdentityServer4.Migration.Scripts/blob/master/MSSQL/ConfigurationDbContext.sql
// Modified by 

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reborn.IdentityServer4.Admin.EntityFramework.SqlServer.Migrations.IdentityServerConfiguration;

public partial class UpdateIdentityServerToVersion4 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            "FK_ApiClaims_ApiResources_ApiResourceId",
            "ApiClaims");

        migrationBuilder.DropForeignKey(
            "FK_ApiProperties_ApiResources_ApiResourceId",
            "ApiProperties");

        migrationBuilder.DropForeignKey(
            "FK_ApiScopeClaims_ApiScopes_ApiScopeId",
            "ApiScopeClaims");

        migrationBuilder.DropForeignKey(
            "FK_ApiScopes_ApiResources_ApiResourceId",
            "ApiScopes");

        migrationBuilder.DropForeignKey(
            "FK_IdentityProperties_IdentityResources_IdentityResourceId",
            "IdentityProperties");

        migrationBuilder.DropIndex(
            "IX_ApiScopes_ApiResourceId",
            "ApiScopes");

        migrationBuilder.DropIndex(
            "IX_ApiScopeClaims_ApiScopeId",
            "ApiScopeClaims");

        migrationBuilder.DropPrimaryKey(
            "PK_IdentityProperties",
            "IdentityProperties");

        migrationBuilder.DropPrimaryKey(
            "PK_ApiProperties",
            "ApiProperties");

        migrationBuilder.DropPrimaryKey(
            "PK_ApiClaims",
            "ApiClaims");

        migrationBuilder.RenameTable(
            "IdentityProperties",
            newName: "IdentityResourceProperties");

        migrationBuilder.RenameTable(
            "ApiProperties",
            newName: "ApiResourceProperties");

        migrationBuilder.RenameTable(
            "ApiClaims",
            newName: "ApiResourceClaims");

        migrationBuilder.RenameIndex(
            "IX_IdentityProperties_IdentityResourceId",
            table: "IdentityResourceProperties",
            newName: "IX_IdentityResourceProperties_IdentityResourceId");

        migrationBuilder.RenameIndex(
            "IX_ApiProperties_ApiResourceId",
            table: "ApiResourceProperties",
            newName: "IX_ApiResourceProperties_ApiResourceId");

        migrationBuilder.RenameIndex(
            "IX_ApiClaims_ApiResourceId",
            table: "ApiResourceClaims",
            newName: "IX_ApiResourceClaims_ApiResourceId");

        migrationBuilder.AddColumn<string>(
            "AllowedIdentityTokenSigningAlgorithms",
            "Clients",
            maxLength: 100,
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            "RequireRequestObject",
            "Clients",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<bool>(
            "Enabled",
            "ApiScopes",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<int>(
            "ScopeId",
            "ApiScopeClaims",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<string>(
            "AllowedAccessTokenSigningAlgorithms",
            "ApiResources",
            maxLength: 100,
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            "ShowInDiscoveryDocument",
            "ApiResources",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddPrimaryKey(
            "PK_IdentityResourceProperties",
            "IdentityResourceProperties",
            "Id");

        migrationBuilder.AddPrimaryKey(
            "PK_ApiResourceProperties",
            "ApiResourceProperties",
            "Id");

        migrationBuilder.AddPrimaryKey(
            "PK_ApiResourceClaims",
            "ApiResourceClaims",
            "Id");

        migrationBuilder.CreateTable(
            "ApiResourceScopes",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Scope = table.Column<string>(maxLength: 200, nullable: false),
                ApiResourceId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiResourceScopes", x => x.Id);
                table.ForeignKey(
                    "FK_ApiResourceScopes_ApiResources_ApiResourceId",
                    x => x.ApiResourceId,
                    "ApiResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ApiResourceSecrets",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Description = table.Column<string>(maxLength: 1000, nullable: true),
                Value = table.Column<string>(maxLength: 4000, nullable: false),
                Expiration = table.Column<DateTime>(nullable: true),
                Type = table.Column<string>(maxLength: 250, nullable: false),
                Created = table.Column<DateTime>(nullable: false),
                ApiResourceId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiResourceSecrets", x => x.Id);
                table.ForeignKey(
                    "FK_ApiResourceSecrets_ApiResources_ApiResourceId",
                    x => x.ApiResourceId,
                    "ApiResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ApiScopeProperties",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Key = table.Column<string>(maxLength: 250, nullable: false),
                Value = table.Column<string>(maxLength: 2000, nullable: false),
                ScopeId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiScopeProperties", x => x.Id);
                table.ForeignKey(
                    "FK_ApiScopeProperties_ApiScopes_ScopeId",
                    x => x.ScopeId,
                    "ApiScopes",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "IdentityResourceClaims",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Type = table.Column<string>(maxLength: 200, nullable: false),
                IdentityResourceId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_IdentityResourceClaims", x => x.Id);
                table.ForeignKey(
                    "FK_IdentityResourceClaims_IdentityResources_IdentityResourceId",
                    x => x.IdentityResourceId,
                    "IdentityResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_ApiScopeClaims_ScopeId",
            "ApiScopeClaims",
            "ScopeId");

        migrationBuilder.CreateIndex(
            "IX_ApiResourceScopes_ApiResourceId",
            "ApiResourceScopes",
            "ApiResourceId");

        migrationBuilder.CreateIndex(
            "IX_ApiResourceSecrets_ApiResourceId",
            "ApiResourceSecrets",
            "ApiResourceId");

        migrationBuilder.CreateIndex(
            "IX_ApiScopeProperties_ScopeId",
            "ApiScopeProperties",
            "ScopeId");

        migrationBuilder.CreateIndex(
            "IX_IdentityResourceClaims_IdentityResourceId",
            "IdentityResourceClaims",
            "IdentityResourceId");

        migrationBuilder.AddForeignKey(
            "FK_ApiResourceClaims_ApiResources_ApiResourceId",
            "ApiResourceClaims",
            "ApiResourceId",
            "ApiResources",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            "FK_ApiResourceProperties_ApiResources_ApiResourceId",
            "ApiResourceProperties",
            "ApiResourceId",
            "ApiResources",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        // migrate data

        migrationBuilder.Sql(@"SET IDENTITY_INSERT ApiResourceSecrets ON;  
GO

INSERT INTO ApiResourceSecrets
 (Id, [Description], [Value], Expiration, [Type], Created, ApiResourceId)
SELECT 
 Id, [Description], [Value], Expiration, [Type], Created, ApiResourceId
FROM ApiSecrets
GO

SET IDENTITY_INSERT ApiResourceSecrets OFF;  
GO");

        migrationBuilder.Sql(@"SET IDENTITY_INSERT IdentityResourceClaims ON;  
GO

INSERT INTO IdentityResourceClaims
 (Id, [Type], IdentityResourceId)
SELECT 
 Id, [Type], IdentityResourceId
FROM IdentityClaims
GO
SET IDENTITY_INSERT IdentityResourceClaims OFF; 
GO");

        migrationBuilder.Sql(@"INSERT INTO ApiResourceScopes 
 ([Scope], [ApiResourceId])
SELECT 
 [Name], [ApiResourceId]
FROM ApiScopes");

        migrationBuilder.Sql(@"UPDATE ApiScopeClaims SET ScopeId = ApiScopeId");

        migrationBuilder.Sql(@"UPDATE ApiScopes SET [Enabled] = 1");

        migrationBuilder.DropTable(
            "ApiSecrets");

        migrationBuilder.DropTable(
            "IdentityClaims");

        migrationBuilder.DropColumn(
            "ApiResourceId",
            "ApiScopes");

        migrationBuilder.DropColumn(
            "ApiScopeId",
            "ApiScopeClaims");

        migrationBuilder.AddForeignKey(
            "FK_ApiScopeClaims_ApiScopes_ScopeId",
            "ApiScopeClaims",
            "ScopeId",
            "ApiScopes",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            "FK_IdentityResourceProperties_IdentityResources_IdentityResourceId",
            "IdentityResourceProperties",
            "IdentityResourceId",
            "IdentityResources",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            "FK_ApiResourceClaims_ApiResources_ApiResourceId",
            "ApiResourceClaims");

        migrationBuilder.DropForeignKey(
            "FK_ApiResourceProperties_ApiResources_ApiResourceId",
            "ApiResourceProperties");

        migrationBuilder.DropForeignKey(
            "FK_ApiScopeClaims_ApiScopes_ScopeId",
            "ApiScopeClaims");

        migrationBuilder.DropForeignKey(
            "FK_IdentityResourceProperties_IdentityResources_IdentityResourceId",
            "IdentityResourceProperties");

        migrationBuilder.DropIndex(
            "IX_ApiScopeClaims_ScopeId",
            "ApiScopeClaims");

        migrationBuilder.DropPrimaryKey(
            "PK_IdentityResourceProperties",
            "IdentityResourceProperties");

        migrationBuilder.DropPrimaryKey(
            "PK_ApiResourceProperties",
            "ApiResourceProperties");

        migrationBuilder.DropPrimaryKey(
            "PK_ApiResourceClaims",
            "ApiResourceClaims");

        migrationBuilder.RenameTable(
            "IdentityResourceProperties",
            newName: "IdentityProperties");

        migrationBuilder.RenameTable(
            "ApiResourceProperties",
            newName: "ApiProperties");

        migrationBuilder.RenameTable(
            "ApiResourceClaims",
            newName: "ApiClaims");

        migrationBuilder.RenameIndex(
            "IX_IdentityResourceProperties_IdentityResourceId",
            table: "IdentityProperties",
            newName: "IX_IdentityProperties_IdentityResourceId");

        migrationBuilder.RenameIndex(
            "IX_ApiResourceProperties_ApiResourceId",
            table: "ApiProperties",
            newName: "IX_ApiProperties_ApiResourceId");

        migrationBuilder.RenameIndex(
            "IX_ApiResourceClaims_ApiResourceId",
            table: "ApiClaims",
            newName: "IX_ApiClaims_ApiResourceId");

        migrationBuilder.AddColumn<int>(
            "ApiResourceId",
            "ApiScopes",
            "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            "ApiScopeId",
            "ApiScopeClaims",
            "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddPrimaryKey(
            "PK_IdentityProperties",
            "IdentityProperties",
            "Id");

        migrationBuilder.AddPrimaryKey(
            "PK_ApiProperties",
            "ApiProperties",
            "Id");

        migrationBuilder.AddPrimaryKey(
            "PK_ApiClaims",
            "ApiClaims",
            "Id");

        migrationBuilder.CreateTable(
            "ApiSecrets",
            table => new
            {
                Id = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ApiResourceId = table.Column<int>("int", nullable: false),
                Created = table.Column<DateTime>("datetime2", nullable: false),
                Description = table.Column<string>("nvarchar(1000)", maxLength: 1000, nullable: true),
                Expiration = table.Column<DateTime>("datetime2", nullable: true),
                Type = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: false),
                Value = table.Column<string>("nvarchar(4000)", maxLength: 4000, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiSecrets", x => x.Id);
                table.ForeignKey(
                    "FK_ApiSecrets_ApiResources_ApiResourceId",
                    x => x.ApiResourceId,
                    "ApiResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "IdentityClaims",
            table => new
            {
                Id = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IdentityResourceId = table.Column<int>("int", nullable: false),
                Type = table.Column<string>("nvarchar(200)", maxLength: 200, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_IdentityClaims", x => x.Id);
                table.ForeignKey(
                    "FK_IdentityClaims_IdentityResources_IdentityResourceId",
                    x => x.IdentityResourceId,
                    "IdentityResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_ApiScopes_ApiResourceId",
            "ApiScopes",
            "ApiResourceId");

        migrationBuilder.CreateIndex(
            "IX_ApiScopeClaims_ApiScopeId",
            "ApiScopeClaims",
            "ApiScopeId");

        migrationBuilder.CreateIndex(
            "IX_ApiSecrets_ApiResourceId",
            "ApiSecrets",
            "ApiResourceId");

        migrationBuilder.CreateIndex(
            "IX_IdentityClaims_IdentityResourceId",
            "IdentityClaims",
            "IdentityResourceId");

        migrationBuilder.AddForeignKey(
            "FK_ApiClaims_ApiResources_ApiResourceId",
            "ApiClaims",
            "ApiResourceId",
            "ApiResources",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            "FK_ApiProperties_ApiResources_ApiResourceId",
            "ApiProperties",
            "ApiResourceId",
            "ApiResources",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        // Rollback data back
        migrationBuilder.Sql(@"SET IDENTITY_INSERT ApiSecrets ON;  
GO

INSERT INTO ApiSecrets
 (Id, [Description], [Value], Expiration, [Type], Created, ApiResourceId)
SELECT 
 Id, [Description], [Value], Expiration, [Type], Created, ApiResourceId
FROM ApiResourceSecrets
GO

SET IDENTITY_INSERT ApiSecrets OFF;
GO");

        migrationBuilder.Sql(@"SET IDENTITY_INSERT IdentityClaims ON;
GO

INSERT INTO IdentityClaims
 (Id, [Type], IdentityResourceId)
SELECT 
 Id, [Type], IdentityResourceId
FROM IdentityResourceClaims
GO
SET IDENTITY_INSERT IdentityClaims OFF;
GO");

        migrationBuilder.Sql(@"UPDATE asp
SET ApiResourceId = arc.ApiResourceId
FROM ApiScopes asp
    INNER JOIN ApiResourceScopes arc
        ON arc.Id = asp.Id
");

        migrationBuilder.Sql(@"UPDATE ApiScopeClaims SET ApiScopeId = ScopeId");

        migrationBuilder.DropTable(
            "ApiResourceScopes");

        migrationBuilder.DropTable(
            "ApiResourceSecrets");

        migrationBuilder.DropTable(
            "ApiScopeProperties");

        migrationBuilder.DropTable(
            "IdentityResourceClaims");

        migrationBuilder.DropColumn(
            "AllowedIdentityTokenSigningAlgorithms",
            "Clients");

        migrationBuilder.DropColumn(
            "RequireRequestObject",
            "Clients");

        migrationBuilder.DropColumn(
            "Enabled",
            "ApiScopes");

        migrationBuilder.DropColumn(
            "ScopeId",
            "ApiScopeClaims");

        migrationBuilder.DropColumn(
            "AllowedAccessTokenSigningAlgorithms",
            "ApiResources");

        migrationBuilder.DropColumn(
            "ShowInDiscoveryDocument",
            "ApiResources");

        migrationBuilder.AddForeignKey(
            "FK_ApiScopeClaims_ApiScopes_ApiScopeId",
            "ApiScopeClaims",
            "ApiScopeId",
            "ApiScopes",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            "FK_ApiScopes_ApiResources_ApiResourceId",
            "ApiScopes",
            "ApiResourceId",
            "ApiResources",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            "FK_IdentityProperties_IdentityResources_IdentityResourceId",
            "IdentityProperties",
            "IdentityResourceId",
            "IdentityResources",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}