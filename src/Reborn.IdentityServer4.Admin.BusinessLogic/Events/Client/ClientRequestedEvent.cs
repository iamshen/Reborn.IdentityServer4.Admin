using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.Client;

public class ClientRequestedEvent : AuditEvent
{
    public ClientRequestedEvent(ClientDto clientDto)
    {
        ClientDto = clientDto;
    }

    public ClientDto ClientDto { get; set; }
}