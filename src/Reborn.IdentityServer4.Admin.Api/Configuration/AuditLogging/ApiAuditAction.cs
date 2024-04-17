using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.Api.AuditLogging;

public class ApiAuditAction : IAuditAction
{
    public ApiAuditAction(IHttpContextAccessor accessor)
    {
        Action = new
        {
            accessor.HttpContext.TraceIdentifier,
            RequestUrl = accessor.HttpContext.Request.GetDisplayUrl(),
            HttpMethod = accessor.HttpContext.Request.Method
        };
    }

    public object Action { get; set; }
}