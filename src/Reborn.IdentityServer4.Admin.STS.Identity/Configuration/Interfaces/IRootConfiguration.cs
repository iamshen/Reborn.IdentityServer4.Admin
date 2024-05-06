using Reborn.IdentityServer4.Admin.Shared.Configuration.Configuration.Identity;

namespace Reborn.IdentityServer4.Admin.STS.Identity.Configuration.Interfaces;

public interface IRootConfiguration
{
    AdminConfiguration AdminConfiguration { get; }

    RegisterConfiguration RegisterConfiguration { get; }
}