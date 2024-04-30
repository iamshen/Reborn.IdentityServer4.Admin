using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiResource;

public class ApiResourcePropertiesRequestedEvent : AuditEvent
{
    public ApiResourcePropertiesRequestedEvent(int apiResourceId, ApiResourcePropertiesDto apiResourceProperties)
    {
        ApiResourceId = apiResourceId;
        ApiResourceProperties = apiResourceProperties;
    }

    public int ApiResourceId { get; set; }
    public ApiResourcePropertiesDto ApiResourceProperties { get; }
}