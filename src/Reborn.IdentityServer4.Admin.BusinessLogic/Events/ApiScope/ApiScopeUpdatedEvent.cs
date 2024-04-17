using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiScope;

public class ApiScopeUpdatedEvent : AuditEvent
{
    public ApiScopeUpdatedEvent(ApiScopeDto originalApiScope, ApiScopeDto apiScope)
    {
        OriginalApiScope = originalApiScope;
        ApiScope = apiScope;
    }

    public ApiScopeDto OriginalApiScope { get; set; }
    public ApiScopeDto ApiScope { get; set; }
}