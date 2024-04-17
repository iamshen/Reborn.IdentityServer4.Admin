using System;
using System.Threading.Tasks;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Common;
using Reborn.AuditLogging.EntityFramework.Entities;

namespace Reborn.IdentityServer4.Admin.EntityFramework.Repositories.Interfaces;

public interface IAuditLogRepository<TAuditLog> where TAuditLog : AuditLog
{
    bool AutoSaveChanges { get; set; }

    Task<PagedList<TAuditLog>> GetAsync(string @event, string source, string category, DateTime? created,
        string subjectIdentifier, string subjectName, int page = 1, int pageSize = 10);

    Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
}