using Microsoft.Extensions.DependencyInjection;

namespace Reborn.AuditLogging.Extensions
{
    public interface IAuditLoggingBuilder
    {
        IServiceCollection Services { get; }
    }
}