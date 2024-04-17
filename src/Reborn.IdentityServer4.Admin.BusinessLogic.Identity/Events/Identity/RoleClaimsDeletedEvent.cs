using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class RoleClaimsDeletedEvent<TRoleClaimsDto> : AuditEvent
{
    public RoleClaimsDeletedEvent(TRoleClaimsDto roleClaim)
    {
        RoleClaim = roleClaim;
    }

    public TRoleClaimsDto RoleClaim { get; set; }
}