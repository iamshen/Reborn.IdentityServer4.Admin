using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiResource;

public class ApiResourceUpdatedEvent : AuditEvent
{
    public ApiResourceUpdatedEvent(ApiResourceDto originalApiResource, ApiResourceDto apiResource)
    {
        OriginalApiResource = originalApiResource;
        ApiResource = apiResource;
    }

    public ApiResourceDto OriginalApiResource { get; set; }
    public ApiResourceDto ApiResource { get; set; }
}