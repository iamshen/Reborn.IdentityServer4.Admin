using Reborn.IdentityServer4.Admin.BusinessLogic.Helpers;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Resources;

public class ApiScopeServiceResources : IApiScopeServiceResources
{
    public virtual ResourceMessage ApiScopeDoesNotExist() => new()
    {
        Code = nameof(ApiScopeDoesNotExist),
        Description = ApiScopeServiceResource.ApiScopeDoesNotExist
    };

    public virtual ResourceMessage ApiScopeExistsValue() => new()
    {
        Code = nameof(ApiScopeExistsValue),
        Description = ApiScopeServiceResource.ApiScopeExistsValue
    };

    public virtual ResourceMessage ApiScopeExistsKey() => new()
    {
        Code = nameof(ApiScopeExistsKey),
        Description = ApiScopeServiceResource.ApiScopeExistsKey
    };

    public ResourceMessage ApiScopePropertyExistsValue() => new()
    {
        Code = nameof(ApiScopePropertyExistsValue),
        Description = ApiScopeServiceResource.ApiScopePropertyExistsValue
    };

    public ResourceMessage ApiScopePropertyDoesNotExist() => new()
    {
        Code = nameof(ApiScopePropertyDoesNotExist),
        Description = ApiScopeServiceResource.ApiScopePropertyDoesNotExist
    };

    public ResourceMessage ApiScopePropertyExistsKey() => new()
    {
        Code = nameof(ApiScopePropertyExistsKey),
        Description = ApiScopeServiceResource.ApiScopePropertyExistsKey
    };
}