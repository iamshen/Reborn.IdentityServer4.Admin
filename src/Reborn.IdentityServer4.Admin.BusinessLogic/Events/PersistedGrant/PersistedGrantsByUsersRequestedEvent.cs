using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Grant;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.PersistedGrant;

public class PersistedGrantsByUsersRequestedEvent : AuditEvent
{
    public PersistedGrantsByUsersRequestedEvent(PersistedGrantsDto persistedGrants)
    {
        PersistedGrants = persistedGrants;
    }

    public PersistedGrantsDto PersistedGrants { get; set; }
}