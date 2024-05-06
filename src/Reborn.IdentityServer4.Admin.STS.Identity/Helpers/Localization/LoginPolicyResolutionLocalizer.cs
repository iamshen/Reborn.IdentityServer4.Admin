using Reborn.IdentityServer4.Admin.Shared.Configuration.Configuration.Identity;

namespace Reborn.IdentityServer4.Admin.STS.Identity.Helpers.Localization;

public static class LoginPolicyResolutionLocalizer
{
    public static string GetUserNameLocalizationKey(LoginResolutionPolicy policy)
    {
        switch (policy)
        {
            case LoginResolutionPolicy.Username:
                return "Username";
            case LoginResolutionPolicy.Email:
                return "Email";
            default:
                return "Username";
        }
    }
}