using AutoMapper;
using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Log;
using Reborn.IdentityServer4.Admin.EntityFramework.Entities;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Common;
using Reborn.IdentityServer4.AuditLogging.EntityFramework.Entities;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Mappers;

public static class LogMappers
{
    static LogMappers()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddProfile<LogMapperProfile>())
            .CreateMapper();
    }

    internal static IMapper Mapper { get; }

    public static LogDto ToModel(this Log log) => Mapper.Map<LogDto>(log);

    public static LogsDto ToModel(this PagedList<Log> logs) => Mapper.Map<LogsDto>(logs);

    public static AuditLogsDto ToModel<TAuditLog>(this PagedList<TAuditLog> auditLogs)
        where TAuditLog : AuditLog
        => Mapper.Map<AuditLogsDto>(auditLogs);

    public static AuditLogDto ToModel(this AuditLog auditLog) => Mapper.Map<AuditLogDto>(auditLog);

    public static Log ToEntity(this LogDto log) => Mapper.Map<Log>(log);
}