using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class RoleAddedEvent<TRoleDto> : AuditEvent
{
    public RoleAddedEvent(TRoleDto role)
    {
        Role = role;
    }

    public TRoleDto Role { get; set; }
}