using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Grant;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.PersistedGrant;

public class PersistedGrantsIdentityByUserRequestedEvent : AuditEvent
{
    public PersistedGrantsIdentityByUserRequestedEvent(PersistedGrantsDto persistedGrants)
    {
        PersistedGrants = persistedGrants;
    }

    public PersistedGrantsDto PersistedGrants { get; set; }
}