using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiResource;

public class ApiResourcePropertyDeletedEvent : AuditEvent
{
    public ApiResourcePropertyDeletedEvent(ApiResourcePropertiesDto apiResourceProperty)
    {
        ApiResourceProperty = apiResourceProperty;
    }

    public ApiResourcePropertiesDto ApiResourceProperty { get; set; }
}