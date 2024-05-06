using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.Client;

public class ClientClaimDeletedEvent : AuditEvent
{
    public ClientClaimDeletedEvent(ClientClaimsDto clientClaim)
    {
        ClientClaim = clientClaim;
    }

    public ClientClaimsDto ClientClaim { get; set; }
}