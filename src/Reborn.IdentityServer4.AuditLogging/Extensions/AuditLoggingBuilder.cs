using Microsoft.Extensions.DependencyInjection;
using Reborn.IdentityServer4.AuditLogging.EntityFramework.Extensions;

namespace Reborn.IdentityServer4.AuditLogging.Extensions
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