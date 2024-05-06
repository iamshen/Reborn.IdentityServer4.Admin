using System.Collections.Generic;
using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class AllRolesRequestedEvent<TRoleDto> : AuditEvent
{
    public AllRolesRequestedEvent(List<TRoleDto> roles)
    {
        Roles = roles;
    }

    public List<TRoleDto> Roles { get; set; }
}