using Reborn.IdentityServer4.Admin.BusinessLogic.Helpers;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Resources;

public class IdentityResourceServiceResources : IIdentityResourceServiceResources
{
    public virtual ResourceMessage IdentityResourceDoesNotExist() => new()
    {
        Code = nameof(IdentityResourceDoesNotExist),
        Description = IdentityResourceServiceResource.IdentityResourceDoesNotExist
    };

    public virtual ResourceMessage IdentityResourceExistsKey() => new()
    {
        Code = nameof(IdentityResourceExistsKey),
        Description = IdentityResourceServiceResource.IdentityResourceExistsKey
    };

    public virtual ResourceMessage IdentityResourceExistsValue() => new()
    {
        Code = nameof(IdentityResourceExistsValue),
        Description = IdentityResourceServiceResource.IdentityResourceExistsValue
    };

    public virtual ResourceMessage IdentityResourcePropertyDoesNotExist() => new()
    {
        Code = nameof(IdentityResourcePropertyDoesNotExist),
        Description = IdentityResourceServiceResource.IdentityResourcePropertyDoesNotExist
    };

    public virtual ResourceMessage IdentityResourcePropertyExistsValue() => new()
    {
        Code = nameof(IdentityResourcePropertyExistsValue),
        Description = IdentityResourceServiceResource.IdentityResourcePropertyExistsValue
    };

    public virtual ResourceMessage IdentityResourcePropertyExistsKey() => new()
    {
        Code = nameof(IdentityResourcePropertyExistsKey),
        Description = IdentityResourceServiceResource.IdentityResourcePropertyExistsKey
    };
}