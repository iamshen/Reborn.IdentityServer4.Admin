using System.Collections.Generic;
using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Common;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Mappers;

public static class IdentityResourceMappers
{
    static IdentityResourceMappers()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityResourceMapperProfile>())
            .CreateMapper();
    }

    internal static IMapper Mapper { get; }


    public static IdentityResourceDto ToModel(this IdentityResource resource)
        => resource == null ? null : Mapper.Map<IdentityResourceDto>(resource);

    public static IdentityResourcesDto ToModel(this PagedList<IdentityResource> resource)
        => resource == null ? null : Mapper.Map<IdentityResourcesDto>(resource);

    public static List<IdentityResourceDto> ToModel(this List<IdentityResource> resource)
        => resource == null ? null : Mapper.Map<List<IdentityResourceDto>>(resource);

    public static IdentityResource ToEntity(this IdentityResourceDto resource)
        => resource == null ? null : Mapper.Map<IdentityResource>(resource);

    public static IdentityResourcePropertiesDto
        ToModel(this PagedList<IdentityResourceProperty> identityResourceProperties)
        => Mapper.Map<IdentityResourcePropertiesDto>(identityResourceProperties);

    public static IdentityResourcePropertiesDto ToModel(this IdentityResourceProperty identityResourceProperty)
        => Mapper.Map<IdentityResourcePropertiesDto>(identityResourceProperty);

    public static List<IdentityResource> ToEntity(this List<IdentityResourceDto> resource)
        => resource == null ? null : Mapper.Map<List<IdentityResource>>(resource);

    public static IdentityResourceProperty ToEntity(this IdentityResourcePropertiesDto identityResourceProperties)
        => Mapper.Map<IdentityResourceProperty>(identityResourceProperties);
}