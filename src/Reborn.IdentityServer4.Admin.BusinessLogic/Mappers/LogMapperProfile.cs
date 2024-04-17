using AutoMapper;
using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Log;
using Reborn.IdentityServer4.Admin.EntityFramework.Entities;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Common;
using Reborn.AuditLogging.EntityFramework.Entities;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Mappers;

public class LogMapperProfile : Profile
{
    public LogMapperProfile()
    {
        CreateMap<Log, LogDto>(MemberList.Destination)
            .ReverseMap();

        CreateMap<PagedList<Log>, LogsDto>(MemberList.Destination)
            .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.Data));

        CreateMap<AuditLog, AuditLogDto>(MemberList.Destination)
            .ReverseMap();

        CreateMap<PagedList<AuditLog>, AuditLogsDto>(MemberList.Destination)
            .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.Data));
    }
}