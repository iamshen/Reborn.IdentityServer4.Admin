using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiResource;

public class ApiResourceAddedEvent : AuditEvent
{
    public ApiResourceAddedEvent(ApiResourceDto apiResource)
    {
        ApiResource = apiResource;
    }

    public ApiResourceDto ApiResource { get; set; }
}