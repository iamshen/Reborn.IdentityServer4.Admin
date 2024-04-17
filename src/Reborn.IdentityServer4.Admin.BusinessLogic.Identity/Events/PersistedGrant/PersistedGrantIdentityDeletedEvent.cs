using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.PersistedGrant;

public class PersistedGrantIdentityDeletedEvent : AuditEvent
{
    public PersistedGrantIdentityDeletedEvent(string key)
    {
        Key = key;
    }

    public string Key { get; set; }
}