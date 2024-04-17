using Reborn.IdentityServer4.Admin.BusinessLogic.Helpers;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Resources;

public interface IIdentityResourceServiceResources
{
    ResourceMessage IdentityResourceDoesNotExist();

    ResourceMessage IdentityResourceExistsKey();

    ResourceMessage IdentityResourceExistsValue();

    ResourceMessage IdentityResourcePropertyDoesNotExist();

    ResourceMessage IdentityResourcePropertyExistsValue();

    ResourceMessage IdentityResourcePropertyExistsKey();
}