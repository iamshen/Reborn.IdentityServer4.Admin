using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.Client;

public class ClientSecretDeletedEvent : AuditEvent
{
    public ClientSecretDeletedEvent(int clientId, int clientSecretId)
    {
        ClientId = clientId;
        ClientSecretId = clientSecretId;
    }

    public int ClientId { get; set; }

    public int ClientSecretId { get; set; }
}