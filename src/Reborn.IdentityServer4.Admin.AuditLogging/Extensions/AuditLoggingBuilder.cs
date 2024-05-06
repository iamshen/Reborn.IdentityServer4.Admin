using Microsoft.Extensions.DependencyInjection;
using Reborn.IdentityServer4.Admin.AuditLogging.EntityFramework.Extensions;

namespace Reborn.IdentityServer4.Admin.AuditLogging.Extensions
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