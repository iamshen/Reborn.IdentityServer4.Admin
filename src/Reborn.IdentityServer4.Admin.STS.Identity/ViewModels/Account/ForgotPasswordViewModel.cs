using System.ComponentModel.DataAnnotations;
using Reborn.IdentityServer4.Admin.Shared.Configuration.Configuration.Identity;

namespace Reborn.IdentityServer4.Admin.STS.Identity.ViewModels.Account;

public class ForgotPasswordViewModel
{
    [Required] public LoginResolutionPolicy? Policy { get; set; }

    [EmailAddress] public string Email { get; set; }

    public string Username { get; set; }
}