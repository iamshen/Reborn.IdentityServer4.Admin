using Microsoft.Extensions.DependencyInjection;

namespace Reborn.IdentityServer4.AuditLogging.Extensions
{
    public interface IAuditLoggingBuilder
    {
        IServiceCollection Services { get; }
    }
}