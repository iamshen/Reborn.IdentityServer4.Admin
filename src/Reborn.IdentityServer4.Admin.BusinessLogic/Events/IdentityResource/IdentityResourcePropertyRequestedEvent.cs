using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.IdentityResource;

public class IdentityResourcePropertyRequestedEvent : AuditEvent
{
    public IdentityResourcePropertyRequestedEvent(IdentityResourcePropertiesDto identityResourceProperties)
    {
        IdentityResourceProperties = identityResourceProperties;
    }

    public IdentityResourcePropertiesDto IdentityResourceProperties { get; set; }
}