using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiScope;

public class ApiScopesRequestedEvent : AuditEvent
{
    public ApiScopesRequestedEvent(ApiScopesDto apiScope)
    {
        ApiScope = apiScope;
    }

    public ApiScopesDto ApiScope { get; set; }
}