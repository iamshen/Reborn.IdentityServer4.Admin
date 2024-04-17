using Reborn.IdentityServer4.Admin.Api.ExceptionHandling;

namespace Reborn.IdentityServer4.Admin.Api.Resources;

public class ApiErrorResources : IApiErrorResources
{
    public virtual ApiError CannotSetId() => new()
    {
        Code = nameof(CannotSetId),
        Description = ApiErrorResource.CannotSetId
    };
}