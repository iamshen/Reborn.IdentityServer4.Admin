using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiScope;

public class ApiScopePropertyAddedEvent : AuditEvent
{
    public ApiScopePropertyAddedEvent(ApiScopePropertiesDto apiScopeProperty)
    {
        ApiScopeProperty = apiScopeProperty;
    }

    public ApiScopePropertiesDto ApiScopeProperty { get; set; }
}