using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reborn.IdentityServer4.Admin.EntityFramework.Entities;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Common;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Enums;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Extensions;
using Reborn.IdentityServer4.Admin.EntityFramework.Interfaces;
using Reborn.IdentityServer4.Admin.EntityFramework.Repositories.Interfaces;

namespace Reborn.IdentityServer4.Admin.EntityFramework.Repositories;

public class LogRepository<TDbContext> : ILogRepository
    where TDbContext : DbContext, IAdminLogDbContext
{
    protected readonly TDbContext DbContext;

    public LogRepository(TDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual async Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan)
    {
        var logsToDelete = await DbContext.Logs.Where(x => x.TimeStamp < deleteOlderThan.Date).ToListAsync();

        if (logsToDelete.Count == 0) return;

        DbContext.Logs.RemoveRange(logsToDelete);

        await AutoSaveChangesAsync();
    }

    public virtual async Task<PagedList<Log>> GetLogsAsync(string search, int page = 1, int pageSize = 10)
    {
        var pagedList = new PagedList<Log>();
        Expression<Func<Log, bool>> searchCondition = x
            => x.LogEvent.Contains(search) || x.Message.Contains(search) || x.Exception.Contains(search);
        var logs = await DbContext.Logs
            .WhereIf(!string.IsNullOrEmpty(search), searchCondition)
            .PageBy(x => x.Id, page, pageSize)
            .ToListAsync();

        pagedList.Data.AddRange(logs);
        pagedList.PageSize = pageSize;
        pagedList.TotalCount =
            await DbContext.Logs.WhereIf(!string.IsNullOrEmpty(search), searchCondition).CountAsync();

        return pagedList;
    }

    public bool AutoSaveChanges { get; set; } = true;

    protected virtual async Task<int> AutoSaveChangesAsync() => AutoSaveChanges
        ? await DbContext.SaveChangesAsync()
        : (int)SavedStatus.WillBeSavedExplicitly;

    public virtual async Task<int> SaveAllChangesAsync() => await DbContext.SaveChangesAsync();
}