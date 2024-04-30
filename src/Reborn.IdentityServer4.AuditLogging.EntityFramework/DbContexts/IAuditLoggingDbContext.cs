using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reborn.IdentityServer4.AuditLogging.EntityFramework.Entities;

namespace Reborn.IdentityServer4.AuditLogging.EntityFramework.DbContexts
{
    public interface IAuditLoggingDbContext<TAuditLog> where TAuditLog : AuditLog
    {
        DbSet<TAuditLog> AuditLog { get; set; }

        Task<int> SaveChangesAsync();
    }
}