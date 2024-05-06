using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class UserRoleDeletedEvent<TUserRolesDto> : AuditEvent
{
    public UserRoleDeletedEvent(TUserRolesDto role)
    {
        Role = role;
    }

    public TUserRolesDto Role { get; set; }
}