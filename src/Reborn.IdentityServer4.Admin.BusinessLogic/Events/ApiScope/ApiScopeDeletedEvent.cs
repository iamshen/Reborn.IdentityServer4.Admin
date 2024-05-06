using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiScope;

public class ApiScopeDeletedEvent : AuditEvent
{
    public ApiScopeDeletedEvent(ApiScopeDto apiScope)
    {
        ApiScope = apiScope;
    }

    public ApiScopeDto ApiScope { get; set; }
}