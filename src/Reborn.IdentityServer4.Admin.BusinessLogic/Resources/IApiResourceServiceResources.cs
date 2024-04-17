using Reborn.IdentityServer4.Admin.BusinessLogic.Helpers;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Resources;

public interface IApiResourceServiceResources
{
    ResourceMessage ApiResourceDoesNotExist();
    ResourceMessage ApiResourceExistsValue();
    ResourceMessage ApiResourceExistsKey();
    ResourceMessage ApiSecretDoesNotExist();
    ResourceMessage ApiResourcePropertyDoesNotExist();
    ResourceMessage ApiResourcePropertyExistsKey();
    ResourceMessage ApiResourcePropertyExistsValue();
}