using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity;

public class UserProvidersRequestedEvent<TUserProvidersDto> : AuditEvent
{
    public UserProvidersRequestedEvent(TUserProvidersDto providers)
    {
        Providers = providers;
    }

    public TUserProvidersDto Providers { get; set; }
}