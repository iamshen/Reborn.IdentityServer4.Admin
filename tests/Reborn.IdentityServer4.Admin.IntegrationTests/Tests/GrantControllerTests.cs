﻿using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Reborn.IdentityServer4.Admin.IntegrationTests.Common;
using Reborn.IdentityServer4.Admin.IntegrationTests.Tests.Base;
using Reborn.IdentityServer4.Admin.UI.Configuration.Constants;
using Xunit;

namespace Reborn.IdentityServer4.Admin.IntegrationTests.Tests;

public class GrantControllerTests : BaseClassFixture
{
    public GrantControllerTests(TestFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task ReturnSuccessWithAdminRole()
    {
        SetupAdminClaimsViaHeaders();

        foreach (var route in RoutesConstants.GetGrantRoutes())
        {
            // Act
            var response = await Client.GetAsync($"/Grant/{route}");

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }

    [Fact]
    public async Task ReturnRedirectWithoutAdminRole()
    {
        //Remove
        Client.DefaultRequestHeaders.Clear();

        foreach (var route in RoutesConstants.GetGrantRoutes())
        {
            // Act
            var response = await Client.GetAsync($"/Grant/{route}");

            // Assert           
            response.StatusCode.Should().Be(HttpStatusCode.Redirect);

            //The redirect to login
            response.Headers.Location.ToString().Should().Contain(AuthenticationConsts.AccountLoginPage);
        }
    }
}