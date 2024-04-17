using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Grant;
using Reborn.IdentityServer4.Admin.EntityFramework.Entities;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Common;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Mappers;

public static class PersistedGrantMappers
{
    static PersistedGrantMappers()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddProfile<PersistedGrantMapperProfile>())
            .CreateMapper();
    }

    internal static IMapper Mapper { get; }

    public static PersistedGrantsDto ToModel(this PagedList<PersistedGrantDataView> grant)
        => grant == null ? null : Mapper.Map<PersistedGrantsDto>(grant);

    public static PersistedGrantsDto ToModel(this PagedList<PersistedGrant> grant)
        => grant == null ? null : Mapper.Map<PersistedGrantsDto>(grant);

    public static PersistedGrantDto ToModel(this PersistedGrant grant)
        => grant == null ? null : Mapper.Map<PersistedGrantDto>(grant);
}