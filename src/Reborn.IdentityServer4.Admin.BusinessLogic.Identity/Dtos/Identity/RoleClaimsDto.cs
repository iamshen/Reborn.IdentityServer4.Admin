using System.Collections.Generic;
using System.Linq;
using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity;

public class RoleClaimsDto<TRoleClaimDto, TKey> : RoleClaimDto<TKey>, IRoleClaimsDto
    where TRoleClaimDto : RoleClaimDto<TKey>
{
    public RoleClaimsDto()
    {
        Claims = new List<TRoleClaimDto>();
    }

    public List<TRoleClaimDto> Claims { get; set; }

    public string RoleName { get; set; }

    public int TotalCount { get; set; }

    public int PageSize { get; set; }

    List<IRoleClaimDto> IRoleClaimsDto.Claims => Claims.Cast<IRoleClaimDto>().ToList();
}