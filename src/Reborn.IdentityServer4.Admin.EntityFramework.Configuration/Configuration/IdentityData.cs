using System.Collections.Generic;
using Reborn.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.Identity;

namespace Reborn.IdentityServer4.Admin.EntityFramework.Configuration.Configuration;

public class IdentityData
{
    public List<Role> Roles { get; set; }
    public List<User> Users { get; set; }
}