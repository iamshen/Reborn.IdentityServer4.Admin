using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class RoleClaimsSavedEvent<TRoleClaimsDto> : AuditEvent
{
    public RoleClaimsSavedEvent(TRoleClaimsDto claims)
    {
        Claims = claims;
    }

    public TRoleClaimsDto Claims { get; set; }
}