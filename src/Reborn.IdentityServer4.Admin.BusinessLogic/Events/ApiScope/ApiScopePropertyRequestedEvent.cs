using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiScope;

public class ApiScopePropertyRequestedEvent : AuditEvent
{
    public ApiScopePropertyRequestedEvent(int apiScopePropertyId, ApiScopePropertiesDto apiScopeProperty)
    {
        ApiScopePropertyId = apiScopePropertyId;
        ApiScopeProperty = apiScopeProperty;
    }

    public int ApiScopePropertyId { get; set; }

    public ApiScopePropertiesDto ApiScopeProperty { get; set; }
}