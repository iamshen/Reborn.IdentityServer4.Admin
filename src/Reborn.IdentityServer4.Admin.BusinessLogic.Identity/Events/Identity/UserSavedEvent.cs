using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class UserSavedEvent<TUserDto> : AuditEvent
{
    public UserSavedEvent(TUserDto user)
    {
        User = user;
    }

    public TUserDto User { get; set; }
}