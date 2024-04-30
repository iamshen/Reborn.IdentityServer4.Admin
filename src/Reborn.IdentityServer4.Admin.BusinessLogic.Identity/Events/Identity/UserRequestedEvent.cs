using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class UserRequestedEvent<TUserDto> : AuditEvent
{
    public UserRequestedEvent(TUserDto userDto)
    {
        UserDto = userDto;
    }

    public TUserDto UserDto { get; set; }
}