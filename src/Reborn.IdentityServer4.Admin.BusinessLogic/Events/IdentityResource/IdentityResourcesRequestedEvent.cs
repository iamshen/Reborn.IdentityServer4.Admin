using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.IdentityResource;

public class IdentityResourcesRequestedEvent : AuditEvent
{
    public IdentityResourcesRequestedEvent(IdentityResourcesDto identityResources)
    {
        IdentityResources = identityResources;
    }

    public IdentityResourcesDto IdentityResources { get; }
}