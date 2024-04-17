using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Helpers;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Resources;

public interface IPersistedGrantAspNetIdentityServiceResources
{
    ResourceMessage PersistedGrantDoesNotExist();

    ResourceMessage PersistedGrantWithSubjectIdDoesNotExist();
}