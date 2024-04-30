using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.PersistedGrant;

public class PersistedGrantDeletedEvent : AuditEvent
{
    public PersistedGrantDeletedEvent(string persistedGrantKey)
    {
        PersistedGrantKey = persistedGrantKey;
    }

    public string PersistedGrantKey { get; set; }
}