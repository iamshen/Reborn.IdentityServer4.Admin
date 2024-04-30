using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class UserClaimsSavedEvent<TUserClaimsDto> : AuditEvent
{
    public UserClaimsSavedEvent(TUserClaimsDto claims)
    {
        Claims = claims;
    }

    public TUserClaimsDto Claims { get; set; }
}