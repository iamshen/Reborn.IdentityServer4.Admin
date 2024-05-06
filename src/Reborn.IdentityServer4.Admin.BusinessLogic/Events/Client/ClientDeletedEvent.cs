using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.Client;

public class ClientDeletedEvent : AuditEvent
{
    public ClientDeletedEvent(ClientDto client)
    {
        Client = client;
    }

    public ClientDto Client { get; set; }
}