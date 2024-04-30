using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.Client;

public class ClientsRequestedEvent : AuditEvent
{
    public ClientsRequestedEvent(ClientsDto clientsDto)
    {
        ClientsDto = clientsDto;
    }

    public ClientsDto ClientsDto { get; set; }
}