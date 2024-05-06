using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Reborn.IdentityServer4.Admin.STS.Identity.Configuration.Test;

namespace Reborn.IdentityServer4.Admin.STS.Identity.IntegrationTests.Tests.Base;

public class TestFixture : IDisposable
{
    public TestServer TestServer;

    public TestFixture()
    {
        var builder = new WebHostBuilder()
            .ConfigureAppConfiguration((hostContext, configApp) =>
            {
                configApp.AddJsonFile("appsettings.json", true, true);
                configApp.AddJsonFile("serilog.json", true, true);

                var env = hostContext.HostingEnvironment;

                configApp.AddJsonFile($"serilog.{env.EnvironmentName}.json", true, true);
                configApp.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
            })
            .UseStartup<StartupTest>();

        TestServer = new TestServer(builder);
        Client = TestServer.CreateClient();
    }

    public HttpClient Client { get; }

    public void Dispose()
    {
        Client.Dispose();
        TestServer.Dispose();
    }
}