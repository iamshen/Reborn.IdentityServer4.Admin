using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Reborn.IdentityServer4.Admin.Api.Middlewares;
namespace Reborn.IdentityServer4.Admin.Api.Configuration.Test;

public class Startup
{
    public Startup(IWebHostEnvironment env, IConfiguration configuration)
    {
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        HostingEnvironment = env;
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public IWebHostEnvironment HostingEnvironment { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var adminApiConfiguration =
            Configuration.GetSection(nameof(AdminApiConfiguration)).Get<AdminApiConfiguration>();
        services.AddSingleton(adminApiConfiguration);

        // Add DbContexts
        RegisterDbContexts(services);

        services.AddDataProtection<IdentityServerDataProtectionDbContext>();

        // Add email senders which is currently setup for SendGrid and SMTP
        services.AddEmailSenders(Configuration);

        services.AddScoped<ControllerExceptionFilterAttribute>();
        services.AddScoped<IApiErrorResources, ApiErrorResources>();

        // Add authentication services
        RegisterAuthentication(services);

        // Add authorization services
        RegisterAuthorization(services);

        var profileTypes = new HashSet<Type>
        {
            typeof(IdentityMapperProfile<IdentityRoleDto, IdentityUserRolesDto, string, IdentityUserClaimsDto,
                IdentityUserClaimDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto,
                IdentityRoleClaimDto, IdentityRoleClaimsDto>)
        };

        services.AddAdminAspNetIdentityServices<AdminIdentityDbContext, IdentityServerPersistedGrantDbContext,
            IdentityUserDto, IdentityRoleDto, UserIdentity, UserIdentityRole, string, UserIdentityUserClaim,
            UserIdentityUserRole,
            UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken,
            IdentityUsersDto, IdentityRolesDto, IdentityUserRolesDto,
            IdentityUserClaimsDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto,
            IdentityRoleClaimsDto, IdentityUserClaimDto, IdentityRoleClaimDto>(profileTypes);

        services
            .AddAdminServices<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext,
                AdminLogDbContext>();

        services.AddAdminApiCors(adminApiConfiguration);

        services.AddMvcServices<IdentityUserDto, IdentityRoleDto,
            UserIdentity, UserIdentityRole, string, UserIdentityUserClaim, UserIdentityUserRole,
            UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken,
            IdentityUsersDto, IdentityRolesDto, IdentityUserRolesDto,
            IdentityUserClaimsDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto,
            IdentityRoleClaimsDto, IdentityUserClaimDto, IdentityRoleClaimDto>();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(adminApiConfiguration.ApiVersion,
                new OpenApiInfo { Title = adminApiConfiguration.ApiName, Version = adminApiConfiguration.ApiVersion });

            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri($"{adminApiConfiguration.IdentityServerBaseUrl}/connect/authorize"),
                        TokenUrl = new Uri($"{adminApiConfiguration.IdentityServerBaseUrl}/connect/token"),
                        Scopes = new Dictionary<string, string>
                        {
                            { adminApiConfiguration.OidcApiName, adminApiConfiguration.ApiName }
                        }
                    }
                }
            });
            options.OperationFilter<AuthorizeCheckOperationFilter>();
        });

        services.AddAuditEventLogging<AdminAuditLogDbContext, AuditLog>(Configuration);

        services
            .AddIdSHealthChecks<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext,
                AdminIdentityDbContext, AdminLogDbContext, AdminAuditLogDbContext,
                IdentityServerDataProtectionDbContext>(Configuration, adminApiConfiguration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AdminApiConfiguration adminApiConfiguration)
    {
        app.AddForwardHeaders();

        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint($"{adminApiConfiguration.ApiBaseUrl}/swagger/v1/swagger.json",
                adminApiConfiguration.ApiName);

            c.OAuthClientId(adminApiConfiguration.OidcSwaggerUIClientId);
            c.OAuthAppName(adminApiConfiguration.ApiName);
            c.OAuthUsePkce();
        });

        app.UseRouting();
        UseAuthentication(app);
        app.UseCors();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();

            endpoints.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        });
    }

    public virtual void RegisterDbContexts(IServiceCollection services)
    {
        services
            .AddDbContexts<AdminIdentityDbContext, IdentityServerConfigurationDbContext,
                IdentityServerPersistedGrantDbContext, AdminLogDbContext, AdminAuditLogDbContext,
                IdentityServerDataProtectionDbContext, AuditLog>(Configuration);
    }

    public virtual void RegisterAuthentication(IServiceCollection services)
    {
        services.AddApiAuthentication<AdminIdentityDbContext, UserIdentity, UserIdentityRole>(Configuration);
    }

    public virtual void RegisterAuthorization(IServiceCollection services)
    {
        services.AddAuthorizationPolicies();
    }

    public virtual void UseAuthentication(IApplicationBuilder app)
    {
        app.UseAuthentication();
    }
}

public class StartupTest(IWebHostEnvironment env, IConfiguration configuration) : Startup(env, configuration)
{
    public override void RegisterDbContexts(IServiceCollection services)
    {
        services
            .RegisterDbContextsStaging<AdminIdentityDbContext, IdentityServerConfigurationDbContext,
                IdentityServerPersistedGrantDbContext, AdminLogDbContext, AdminAuditLogDbContext,
                IdentityServerDataProtectionDbContext>();
    }

    public override void RegisterAuthentication(IServiceCollection services)
    {
        services
            .AddIdentity<UserIdentity, UserIdentityRole>(options
                => Configuration.GetSection(nameof(IdentityOptions)).Bind(options))
            .AddEntityFrameworkStores<AdminIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddCookie(JwtBearerDefaults.AuthenticationScheme);
    }

    public override void RegisterAuthorization(IServiceCollection services)
    {
        services.AddAuthorizationPolicies();
    }

    public override void UseAuthentication(IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseMiddleware<AuthenticatedTestRequestMiddleware>();
    }
}