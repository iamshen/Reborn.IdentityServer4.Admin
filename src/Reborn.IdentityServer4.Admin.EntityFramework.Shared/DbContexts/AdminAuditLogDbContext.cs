using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reborn.IdentityServer4.Admin.AuditLogging.EntityFramework.DbContexts;
using Reborn.IdentityServer4.Admin.AuditLogging.EntityFramework.Entities;

namespace Reborn.IdentityServer4.Admin.EntityFramework.Shared.DbContexts;

public class AdminAuditLogDbContext : DbContext, IAuditLoggingDbContext<AuditLog>
{
    public AdminAuditLogDbContext(DbContextOptions<AdminAuditLogDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    public Task<int> SaveChangesAsync() => base.SaveChangesAsync();

    public DbSet<AuditLog> AuditLog { get; set; }
}