using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Reborn.IdentityServer4.Admin.EntityFramework.PostgreSQL.Migrations.IdentityServerConfiguration;

public partial class DbInit : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "ApiResources",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Enabled = table.Column<bool>(nullable: false),
                Name = table.Column<string>(maxLength: 200, nullable: false),
                DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                Description = table.Column<string>(maxLength: 1000, nullable: true),
                Created = table.Column<DateTime>(nullable: false),
                Updated = table.Column<DateTime>(nullable: true),
                LastAccessed = table.Column<DateTime>(nullable: true),
                NonEditable = table.Column<bool>(nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_ApiResources", x => x.Id); });

        migrationBuilder.CreateTable(
            "Clients",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Enabled = table.Column<bool>(nullable: false),
                ClientId = table.Column<string>(maxLength: 200, nullable: false),
                ProtocolType = table.Column<string>(maxLength: 200, nullable: false),
                RequireClientSecret = table.Column<bool>(nullable: false),
                ClientName = table.Column<string>(maxLength: 200, nullable: true),
                Description = table.Column<string>(maxLength: 1000, nullable: true),
                ClientUri = table.Column<string>(maxLength: 2000, nullable: true),
                LogoUri = table.Column<string>(maxLength: 2000, nullable: true),
                RequireConsent = table.Column<bool>(nullable: false),
                AllowRememberConsent = table.Column<bool>(nullable: false),
                AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(nullable: false),
                RequirePkce = table.Column<bool>(nullable: false),
                AllowPlainTextPkce = table.Column<bool>(nullable: false),
                AllowAccessTokensViaBrowser = table.Column<bool>(nullable: false),
                FrontChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                FrontChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                BackChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                BackChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                AllowOfflineAccess = table.Column<bool>(nullable: false),
                IdentityTokenLifetime = table.Column<int>(nullable: false),
                AccessTokenLifetime = table.Column<int>(nullable: false),
                AuthorizationCodeLifetime = table.Column<int>(nullable: false),
                ConsentLifetime = table.Column<int>(nullable: true),
                AbsoluteRefreshTokenLifetime = table.Column<int>(nullable: false),
                SlidingRefreshTokenLifetime = table.Column<int>(nullable: false),
                RefreshTokenUsage = table.Column<int>(nullable: false),
                UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(nullable: false),
                RefreshTokenExpiration = table.Column<int>(nullable: false),
                AccessTokenType = table.Column<int>(nullable: false),
                EnableLocalLogin = table.Column<bool>(nullable: false),
                IncludeJwtId = table.Column<bool>(nullable: false),
                AlwaysSendClientClaims = table.Column<bool>(nullable: false),
                ClientClaimsPrefix = table.Column<string>(maxLength: 200, nullable: true),
                PairWiseSubjectSalt = table.Column<string>(maxLength: 200, nullable: true),
                Created = table.Column<DateTime>(nullable: false),
                Updated = table.Column<DateTime>(nullable: true),
                LastAccessed = table.Column<DateTime>(nullable: true),
                UserSsoLifetime = table.Column<int>(nullable: true),
                UserCodeType = table.Column<string>(maxLength: 100, nullable: true),
                DeviceCodeLifetime = table.Column<int>(nullable: false),
                NonEditable = table.Column<bool>(nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Clients", x => x.Id); });

        migrationBuilder.CreateTable(
            "IdentityResources",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Enabled = table.Column<bool>(nullable: false),
                Name = table.Column<string>(maxLength: 200, nullable: false),
                DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                Description = table.Column<string>(maxLength: 1000, nullable: true),
                Required = table.Column<bool>(nullable: false),
                Emphasize = table.Column<bool>(nullable: false),
                ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                Created = table.Column<DateTime>(nullable: false),
                Updated = table.Column<DateTime>(nullable: true),
                NonEditable = table.Column<bool>(nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_IdentityResources", x => x.Id); });

        migrationBuilder.CreateTable(
            "ApiClaims",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Type = table.Column<string>(maxLength: 200, nullable: false),
                ApiResourceId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiClaims", x => x.Id);
                table.ForeignKey(
                    "FK_ApiClaims_ApiResources_ApiResourceId",
                    x => x.ApiResourceId,
                    "ApiResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ApiProperties",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Key = table.Column<string>(maxLength: 250, nullable: false),
                Value = table.Column<string>(maxLength: 2000, nullable: false),
                ApiResourceId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiProperties", x => x.Id);
                table.ForeignKey(
                    "FK_ApiProperties_ApiResources_ApiResourceId",
                    x => x.ApiResourceId,
                    "ApiResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ApiScopes",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(maxLength: 200, nullable: false),
                DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                Description = table.Column<string>(maxLength: 1000, nullable: true),
                Required = table.Column<bool>(nullable: false),
                Emphasize = table.Column<bool>(nullable: false),
                ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                ApiResourceId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiScopes", x => x.Id);
                table.ForeignKey(
                    "FK_ApiScopes_ApiResources_ApiResourceId",
                    x => x.ApiResourceId,
                    "ApiResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ApiSecrets",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Description = table.Column<string>(maxLength: 1000, nullable: true),
                Value = table.Column<string>(maxLength: 4000, nullable: false),
                Expiration = table.Column<DateTime>(nullable: true),
                Type = table.Column<string>(maxLength: 250, nullable: false),
                Created = table.Column<DateTime>(nullable: false),
                ApiResourceId = table.Column<int>(nullable: false)
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
            "ClientClaims",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Type = table.Column<string>(maxLength: 250, nullable: false),
                Value = table.Column<string>(maxLength: 250, nullable: false),
                ClientId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientClaims", x => x.Id);
                table.ForeignKey(
                    "FK_ClientClaims_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientCorsOrigins",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Origin = table.Column<string>(maxLength: 150, nullable: false),
                ClientId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientCorsOrigins", x => x.Id);
                table.ForeignKey(
                    "FK_ClientCorsOrigins_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientGrantTypes",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                GrantType = table.Column<string>(maxLength: 250, nullable: false),
                ClientId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientGrantTypes", x => x.Id);
                table.ForeignKey(
                    "FK_ClientGrantTypes_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientIdPRestrictions",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Provider = table.Column<string>(maxLength: 200, nullable: false),
                ClientId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientIdPRestrictions", x => x.Id);
                table.ForeignKey(
                    "FK_ClientIdPRestrictions_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientPostLogoutRedirectUris",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                PostLogoutRedirectUri = table.Column<string>(maxLength: 2000, nullable: false),
                ClientId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientPostLogoutRedirectUris", x => x.Id);
                table.ForeignKey(
                    "FK_ClientPostLogoutRedirectUris_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientProperties",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Key = table.Column<string>(maxLength: 250, nullable: false),
                Value = table.Column<string>(maxLength: 2000, nullable: false),
                ClientId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientProperties", x => x.Id);
                table.ForeignKey(
                    "FK_ClientProperties_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientRedirectUris",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                RedirectUri = table.Column<string>(maxLength: 2000, nullable: false),
                ClientId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientRedirectUris", x => x.Id);
                table.ForeignKey(
                    "FK_ClientRedirectUris_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientScopes",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Scope = table.Column<string>(maxLength: 200, nullable: false),
                ClientId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientScopes", x => x.Id);
                table.ForeignKey(
                    "FK_ClientScopes_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientSecrets",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Description = table.Column<string>(maxLength: 2000, nullable: true),
                Value = table.Column<string>(maxLength: 4000, nullable: false),
                Expiration = table.Column<DateTime>(nullable: true),
                Type = table.Column<string>(maxLength: 250, nullable: false),
                Created = table.Column<DateTime>(nullable: false),
                ClientId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientSecrets", x => x.Id);
                table.ForeignKey(
                    "FK_ClientSecrets_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "IdentityClaims",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Type = table.Column<string>(maxLength: 200, nullable: false),
                IdentityResourceId = table.Column<int>(nullable: false)
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

        migrationBuilder.CreateTable(
            "IdentityProperties",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Key = table.Column<string>(maxLength: 250, nullable: false),
                Value = table.Column<string>(maxLength: 2000, nullable: false),
                IdentityResourceId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_IdentityProperties", x => x.Id);
                table.ForeignKey(
                    "FK_IdentityProperties_IdentityResources_IdentityResourceId",
                    x => x.IdentityResourceId,
                    "IdentityResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ApiScopeClaims",
            table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Type = table.Column<string>(maxLength: 200, nullable: false),
                ApiScopeId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiScopeClaims", x => x.Id);
                table.ForeignKey(
                    "FK_ApiScopeClaims_ApiScopes_ApiScopeId",
                    x => x.ApiScopeId,
                    "ApiScopes",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_ApiClaims_ApiResourceId",
            "ApiClaims",
            "ApiResourceId");

        migrationBuilder.CreateIndex(
            "IX_ApiProperties_ApiResourceId",
            "ApiProperties",
            "ApiResourceId");

        migrationBuilder.CreateIndex(
            "IX_ApiResources_Name",
            "ApiResources",
            "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_ApiScopeClaims_ApiScopeId",
            "ApiScopeClaims",
            "ApiScopeId");

        migrationBuilder.CreateIndex(
            "IX_ApiScopes_ApiResourceId",
            "ApiScopes",
            "ApiResourceId");

        migrationBuilder.CreateIndex(
            "IX_ApiScopes_Name",
            "ApiScopes",
            "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_ApiSecrets_ApiResourceId",
            "ApiSecrets",
            "ApiResourceId");

        migrationBuilder.CreateIndex(
            "IX_ClientClaims_ClientId",
            "ClientClaims",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientCorsOrigins_ClientId",
            "ClientCorsOrigins",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientGrantTypes_ClientId",
            "ClientGrantTypes",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientIdPRestrictions_ClientId",
            "ClientIdPRestrictions",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientPostLogoutRedirectUris_ClientId",
            "ClientPostLogoutRedirectUris",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientProperties_ClientId",
            "ClientProperties",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientRedirectUris_ClientId",
            "ClientRedirectUris",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_Clients_ClientId",
            "Clients",
            "ClientId",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_ClientScopes_ClientId",
            "ClientScopes",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientSecrets_ClientId",
            "ClientSecrets",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_IdentityClaims_IdentityResourceId",
            "IdentityClaims",
            "IdentityResourceId");

        migrationBuilder.CreateIndex(
            "IX_IdentityProperties_IdentityResourceId",
            "IdentityProperties",
            "IdentityResourceId");

        migrationBuilder.CreateIndex(
            "IX_IdentityResources_Name",
            "IdentityResources",
            "Name",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "ApiClaims");

        migrationBuilder.DropTable(
            "ApiProperties");

        migrationBuilder.DropTable(
            "ApiScopeClaims");

        migrationBuilder.DropTable(
            "ApiSecrets");

        migrationBuilder.DropTable(
            "ClientClaims");

        migrationBuilder.DropTable(
            "ClientCorsOrigins");

        migrationBuilder.DropTable(
            "ClientGrantTypes");

        migrationBuilder.DropTable(
            "ClientIdPRestrictions");

        migrationBuilder.DropTable(
            "ClientPostLogoutRedirectUris");

        migrationBuilder.DropTable(
            "ClientProperties");

        migrationBuilder.DropTable(
            "ClientRedirectUris");

        migrationBuilder.DropTable(
            "ClientScopes");

        migrationBuilder.DropTable(
            "ClientSecrets");

        migrationBuilder.DropTable(
            "IdentityClaims");

        migrationBuilder.DropTable(
            "IdentityProperties");

        migrationBuilder.DropTable(
            "ApiScopes");

        migrationBuilder.DropTable(
            "Clients");

        migrationBuilder.DropTable(
            "IdentityResources");

        migrationBuilder.DropTable(
            "ApiResources");
    }
}