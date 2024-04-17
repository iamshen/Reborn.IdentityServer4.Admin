using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.Client;

public class ClientClonedEvent : AuditEvent
{
    public ClientClonedEvent(ClientCloneDto client)
    {
        Client = client;
    }

    public ClientCloneDto Client { get; set; }
}