using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class UserProviderRequestedEvent<TUserProviderDto> : AuditEvent
{
    public UserProviderRequestedEvent(TUserProviderDto provider)
    {
        Provider = provider;
    }

    public TUserProviderDto Provider { get; set; }
}