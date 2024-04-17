using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reborn.AuditLogging.EntityFramework.Entities;

namespace Reborn.AuditLogging.EntityFramework.DbContexts
{
    public interface IAuditLoggingDbContext<TAuditLog> where TAuditLog : AuditLog
    {
        DbSet<TAuditLog> AuditLog { get; set; }

        Task<int> SaveChangesAsync();
    }
}