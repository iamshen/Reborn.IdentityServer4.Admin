using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class UserUpdatedEvent<TUserDto> : AuditEvent
{
    public UserUpdatedEvent(TUserDto originalUser, TUserDto user)
    {
        OriginalUser = originalUser;
        User = user;
    }

    public TUserDto OriginalUser { get; set; }
    public TUserDto User { get; set; }
}