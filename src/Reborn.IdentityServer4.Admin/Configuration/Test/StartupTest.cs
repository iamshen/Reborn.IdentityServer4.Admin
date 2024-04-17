using Microsoft.Extensions.Logging;

namespace Reborn.IdentityServer4.Admin.Configuration.Test;

public class StartupTest
{
    public StartupTest(IWebHostEnvironment env, IConfiguration configuration)
    {
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        HostingEnvironment = env;
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public IWebHostEnvironment HostingEnvironment { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Adds the IdentityServer4 Admin UI with custom options.
        services
            .AddIdentityServer4AdminUI<AdminIdentityDbContext, IdentityServerConfigurationDbContext,
                IdentityServerPersistedGrantDbContext,
                AdminLogDbContext, AdminAuditLogDbContext, AuditLog, IdentityServerDataProtectionDbContext,
                UserIdentity, UserIdentityRole, UserIdentityUserClaim, UserIdentityUserRole,
                UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken, string,
                IdentityUserDto, IdentityRoleDto, IdentityUsersDto, IdentityRolesDto, IdentityUserRolesDto,
                IdentityUserClaimsDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto,
                IdentityRoleClaimsDto, IdentityUserClaimDto, IdentityRoleClaimDto>(ConfigureUiOptions);

        // Monitor changes in Admin UI views
        services.AddAdminUiRazorRuntimeCompilation(HostingEnvironment);

        // Add email senders which is currently setup for SendGrid and SMTP
        services.AddEmailSenders(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment _, ILoggerFactory _1)
    {
        app.UseRouting();

        app.UseIdentityServer4AdminUi();

        app.UseEndpoints(endpoint =>
        {
            endpoint.MapIdentityServer4AdminUi();
            endpoint.MapIdentityServer4AdminUiHealthChecks();
        });
    }

    public virtual void ConfigureUiOptions(IdentityServer4AdminUIOptions options)
    {
        // Applies configuration from appsettings.
        options.BindConfiguration(Configuration);
        if (HostingEnvironment.IsDevelopment())
            options.Security.UseDeveloperExceptionPage = true;
        else
            options.Security.UseHsts = true;

        // Set migration assembly for application of db migrations
        var migrationsAssembly =
            MigrationAssemblyConfiguration.GetMigrationAssemblyByProvider(options.DatabaseProvider);
        options.DatabaseMigrations.SetMigrationsAssemblies(migrationsAssembly);

        // Use production DbContexts and auth services.
        options.Testing.IsStaging = true;
    }
}