﻿using Reborn.IdentityServer4.Admin.Shared.Configuration.Configuration.Identity;

namespace SkorubaIdentityServer4Admin.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}







