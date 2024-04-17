using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiScope;

public class ApiScopePropertiesRequestedEvent : AuditEvent
{
    public ApiScopePropertiesRequestedEvent(int apiScopeId, ApiScopePropertiesDto apiScopeProperties)
    {
        ApiScopeId = apiScopeId;
        ApiResourceProperties = apiScopeProperties;
    }

    public int ApiScopeId { get; set; }
    public ApiScopePropertiesDto ApiResourceProperties { get; }
}