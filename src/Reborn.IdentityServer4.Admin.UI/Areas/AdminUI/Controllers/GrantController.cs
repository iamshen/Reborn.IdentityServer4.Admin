﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Grant;
using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Services.Interfaces;
using Reborn.IdentityServer4.Admin.UI.Configuration.Constants;
using Reborn.IdentityServer4.Admin.UI.ExceptionHandling;
using Reborn.IdentityServer4.Admin.UI.Helpers;

namespace Reborn.IdentityServer4.Admin.UI.Areas.AdminUI.Controllers;

[Authorize(Policy = AuthorizationConsts.AdministrationPolicy)]
[TypeFilter(typeof(ControllerExceptionFilterAttribute))]
[Area(CommonConsts.AdminUIArea)]
public class GrantController : BaseController
{
    private readonly IStringLocalizer<GrantController> _localizer;
    private readonly IPersistedGrantAspNetIdentityService _persistedGrantService;

    public GrantController(IPersistedGrantAspNetIdentityService persistedGrantService,
        ILogger<GrantController> logger,
        IStringLocalizer<GrantController> localizer) : base(logger)
    {
        _persistedGrantService = persistedGrantService;
        _localizer = localizer;
    }

    [HttpGet]
    public async Task<IActionResult> PersistedGrants(int? page, string search)
    {
        ViewBag.Search = search;
        var persistedGrants = await _persistedGrantService.GetPersistedGrantsByUsersAsync(search, page ?? 1);

        return View(persistedGrants);
    }

    [HttpGet]
    public async Task<IActionResult> PersistedGrantDelete(string id)
    {
        if (string.IsNullOrEmpty(id)) return NotFound();

        var grant = await _persistedGrantService.GetPersistedGrantAsync(UrlHelpers.QueryStringUnSafeHash(id));
        if (grant == null) return NotFound();

        return View(grant);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PersistedGrantDelete(PersistedGrantDto grant)
    {
        await _persistedGrantService.DeletePersistedGrantAsync(grant.Key);

        SuccessNotification(_localizer["SuccessPersistedGrantDelete"], _localizer["SuccessTitle"]);

        return RedirectToAction(nameof(PersistedGrants));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PersistedGrantsDelete(PersistedGrantsDto grants)
    {
        await _persistedGrantService.DeletePersistedGrantsAsync(grants.SubjectId);

        SuccessNotification(_localizer["SuccessPersistedGrantsDelete"], _localizer["SuccessTitle"]);

        return RedirectToAction(nameof(PersistedGrants));
    }


    [HttpGet]
    public async Task<IActionResult> PersistedGrant(string id, int? page)
    {
        var persistedGrants = await _persistedGrantService.GetPersistedGrantsByUserAsync(id, page ?? 1);
        persistedGrants.SubjectId = id;

        return View(persistedGrants);
    }
}