using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reborn.IdentityServer4.Shared.Configuration.Configuration.Email;
using Reborn.IdentityServer4.Shared.Configuration.Email;
using SendGrid;

namespace Reborn.IdentityServer4.Shared.Configuration.Helpers;

public static class StartupHelpers
{
    /// <summary>
    ///     Add email senders - configuration of sendgrid, smtp senders
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddEmailSenders(this IServiceCollection services, IConfiguration configuration)
    {
        var smtpConfiguration = configuration.GetSection(nameof(SmtpConfiguration)).Get<SmtpConfiguration>();
        var sendGridConfiguration =
            configuration.GetSection(nameof(SendGridConfiguration)).Get<SendGridConfiguration>();

        if (sendGridConfiguration != null && !string.IsNullOrWhiteSpace(sendGridConfiguration.ApiKey))
        {
            services.AddSingleton<ISendGridClient>(_ => new SendGridClient(sendGridConfiguration.ApiKey));
            services.AddSingleton(sendGridConfiguration);
            services.AddTransient<IEmailSender, SendGridEmailSender>();
        }
        else if (smtpConfiguration != null && !string.IsNullOrWhiteSpace(smtpConfiguration.Host))
        {
            services.AddSingleton(smtpConfiguration);
            services.AddTransient<IEmailSender, SmtpEmailSender>();
        }
        else
        {
            services.AddSingleton<IEmailSender, LogEmailSender>();
        }
    }

    public static void AddDataProtection<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext, IDataProtectionKeyContext
    {
        services.AddDataProtection()
            .SetApplicationName("Reborn.IdentityServer4")
            .PersistKeysToDbContext<TDbContext>();
    }
}