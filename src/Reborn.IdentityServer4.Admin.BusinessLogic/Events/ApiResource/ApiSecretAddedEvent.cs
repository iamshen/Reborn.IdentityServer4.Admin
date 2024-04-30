using System;
using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiResource;

public class ApiSecretAddedEvent : AuditEvent
{
    public ApiSecretAddedEvent(int apiResourceId, string type, DateTime? expiration)
    {
        ApiResourceId = apiResourceId;
        Type = type;
        Expiration = expiration;
    }

    public string Type { get; set; }

    public DateTime? Expiration { get; set; }

    public int ApiResourceId { get; set; }
}