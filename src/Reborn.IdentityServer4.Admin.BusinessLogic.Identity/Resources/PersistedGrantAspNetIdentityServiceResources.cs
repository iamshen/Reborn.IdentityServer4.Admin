using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Helpers;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Resources;

public class PersistedGrantAspNetIdentityServiceResources : IPersistedGrantAspNetIdentityServiceResources
{
    public virtual ResourceMessage PersistedGrantDoesNotExist() => new()
    {
        Code = nameof(PersistedGrantDoesNotExist),
        Description = PersistedGrantServiceResource.PersistedGrantDoesNotExist
    };

    public virtual ResourceMessage PersistedGrantWithSubjectIdDoesNotExist() => new()
    {
        Code = nameof(PersistedGrantWithSubjectIdDoesNotExist),
        Description = PersistedGrantServiceResource.PersistedGrantWithSubjectIdDoesNotExist
    };
}