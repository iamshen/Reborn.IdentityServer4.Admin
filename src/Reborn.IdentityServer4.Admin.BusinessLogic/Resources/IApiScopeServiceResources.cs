using Reborn.IdentityServer4.Admin.BusinessLogic.Helpers;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Resources;

public interface IApiScopeServiceResources
{
    ResourceMessage ApiScopeDoesNotExist();
    ResourceMessage ApiScopeExistsValue();
    ResourceMessage ApiScopeExistsKey();
    ResourceMessage ApiScopePropertyExistsValue();
    ResourceMessage ApiScopePropertyDoesNotExist();
    ResourceMessage ApiScopePropertyExistsKey();
}