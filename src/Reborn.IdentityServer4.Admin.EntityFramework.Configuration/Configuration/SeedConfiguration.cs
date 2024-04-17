using Microsoft.Extensions.Configuration;

namespace Reborn.IdentityServer4.Admin.EntityFramework.Configuration.Configuration;

public class SeedConfiguration
{
    public bool ApplySeed { get; set; } = false;
}

public static class SeedConfigurationExtensions
{
    public static T GetConfig<T>(this IConfiguration configuration) => configuration.GetSection(nameof(T)).Get<T>();
}