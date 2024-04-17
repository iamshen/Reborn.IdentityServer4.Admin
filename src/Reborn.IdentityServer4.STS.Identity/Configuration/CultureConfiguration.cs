using System.Collections.Generic;

namespace Reborn.IdentityServer4.STS.Identity.Configuration;

public class CultureConfiguration
{
    public static readonly string[] AvailableCultures = ["en", "fa", "fr", "ru", "sv", "zh", "es", "da", "de", "nl", "fi", "pt"];

    public static readonly string DefaultRequestCulture = "zh";

    public List<string> Cultures { get; set; }
    public string DefaultCulture { get; set; } = DefaultRequestCulture;
}