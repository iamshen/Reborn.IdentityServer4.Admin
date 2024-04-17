using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Grant;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.PersistedGrant;

public class PersistedGrantIdentityRequestedEvent : AuditEvent
{
    public PersistedGrantIdentityRequestedEvent(PersistedGrantDto persistedGrant)
    {
        PersistedGrant = persistedGrant;
    }

    public PersistedGrantDto PersistedGrant { get; set; }
}