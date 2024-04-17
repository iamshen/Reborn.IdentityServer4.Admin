﻿using Reborn.IdentityServer4.Admin.BusinessLogic.Helpers;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Resources;

public interface IClientServiceResources
{
    ResourceMessage ClientClaimDoesNotExist();

    ResourceMessage ClientDoesNotExist();

    ResourceMessage ClientExistsKey();

    ResourceMessage ClientExistsValue();

    ResourceMessage ClientPropertyDoesNotExist();

    ResourceMessage ClientSecretDoesNotExist();
}