using System;
using System.Threading.Tasks;
using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Log;
using Reborn.IdentityServer4.Admin.BusinessLogic.Events.Log;
using Reborn.IdentityServer4.Admin.BusinessLogic.Mappers;
using Reborn.IdentityServer4.Admin.BusinessLogic.Services.Interfaces;
using Reborn.IdentityServer4.Admin.EntityFramework.Repositories.Interfaces;
using Reborn.AuditLogging.Services;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Services;

public class LogService : ILogService
{
    protected readonly IAuditEventLogger AuditEventLogger;
    protected readonly ILogRepository Repository;

    public LogService(ILogRepository repository, IAuditEventLogger auditEventLogger)
    {
        Repository = repository;
        AuditEventLogger = auditEventLogger;
    }

    public virtual async Task<LogsDto> GetLogsAsync(string search, int page = 1, int pageSize = 10)
    {
        var pagedList = await Repository.GetLogsAsync(search, page, pageSize);
        var logs = pagedList.ToModel();

        await AuditEventLogger.LogEventAsync(new LogsRequestedEvent());

        return logs;
    }

    public virtual async Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan)
    {
        await Repository.DeleteLogsOlderThanAsync(deleteOlderThan);

        await AuditEventLogger.LogEventAsync(new LogsDeletedEvent(deleteOlderThan));
    }
}