using AutoMapper;

namespace Reborn.IdentityServer4.Admin.Api.Mappers;

public static class ApiScopeApiMappers
{
    static ApiScopeApiMappers()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiScopeApiMapperProfile>())
            .CreateMapper();
    }

    internal static IMapper Mapper { get; }

    public static T ToApiScopeApiModel<T>(this object source) => Mapper.Map<T>(source);
}