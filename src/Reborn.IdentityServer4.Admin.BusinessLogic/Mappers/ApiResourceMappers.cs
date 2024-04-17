using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Common;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Mappers;

public static class ApiResourceMappers
{
    static ApiResourceMappers()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceMapperProfile>())
            .CreateMapper();
    }

    internal static IMapper Mapper { get; }

    public static ApiResourceDto ToModel(this ApiResource resource)
        => resource == null ? null : Mapper.Map<ApiResourceDto>(resource);

    public static ApiResourcesDto ToModel(this PagedList<ApiResource> resources)
        => resources == null ? null : Mapper.Map<ApiResourcesDto>(resources);

    public static ApiResourcePropertiesDto ToModel(this PagedList<ApiResourceProperty> apiResourceProperties)
        => Mapper.Map<ApiResourcePropertiesDto>(apiResourceProperties);

    public static ApiResourcePropertiesDto ToModel(this ApiResourceProperty apiResourceProperty)
        => Mapper.Map<ApiResourcePropertiesDto>(apiResourceProperty);

    public static ApiSecretsDto ToModel(this PagedList<ApiResourceSecret> secrets)
        => secrets == null ? null : Mapper.Map<ApiSecretsDto>(secrets);

    public static ApiSecretsDto ToModel(this ApiResourceSecret resource)
        => resource == null ? null : Mapper.Map<ApiSecretsDto>(resource);

    public static ApiResource ToEntity(this ApiResourceDto resource)
        => resource == null ? null : Mapper.Map<ApiResource>(resource);

    public static ApiResourceSecret ToEntity(this ApiSecretsDto resource)
        => resource == null ? null : Mapper.Map<ApiResourceSecret>(resource);

    public static ApiResourceProperty ToEntity(this ApiResourcePropertiesDto apiResourceProperties)
        => Mapper.Map<ApiResourceProperty>(apiResourceProperties);
}