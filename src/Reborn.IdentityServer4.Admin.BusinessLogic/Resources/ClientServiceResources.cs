using Reborn.IdentityServer4.Admin.BusinessLogic.Helpers;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Resources;

public class ClientServiceResources : IClientServiceResources
{
    public virtual ResourceMessage ClientClaimDoesNotExist() => new()
    {
        Code = nameof(ClientClaimDoesNotExist),
        Description = ClientServiceResource.ClientClaimDoesNotExist
    };

    public virtual ResourceMessage ClientDoesNotExist() => new()
    {
        Code = nameof(ClientDoesNotExist),
        Description = ClientServiceResource.ClientDoesNotExist
    };

    public virtual ResourceMessage ClientExistsKey() => new()
    {
        Code = nameof(ClientExistsKey),
        Description = ClientServiceResource.ClientExistsKey
    };

    public virtual ResourceMessage ClientExistsValue() => new()
    {
        Code = nameof(ClientExistsValue),
        Description = ClientServiceResource.ClientExistsValue
    };

    public virtual ResourceMessage ClientPropertyDoesNotExist() => new()
    {
        Code = nameof(ClientPropertyDoesNotExist),
        Description = ClientServiceResource.ClientPropertyDoesNotExist
    };

    public virtual ResourceMessage ClientSecretDoesNotExist() => new()
    {
        Code = nameof(ClientSecretDoesNotExist),
        Description = ClientServiceResource.ClientSecretDoesNotExist
    };
}