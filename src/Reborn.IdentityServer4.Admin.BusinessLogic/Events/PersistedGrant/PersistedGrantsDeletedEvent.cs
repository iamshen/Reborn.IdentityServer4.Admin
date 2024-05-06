using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.PersistedGrant;

public class PersistedGrantsDeletedEvent : AuditEvent
{
    public PersistedGrantsDeletedEvent(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; set; }
}