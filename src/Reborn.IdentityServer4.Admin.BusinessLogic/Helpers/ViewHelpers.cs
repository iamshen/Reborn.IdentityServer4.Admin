namespace Reborn.IdentityServer4.Admin.BusinessLogic.Helpers;

public static class ViewHelpers
{
    public static string GetClientName(string clientId, string clientName) => $"{clientId} ({clientName})";
}