using Reborn.IdentityServer4.Admin.Shared.ModuleInitializer;

var builder = WebApplication.CreateBuilder();

#region Config

builder.Configuration.AddJsonFile("serilog.json", true, true);
if (builder.Environment.IsDevelopment()) builder.Configuration.AddUserSecrets<Program>();
builder.WebHost.ConfigureKestrel(options => { options.AddServerHeader = false; });

#endregion

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

try
{
    #region Service

    var adminApiConfiguration =
        builder.Configuration.GetSection(nameof(AdminApiConfiguration)).Get<AdminApiConfiguration>();
    builder.Services.AddSingleton(adminApiConfiguration);

    // Add DbContexts
    builder.Services
        .AddDbContexts<AdminIdentityDbContext, IdentityServerConfigurationDbContext,
            IdentityServerPersistedGrantDbContext, AdminLogDbContext, AdminAuditLogDbContext,
            IdentityServerDataProtectionDbContext, AuditLog>(builder.Configuration);

    builder.Services.AddDataProtection<IdentityServerDataProtectionDbContext>();

    // Add email senders which is currently setup for SendGrid and SMTP
    builder.Services.AddEmailSenders(builder.Configuration);

    builder.Services.AddScoped<ControllerExceptionFilterAttribute>();
    builder.Services.AddScoped<IApiErrorResources, ApiErrorResources>();

    // Add authentication services
    builder.Services
        .AddApiAuthentication<AdminIdentityDbContext, UserIdentity, UserIdentityRole>(builder.Configuration);
    // Add authorization services
    builder.Services.AddAuthorizationPolicies();

    var profileTypes = new HashSet<Type>
    {
        typeof(IdentityMapperProfile<IdentityRoleDto, IdentityUserRolesDto, string, IdentityUserClaimsDto,
            IdentityUserClaimDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto,
            IdentityRoleClaimDto, IdentityRoleClaimsDto>)
    };

    builder.Services.AddAdminAspNetIdentityServices<AdminIdentityDbContext, IdentityServerPersistedGrantDbContext,
        IdentityUserDto, IdentityRoleDto, UserIdentity, UserIdentityRole, string, UserIdentityUserClaim,
        UserIdentityUserRole,
        UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken,
        IdentityUsersDto, IdentityRolesDto, IdentityUserRolesDto,
        IdentityUserClaimsDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto,
        IdentityRoleClaimsDto, IdentityUserClaimDto, IdentityRoleClaimDto>(profileTypes);

    builder.Services
        .AddAdminServices<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext,
            AdminLogDbContext>();

    builder.Services.AddAdminApiCors(adminApiConfiguration);

    builder.Services.AddMvcServices<IdentityUserDto, IdentityRoleDto,
        UserIdentity, UserIdentityRole, string, UserIdentityUserClaim, UserIdentityUserRole,
        UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken,
        IdentityUsersDto, IdentityRolesDto, IdentityUserRolesDto,
        IdentityUserClaimsDto, IdentityUserProviderDto, IdentityUserProvidersDto, IdentityUserChangePasswordDto,
        IdentityRoleClaimsDto, IdentityUserClaimDto, IdentityRoleClaimDto>();

    builder.Services.AddSwaggerGen(options =>
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

    builder.Services.AddAuditEventLogging<AdminAuditLogDbContext, AuditLog>(builder.Configuration);

    builder.Services
        .AddIdSHealthChecks<IdentityServerConfigurationDbContext, IdentityServerPersistedGrantDbContext,
            AdminIdentityDbContext, AdminLogDbContext, AdminAuditLogDbContext,
            IdentityServerDataProtectionDbContext>(builder.Configuration, adminApiConfiguration);

    #endregion

    #region Serilog

    builder.Services.AddSerilog((services, loggerConfig) => loggerConfig
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.WithProperty("ApplicationName", builder.Environment.ApplicationName));
    builder.Host.UseSerilog();

    #endregion

    var app = builder.Build();

    app.AddForwardHeaders();

    if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

    #region Swagger

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"{adminApiConfiguration.ApiBaseUrl}/swagger/v1/swagger.json",
            adminApiConfiguration.ApiName);

        c.OAuthClientId(adminApiConfiguration.OidcSwaggerUIClientId);
        c.OAuthAppName(adminApiConfiguration.ApiName);
        c.OAuthUsePkce();
    });

    #endregion

    #region Middlerware

    app.UseRouting();
    app.UseAuthentication();
    app.UseCors();
    app.UseAuthorization();

    #endregion

    app.MapControllers();
    app.MapHealthChecks("/health", new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });


    //NpgsqlModuleInitializer.EnableLegacyTimestampBehavior();

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Api Server terminated unexpectedly");
}
finally
{
    await Log.CloseAndFlushAsync();
}