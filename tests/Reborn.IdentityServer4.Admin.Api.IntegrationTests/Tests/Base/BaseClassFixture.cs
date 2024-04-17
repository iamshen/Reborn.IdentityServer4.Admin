using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Reborn.IdentityServer4.Admin.Api.Configuration;
using Reborn.IdentityServer4.Admin.Api.IntegrationTests.Common;
using Xunit;

namespace Reborn.IdentityServer4.Admin.Api.IntegrationTests.Tests.Base;

public class BaseClassFixture : IClassFixture<TestFixture>
{
    protected readonly HttpClient Client;
    protected readonly TestServer TestServer;

    public BaseClassFixture(TestFixture fixture)
    {
        Client = fixture.Client;
        TestServer = fixture.TestServer;
    }

    protected virtual void SetupAdminClaimsViaHeaders()
    {
        using (var scope = TestServer.Services.CreateScope())
        {
            var configuration = scope.ServiceProvider.GetRequiredService<AdminApiConfiguration>();
            Client.SetAdminClaimsViaHeaders(configuration);
        }
    }
}