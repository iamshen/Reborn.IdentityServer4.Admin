using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reborn.IdentityServer4.Admin.UI.Configuration.Constants;
using Reborn.IdentityServer4.Admin.UI.ExceptionHandling;
using Reborn.IdentityServer4.Shared.Configuration.Helpers;

namespace Reborn.IdentityServer4.Admin.UI.Areas.AdminUI.Controllers;

[Authorize(Policy = AuthorizationConsts.AdministrationPolicy)]
[TypeFilter(typeof(ControllerExceptionFilterAttribute))]
[Area(CommonConsts.AdminUIArea)]
public class HomeController : BaseController
{
    private readonly ILogger<ConfigurationController> _logger;

    public HomeController(ILogger<ConfigurationController> logger) : base(logger)
    {
        _logger = logger;
    }

    public IActionResult Index() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );
        return LocalRedirect(returnUrl);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SelectTheme(string theme, string returnUrl)
    {
        Response.Cookies.Append(
            ThemeHelpers.CookieThemeKey,
            theme,
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );

        return LocalRedirect(returnUrl);
    }

    public IActionResult Error()
    {
        // Get the details of the exception that occurred
        var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionFeature == null) return View();

        // Get which route the exception occurred at
        var routeWhereExceptionOccurred = exceptionFeature.Path;

        // Get the exception that occurred
        var exceptionThatOccurred = exceptionFeature.Error;

        // Log the exception
        _logger.LogError(exceptionThatOccurred, $"Exception at route {routeWhereExceptionOccurred}");

        return View();
    }
}