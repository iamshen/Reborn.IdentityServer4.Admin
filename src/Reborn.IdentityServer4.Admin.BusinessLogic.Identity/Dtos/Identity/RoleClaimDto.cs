﻿using System.ComponentModel.DataAnnotations;
using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity;

public class RoleClaimDto<TKey> : BaseRoleClaimDto<TKey>, IRoleClaimDto
{
    [Required] public string ClaimType { get; set; }


    [Required] public string ClaimValue { get; set; }
}