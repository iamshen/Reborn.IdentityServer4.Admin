namespace Reborn.IdentityServer4.Admin.Shared.Configuration.Configuration.Identity;

public class LoginConfiguration
{
    public LoginResolutionPolicy ResolutionPolicy { get; set; } = LoginResolutionPolicy.Username;
}