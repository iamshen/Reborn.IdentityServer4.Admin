using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.Client;

public class ClientPropertyDeletedEvent : AuditEvent
{
    public ClientPropertyDeletedEvent(ClientPropertiesDto clientProperty)
    {
        ClientProperty = clientProperty;
    }

    public ClientPropertiesDto ClientProperty { get; set; }
}