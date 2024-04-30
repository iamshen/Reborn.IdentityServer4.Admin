using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class RoleClaimRequestedEvent<TRoleClaimsDto> : AuditEvent
{
    public RoleClaimRequestedEvent(TRoleClaimsDto roleClaim)
    {
        RoleClaim = roleClaim;
    }

    public TRoleClaimsDto RoleClaim { get; set; }
}