using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Reborn.IdentityServer4.Admin.STS.Identity.IntegrationTests.Tests.Base;
using Xunit;

namespace Reborn.IdentityServer4.Admin.STS.Identity.IntegrationTests.Tests;

public class DiagnosticsControllerTests : BaseClassFixture
{
    public DiagnosticsControllerTests(TestFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task UnAuthorizeUserCannotAccessDiagnosticsView()
    {
        // Clear headers
        Client.DefaultRequestHeaders.Clear();

        // Act
        var response = await Client.GetAsync("/Diagnostics/Index");

        // Assert      
        response.StatusCode.Should().Be(HttpStatusCode.Redirect);

        //The redirect to login
        response.Headers.Location.ToString().Should().Contain("Account/Login");
    }
}