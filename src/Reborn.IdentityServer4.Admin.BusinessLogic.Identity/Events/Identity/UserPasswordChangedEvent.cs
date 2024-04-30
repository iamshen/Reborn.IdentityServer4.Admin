using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class UserPasswordChangedEvent : AuditEvent
{
    public UserPasswordChangedEvent(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; set; }
}