using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.IdentityResource;

public class IdentityResourceAddedEvent : AuditEvent
{
    public IdentityResourceAddedEvent(IdentityResourceDto identityResource)
    {
        IdentityResource = identityResource;
    }

    public IdentityResourceDto IdentityResource { get; set; }
}