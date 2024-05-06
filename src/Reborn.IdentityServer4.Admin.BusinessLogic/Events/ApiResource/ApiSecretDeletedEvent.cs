using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiResource;

public class ApiSecretDeletedEvent : AuditEvent
{
    public ApiSecretDeletedEvent(int apiResourceId, int apiSecretId)
    {
        ApiResourceId = apiResourceId;
        ApiSecretId = apiSecretId;
    }

    public int ApiResourceId { get; set; }

    public int ApiSecretId { get; set; }
}