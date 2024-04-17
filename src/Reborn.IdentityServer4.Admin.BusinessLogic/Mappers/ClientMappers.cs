using System.Collections.Generic;
using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.Admin.BusinessLogic.Shared.Dtos.Common;
using Reborn.IdentityServer4.Admin.EntityFramework.Extensions.Common;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Mappers;

public static class ClientMappers
{
    static ClientMappers()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientMapperProfile>())
            .CreateMapper();
    }

    internal static IMapper Mapper { get; }

    public static ClientDto ToModel(this Client client) => Mapper.Map<ClientDto>(client);

    public static ClientSecretsDto ToModel(this PagedList<ClientSecret> clientSecret)
        => Mapper.Map<ClientSecretsDto>(clientSecret);

    public static ClientClaimsDto ToModel(this PagedList<ClientClaim> clientClaims)
        => Mapper.Map<ClientClaimsDto>(clientClaims);

    public static ClientsDto ToModel(this PagedList<Client> clients) => Mapper.Map<ClientsDto>(clients);

    public static ClientPropertiesDto ToModel(this PagedList<ClientProperty> clientProperties)
        => Mapper.Map<ClientPropertiesDto>(clientProperties);

    public static Client ToEntity(this ClientDto client) => Mapper.Map<Client>(client);

    public static ClientSecretsDto ToModel(this ClientSecret clientSecret)
        => Mapper.Map<ClientSecretsDto>(clientSecret);

    public static ClientSecret ToEntity(this ClientSecretsDto clientSecret) => Mapper.Map<ClientSecret>(clientSecret);

    public static ClientClaimsDto ToModel(this ClientClaim clientClaim) => Mapper.Map<ClientClaimsDto>(clientClaim);

    public static ClientPropertiesDto ToModel(this ClientProperty clientProperty)
        => Mapper.Map<ClientPropertiesDto>(clientProperty);

    public static ClientClaim ToEntity(this ClientClaimsDto clientClaim) => Mapper.Map<ClientClaim>(clientClaim);

    public static ClientProperty ToEntity(this ClientPropertiesDto clientProperties)
        => Mapper.Map<ClientProperty>(clientProperties);

    public static SelectItemDto ToModel(this SelectItem selectItem) => Mapper.Map<SelectItemDto>(selectItem);

    public static List<SelectItemDto> ToModel(this List<SelectItem> selectItem)
        => Mapper.Map<List<SelectItemDto>>(selectItem);
}