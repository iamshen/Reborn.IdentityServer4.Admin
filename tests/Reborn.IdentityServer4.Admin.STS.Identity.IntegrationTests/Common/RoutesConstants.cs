using System.Collections.Generic;

namespace Reborn.IdentityServer4.Admin.STS.Identity.IntegrationTests.Common;

public static class RoutesConstants
{
    public static List<string> GetManageRoutes()
    {
        var manageRoutes = new List<string>
        {
            "Index",
            "ChangePassword",
            "PersonalData",
            "DeletePersonalData",
            "ExternalLogins",
            "TwoFactorAuthentication",
            "ResetAuthenticatorWarning",
            "EnableAuthenticator"
        };

        return manageRoutes;
    }
}