using Microsoft.Extensions.DependencyInjection;

namespace Reborn.IdentityServer4.Admin.AuditLogging.Extensions
{
    public interface IAuditLoggingBuilder
    {
        IServiceCollection Services { get; }
    }
}