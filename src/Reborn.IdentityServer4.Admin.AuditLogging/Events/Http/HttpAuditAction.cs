using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Reborn.IdentityServer4.Admin.AuditLogging.Configuration;
using Reborn.IdentityServer4.Admin.AuditLogging.Helpers.HttpContextHelpers;

namespace Reborn.IdentityServer4.Admin.AuditLogging.Events.Http
{
    public class HttpAuditAction : IAuditAction
    {
        public HttpAuditAction(IHttpContextAccessor accessor, AuditHttpActionOptions options)
        {
            Action = new
            {
                TraceIdentifier = accessor.HttpContext.TraceIdentifier,
                RequestUrl = accessor.HttpContext.Request.GetDisplayUrl(),
                HttpMethod = accessor.HttpContext.Request.Method,
                FormVariables = options.IncludeFormVariables ? HttpContextHelpers.GetFormVariables(accessor.HttpContext) : null
            };
        }

        public object Action { get; set; }
    }
}