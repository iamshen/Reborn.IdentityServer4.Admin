using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiScope;

public class ApiScopeAddedEvent : AuditEvent
{
    public ApiScopeAddedEvent(ApiScopeDto apiScope)
    {
        ApiScope = apiScope;
    }

    public ApiScopeDto ApiScope { get; set; }
}