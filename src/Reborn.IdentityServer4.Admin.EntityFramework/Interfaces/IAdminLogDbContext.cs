using Microsoft.EntityFrameworkCore;
using Reborn.IdentityServer4.Admin.EntityFramework.Entities;

namespace Reborn.IdentityServer4.Admin.EntityFramework.Interfaces;

public interface IAdminLogDbContext
{
    DbSet<Log> Logs { get; set; }
}