using Microsoft.EntityFrameworkCore;
using Reborn.IdentityServer4.AuditLogging.EntityFramework.Entities;

namespace Reborn.IdentityServer4.AuditLogging.EntityFramework.DbContexts.Default
{
    public class DefaultAuditLoggingDbContext : AuditLoggingDbContext<AuditLog>
    {
        public DefaultAuditLoggingDbContext(DbContextOptions<DefaultAuditLoggingDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {

        }
    }
}