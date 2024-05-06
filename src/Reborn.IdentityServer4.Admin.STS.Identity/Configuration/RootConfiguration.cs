using Reborn.IdentityServer4.Admin.Shared.Configuration.Configuration.Identity;

namespace Reborn.IdentityServer4.Admin.STS.Identity.Configuration;

public class RootConfiguration : IRootConfiguration
{
    public AdminConfiguration AdminConfiguration { get; } = new();
    public RegisterConfiguration RegisterConfiguration { get; } = new();
}