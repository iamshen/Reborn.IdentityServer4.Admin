using System.Collections.Generic;

namespace Reborn.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.Identity;

public class Role
{
    public string Name { get; set; }
    public List<Claim> Claims { get; set; } = new();
}