using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class UserClaimRequestedEvent<TUserClaimsDto> : AuditEvent
{
    public UserClaimRequestedEvent(TUserClaimsDto userClaims)
    {
        UserClaims = userClaims;
    }

    public TUserClaimsDto UserClaims { get; set; }
}