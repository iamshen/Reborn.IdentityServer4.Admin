using System.ComponentModel.DataAnnotations;
using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity;

public class RoleDto<TKey> : BaseRoleDto<TKey>, IRoleDto
{
    [Required] public string Name { get; set; }
}