using Reborn.IdentityServer4.Admin.Shared.ModuleInitializer;

const string seedArgs = "/seed";
const string migrateOnlyArgs = "/migrateonly";

var builder = WebApplication.CreateBuilder(args.Where(x => x != seedArgs).ToArray());

#region Config

builder.Configuration.AddJsonFile("serilog.json", true, true);
builder.Configuration.AddJsonFile("identitydata.json", true, true);
builder.Configuration.AddJsonFile("identityserverdata.json", true, true);
if (builder.Environment.IsDevelopment()) builder.Configuration.AddUserSecrets<Program>();
builder.WebHost.ConfigureKestrel(options => { options.AddServerHeader = false; });

#endregion

Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();

try
{
    #region AdminUI

    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

    builder.Services
        .AddIdentityServer4AdminUI<AdminIdentityDbContext, IdentityServerConfigurationDbContext,
            IdentityServerPersistedGrantDbContext,
            AdminLogDbContext, AdminAuditLogDbContext, AuditLog, IdentityServerDataProtectionDbContext,
            UserIdentity, UserIdentityRole, UserIdentityUserClaim, UserIdentityUserRole,
            UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken, string,
            IdentityUserDto, IdentityRoleDto, IdentityUsersDto, IdentityRolesDto, IdentityUserRolesDto,
            IdentityUserClaimsDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto,
            IdentityRoleClaimsDto, IdentityUserClaimDto, IdentityRoleClaimDto>(options =>
        {
            // Applies configuration from appsettings.
            options.BindConfiguration(builder.Configuration);

            options.Security.UseDeveloperExceptionPage = builder.Environment.IsDevelopment();
            options.Security.UseHsts = builder.Environment.IsDevelopment();

            // Set migration assembly for application of db migrations
            var migrationsAssembly =
                MigrationAssemblyConfiguration.GetMigrationAssemblyByProvider(options.DatabaseProvider);
            options.DatabaseMigrations.SetMigrationsAssemblies(migrationsAssembly);

            // Use production DbContexts and auth services.
            options.Testing.IsStaging = false;
        });

    // Monitor changes in Admin UI views
    builder.Services.AddAdminUiRazorRuntimeCompilation(builder.Environment);

    // Add email senders which is currently setup for SendGrid and SMTP
    builder.Services.AddEmailSenders(builder.Configuration);

    #endregion

    #region Serilog

    builder.Services.AddSerilog((services, loggerConfig) => loggerConfig
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.WithProperty("ApplicationName", builder.Environment.ApplicationName));
    builder.Host.UseSerilog();

    #endregion

    var app = builder.Build();

    #region Migrations


    var migrationComplete = await ApplyDbMigrationsWithDataSeedAsync(args, builder.Configuration, app.Services);
    if (args.Any(x => x == migrateOnlyArgs))
    {
        await app.StopAsync();
        if (!migrationComplete) Environment.ExitCode = -1;

        return;
    }

    #endregion

    #region Middleware

    app.UseRouting();
    app.UseIdentityServer4AdminUi();
    app.MapIdentityServer4AdminUi();
    app.MapIdentityServer4AdminUiHealthChecks();

    #endregion

    //NpgsqlModuleInitializer.EnableLegacyTimestampBehavior();

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    await Log.CloseAndFlushAsync();
}

return;

static Task<bool> ApplyDbMigrationsWithDataSeedAsync(string[] args, IConfiguration configuration,
    IServiceProvider serviceProvider)
{
    var applyDbMigrationWithDataSeedFromProgramArguments = args.Any(x => x == seedArgs);
    if (applyDbMigrationWithDataSeedFromProgramArguments) args = args.Except([seedArgs]).ToArray();

    var seedConfiguration = configuration.GetSection(nameof(SeedConfiguration)).Get<SeedConfiguration>();
    var databaseMigrationsConfiguration = configuration.GetSection(nameof(DatabaseMigrationsConfiguration))
        .Get<DatabaseMigrationsConfiguration>();

    return DbMigrationHelpers
        .ApplyDbMigrationsWithDataSeedAsync<IdentityServerConfigurationDbContext, AdminIdentityDbContext,
            IdentityServerPersistedGrantDbContext, AdminLogDbContext, AdminAuditLogDbContext,
            IdentityServerDataProtectionDbContext, UserIdentity, UserIdentityRole>(serviceProvider,
            applyDbMigrationWithDataSeedFromProgramArguments, seedConfiguration, databaseMigrationsConfiguration);
}