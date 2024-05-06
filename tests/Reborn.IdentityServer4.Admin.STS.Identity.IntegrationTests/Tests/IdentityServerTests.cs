using System.Threading.Tasks;
using FluentAssertions;
using IdentityModel.Client;
using Reborn.IdentityServer4.Admin.STS.Identity.IntegrationTests.Tests.Base;
using Xunit;

namespace Reborn.IdentityServer4.Admin.STS.Identity.IntegrationTests.Tests;

public class IdentityServerTests : BaseClassFixture
{
    public IdentityServerTests(TestFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task CanShowDiscoveryEndpoint()
    {
        var disco = await Client.GetDiscoveryDocumentAsync("http://localhost");

        disco.Should().NotBeNull();
        disco.IsError.Should().Be(false);

        disco.KeySet.Keys.Count.Should().Be(1);
    }
}