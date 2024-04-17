using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Grant;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.PersistedGrant;

public class PersistedGrantRequestedEvent : AuditEvent
{
    public PersistedGrantRequestedEvent(PersistedGrantDto persistedGrant)
    {
        PersistedGrant = persistedGrant;
    }

    public PersistedGrantDto PersistedGrant { get; set; }
}