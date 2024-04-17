﻿global using System;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Reborn.IdentityServer4.Admin.EntityFramework.Shared.DbContexts;
global using Reborn.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity;
global using Reborn.IdentityServer4.Shared.Configuration.Helpers;
global using Reborn.IdentityServer4.STS.Identity.Configuration;
global using Reborn.IdentityServer4.STS.Identity.Configuration.Constants;
global using Reborn.IdentityServer4.STS.Identity.Configuration.Interfaces;
global using Reborn.IdentityServer4.STS.Identity.Helpers;
global using System.IO;
global using Serilog;