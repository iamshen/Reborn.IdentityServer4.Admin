using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.IdentityResource;

public class IdentityResourceUpdatedEvent : AuditEvent
{
    public IdentityResourceUpdatedEvent(IdentityResourceDto originalIdentityResource,
        IdentityResourceDto identityResource)
    {
        OriginalIdentityResource = originalIdentityResource;
        IdentityResource = identityResource;
    }

    public IdentityResourceDto OriginalIdentityResource { get; set; }
    public IdentityResourceDto IdentityResource { get; set; }
}