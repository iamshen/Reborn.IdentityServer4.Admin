using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.Client;

public class ClientAddedEvent : AuditEvent
{
    public ClientAddedEvent(ClientDto client)
    {
        Client = client;
    }

    public ClientDto Client { get; set; }
}