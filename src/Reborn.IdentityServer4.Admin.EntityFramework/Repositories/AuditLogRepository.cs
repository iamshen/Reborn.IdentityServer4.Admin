﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Common;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Enums;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Extensions;
using Reborn.IdentityServer4.Admin.EntityFramework.Repositories.Interfaces;
using Reborn.IdentityServer4.Admin.AuditLogging.EntityFramework.DbContexts;
using Reborn.IdentityServer4.Admin.AuditLogging.EntityFramework.Entities;

namespace Reborn.IdentityServer4.Admin.EntityFramework.Repositories;

public class AuditLogRepository<TDbContext, TAuditLog>(TDbContext dbContext) : IAuditLogRepository<TAuditLog>
    where TDbContext : IAuditLoggingDbContext<TAuditLog>
    where TAuditLog : AuditLog
{
    protected readonly TDbContext DbContext = dbContext;

    public async Task<PagedList<TAuditLog>> GetAsync(string @event, string source, string category, DateTime? created,
        string subjectIdentifier, string subjectName, int page = 1, int pageSize = 10)
    {
        var pagedList = new PagedList<TAuditLog>();

        var auditLogs = await DbContext.AuditLog
            .WhereIf(!string.IsNullOrEmpty(subjectIdentifier), log => log.SubjectIdentifier.Contains(subjectIdentifier))
            .WhereIf(!string.IsNullOrEmpty(subjectName), log => log.SubjectName.Contains(subjectName))
            .WhereIf(!string.IsNullOrEmpty(@event), log => log.Event.Contains(@event))
            .WhereIf(!string.IsNullOrEmpty(source), log => log.Source.Contains(source))
            .WhereIf(!string.IsNullOrEmpty(category), log => log.Category.Contains(category))
            .WhereIf(created.HasValue, log => log.Created.Date == created.Value.Date)
            .PageBy(x => x.Id, page, pageSize)
            .ToListAsync();

        pagedList.Data.AddRange(auditLogs);
        pagedList.PageSize = pageSize;
        pagedList.TotalCount = await DbContext.AuditLog
            .WhereIf(!string.IsNullOrEmpty(subjectIdentifier), log => log.SubjectIdentifier.Contains(subjectIdentifier))
            .WhereIf(!string.IsNullOrEmpty(subjectName), log => log.SubjectName.Contains(subjectName))
            .WhereIf(!string.IsNullOrEmpty(@event), log => log.Event.Contains(@event))
            .WhereIf(!string.IsNullOrEmpty(source), log => log.Source.Contains(source))
            .WhereIf(!string.IsNullOrEmpty(category), log => log.Category.Contains(category))
            .WhereIf(created.HasValue, log => log.Created.Date == created.Value.Date)
            .CountAsync();

        return pagedList;
    }

    public virtual async Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan)
    {
        var logsToDelete = await DbContext.AuditLog.Where(x => x.Created.Date < deleteOlderThan.Date).ToListAsync();

        if (logsToDelete.Count == 0) return;

        DbContext.AuditLog.RemoveRange(logsToDelete);

        await AutoSaveChangesAsync();
    }

    public bool AutoSaveChanges { get; set; } = true;

    protected virtual async Task<int> AutoSaveChangesAsync() => AutoSaveChanges
        ? await DbContext.SaveChangesAsync()
        : (int)SavedStatus.WillBeSavedExplicitly;

    public virtual async Task<int> SaveAllChangesAsync() => await DbContext.SaveChangesAsync();
}