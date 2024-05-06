using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class UserDeletedEvent<TUserDto> : AuditEvent
{
    public UserDeletedEvent(TUserDto user)
    {
        User = user;
    }

    public TUserDto User { get; set; }
}