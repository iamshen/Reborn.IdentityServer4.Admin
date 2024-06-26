﻿using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Grant;
using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.PersistedGrant;

public class PersistedGrantsByUserRequestedEvent : AuditEvent
{
    public PersistedGrantsByUserRequestedEvent(PersistedGrantsDto persistedGrants)
    {
        PersistedGrants = persistedGrants;
    }

    public PersistedGrantsDto PersistedGrants { get; set; }
}