using System.Collections.Generic;

namespace Reborn.IdentityServer4.Admin.EntityFramework.Configuration.Configuration.Identity;

public class User
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Claim> Claims { get; set; } = new();
    public List<string> Roles { get; set; } = new();
}