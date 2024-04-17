using Reborn.IdentityServer4.Admin.BusinessLogic.Helpers;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Resources;

public class ApiResourceServiceResources : IApiResourceServiceResources
{
    public virtual ResourceMessage ApiResourceDoesNotExist() => new()
    {
        Code = nameof(ApiResourceDoesNotExist),
        Description = ApiResourceServiceResource.ApiResourceDoesNotExist
    };

    public virtual ResourceMessage ApiResourceExistsValue() => new()
    {
        Code = nameof(ApiResourceExistsValue),
        Description = ApiResourceServiceResource.ApiResourceExistsValue
    };

    public virtual ResourceMessage ApiResourceExistsKey() => new()
    {
        Code = nameof(ApiResourceExistsKey),
        Description = ApiResourceServiceResource.ApiResourceExistsKey
    };

    public virtual ResourceMessage ApiSecretDoesNotExist() => new()
    {
        Code = nameof(ApiSecretDoesNotExist),
        Description = ApiResourceServiceResource.ApiSecretDoesNotExist
    };

    public virtual ResourceMessage ApiResourcePropertyDoesNotExist() => new()
    {
        Code = nameof(ApiResourcePropertyDoesNotExist),
        Description = ApiResourceServiceResource.ApiResourcePropertyDoesNotExist
    };

    public virtual ResourceMessage ApiResourcePropertyExistsKey() => new()
    {
        Code = nameof(ApiResourcePropertyExistsKey),
        Description = ApiResourceServiceResource.ApiResourcePropertyExistsKey
    };

    public virtual ResourceMessage ApiResourcePropertyExistsValue() => new()
    {
        Code = nameof(ApiResourcePropertyExistsValue),
        Description = ApiResourceServiceResource.ApiResourcePropertyExistsValue
    };
}