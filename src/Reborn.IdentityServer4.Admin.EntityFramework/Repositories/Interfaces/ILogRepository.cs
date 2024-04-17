using System;
using System.Threading.Tasks;
using Reborn.IdentityServer4.Admin.EntityFramework.Entities;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Common;

namespace Reborn.IdentityServer4.Admin.EntityFramework.Repositories.Interfaces;

public interface ILogRepository
{
    bool AutoSaveChanges { get; set; }
    Task<PagedList<Log>> GetLogsAsync(string search, int page = 1, int pageSize = 10);

    Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
}