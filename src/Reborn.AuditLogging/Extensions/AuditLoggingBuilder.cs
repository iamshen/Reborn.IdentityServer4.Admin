using Microsoft.Extensions.DependencyInjection;
using Reborn.AuditLogging.EntityFramework.Extensions;

namespace Reborn.AuditLogging.Extensions
{
    public class AuditLoggingBuilder : IAuditLoggingBuilder
    {
        public AuditLoggingBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}