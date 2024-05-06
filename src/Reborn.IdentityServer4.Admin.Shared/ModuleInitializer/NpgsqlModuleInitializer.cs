using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Reborn.IdentityServer4.Admin.Shared.ModuleInitializer;

#pragma warning disable CA2255

public static class NpgsqlModuleInitializer
{
    [ModuleInitializer]
    public static void EnableLegacyTimestampBehavior()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}
#pragma warning restore CA2255
