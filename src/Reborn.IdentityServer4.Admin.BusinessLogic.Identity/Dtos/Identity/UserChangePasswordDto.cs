using System.ComponentModel.DataAnnotations;
using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity;

public class UserChangePasswordDto<TKey> : BaseUserChangePasswordDto<TKey>, IUserChangePasswordDto
{
    public string UserName { get; set; }

    [Required] public string Password { get; set; }

    [Required] [Compare(nameof(Password))] public string ConfirmPassword { get; set; }
}