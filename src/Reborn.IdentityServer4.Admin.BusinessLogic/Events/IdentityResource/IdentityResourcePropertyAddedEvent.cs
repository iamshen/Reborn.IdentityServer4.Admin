using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.IdentityResource;

public class IdentityResourcePropertyAddedEvent : AuditEvent
{
    public IdentityResourcePropertyAddedEvent(IdentityResourcePropertiesDto identityResourceProperty)
    {
        IdentityResourceProperty = identityResourceProperty;
    }

    public IdentityResourcePropertiesDto IdentityResourceProperty { get; set; }
}