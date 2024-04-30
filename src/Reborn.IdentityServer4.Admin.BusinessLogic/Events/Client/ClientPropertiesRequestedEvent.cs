using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.Client;

public class ClientPropertiesRequestedEvent : AuditEvent
{
    public ClientPropertiesRequestedEvent(ClientPropertiesDto clientProperties)
    {
        ClientProperties = clientProperties;
    }

    public ClientPropertiesDto ClientProperties { get; set; }
}