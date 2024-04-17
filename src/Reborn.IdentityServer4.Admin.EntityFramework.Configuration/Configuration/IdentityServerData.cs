using System.Collections.Generic;
using IdentityServer4.Models;
using Client = Reborn.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.IdentityServer.Client;

namespace Reborn.IdentityServer4.Admin.EntityFramework.Configuration.Configuration;

public class IdentityServerData
{
    public List<Client> Clients { get; set; } = new();
    public List<IdentityResource> IdentityResources { get; set; } = new();
    public List<ApiResource> ApiResources { get; set; } = new();
    public List<ApiScope> ApiScopes { get; set; } = new();
}