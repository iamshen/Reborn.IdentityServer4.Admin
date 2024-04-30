using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class ClaimUsersRequestedEvent<TUsersDto> : AuditEvent
{
    public ClaimUsersRequestedEvent(TUsersDto users)
    {
        Users = users;
    }

    public TUsersDto Users { get; set; }
}