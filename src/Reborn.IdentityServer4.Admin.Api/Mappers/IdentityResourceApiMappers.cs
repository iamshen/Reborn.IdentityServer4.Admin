using AutoMapper;

namespace Reborn.IdentityServer4.Admin.Api.Mappers;

public static class IdentityResourceApiMappers
{
    static IdentityResourceApiMappers()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityResourceApiMapperProfile>())
            .CreateMapper();
    }

    internal static IMapper Mapper { get; }

    public static T ToIdentityResourceApiModel<T>(this object source) => Mapper.Map<T>(source);
}