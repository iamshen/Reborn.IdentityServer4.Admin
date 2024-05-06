using System;
using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiResource;

public class ApiSecretRequestedEvent : AuditEvent
{
    public ApiSecretRequestedEvent(int apiResourceId, int apiSecretId, string type, DateTime? expiration)
    {
        ApiResourceId = apiResourceId;
        ApiSecretId = apiSecretId;
        Type = type;
        Expiration = expiration;
    }

    public int ApiResourceId { get; set; }

    public int ApiSecretId { get; set; }

    public string Type { get; set; }

    public DateTime? Expiration { get; set; }
}