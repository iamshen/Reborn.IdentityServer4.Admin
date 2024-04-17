using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.PersistedGrant;

public class PersistedGrantsIdentityDeletedEvent : AuditEvent
{
    public PersistedGrantsIdentityDeletedEvent(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; set; }
}