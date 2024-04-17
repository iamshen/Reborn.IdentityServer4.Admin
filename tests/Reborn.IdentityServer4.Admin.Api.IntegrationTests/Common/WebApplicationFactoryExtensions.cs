using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Reborn.IdentityServer4.Admin.Api.Configuration.Test;

namespace Reborn.IdentityServer4.Admin.Api.IntegrationTests.Common;

public static class WebApplicationFactoryExtensions
{
    public static HttpClient SetupClient(this WebApplicationFactory<StartupTest> fixture)
    {
        var options = new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        };

        return fixture.WithWebHostBuilder(
            builder => builder
                .UseStartup<StartupTest>()
                .ConfigureTestServices(services => { })
        ).CreateClient(options);
    }
}