using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class UserRolesRequestedEvent<TUserRolesDto> : AuditEvent
{
    public UserRolesRequestedEvent(TUserRolesDto roles)
    {
        Roles = roles;
    }

    public TUserRolesDto Roles { get; set; }
}