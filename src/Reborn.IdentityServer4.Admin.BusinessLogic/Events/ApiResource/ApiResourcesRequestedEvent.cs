using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiResource;

public class ApiResourcesRequestedEvent : AuditEvent
{
    public ApiResourcesRequestedEvent(ApiResourcesDto apiResources)
    {
        ApiResources = apiResources;
    }

    public ApiResourcesDto ApiResources { get; set; }
}