using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Reborn.IdentityServer4.Admin.STS.Identity.IntegrationTests.Tests.Base;
using Xunit;

namespace Reborn.IdentityServer4.Admin.STS.Identity.IntegrationTests.Tests;

public class HomeControllerTests : BaseClassFixture
{
    public HomeControllerTests(TestFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task EveryoneHasAccessToHomepage()
    {
        Client.DefaultRequestHeaders.Clear();

        // Act
        var response = await Client.GetAsync("/home/index");

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}