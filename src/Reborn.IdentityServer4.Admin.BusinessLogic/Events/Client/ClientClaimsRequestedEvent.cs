using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.Client;

public class ClientClaimsRequestedEvent : AuditEvent
{
    public ClientClaimsRequestedEvent(ClientClaimsDto clientClaims)
    {
        ClientClaims = clientClaims;
    }

    public ClientClaimsDto ClientClaims { get; set; }
}