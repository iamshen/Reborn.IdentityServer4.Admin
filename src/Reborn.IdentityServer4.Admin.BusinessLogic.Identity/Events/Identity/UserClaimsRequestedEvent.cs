using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class UserClaimsRequestedEvent<TUserClaimsDto> : AuditEvent
{
    public UserClaimsRequestedEvent(TUserClaimsDto claims)
    {
        Claims = claims;
    }

    public TUserClaimsDto Claims { get; set; }
}