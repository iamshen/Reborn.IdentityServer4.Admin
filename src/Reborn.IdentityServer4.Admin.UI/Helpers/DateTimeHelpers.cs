using System;

namespace Reborn.IdentityServer4.Admin.UI.Helpers;

public static class DateTimeHelpers
{
    private static readonly DateTime Epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static double GetEpochTicks(this DateTimeOffset dateTime) => dateTime.Subtract(Epoch).TotalMilliseconds;
}