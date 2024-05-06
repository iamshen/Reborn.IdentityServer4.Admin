using System;
using System.Threading.Tasks;
using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Log;
using Reborn.IdentityServer4.Admin.BusinessLogic.Mappers;
using Reborn.IdentityServer4.Admin.BusinessLogic.Services.Interfaces;
using Reborn.IdentityServer4.Admin.EntityFramework.Repositories.Interfaces;
using Reborn.IdentityServer4.Admin.AuditLogging.EntityFramework.Entities;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Services;

public class AuditLogService<TAuditLog> : IAuditLogService
    where TAuditLog : AuditLog
{
    protected readonly IAuditLogRepository<TAuditLog> AuditLogRepository;

    public AuditLogService(IAuditLogRepository<TAuditLog> auditLogRepository)
    {
        AuditLogRepository = auditLogRepository;
    }

    public async Task<AuditLogsDto> GetAsync(AuditLogFilterDto filters)
    {
        var pagedList = await AuditLogRepository.GetAsync(filters.Event, filters.Source, filters.Category,
            filters.Created, filters.SubjectIdentifier, filters.SubjectName, filters.Page, filters.PageSize);
        var auditLogsDto = pagedList.ToModel();

        return auditLogsDto;
    }

    public virtual async Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan)
    {
        await AuditLogRepository.DeleteLogsOlderThanAsync(deleteOlderThan);
    }
}