﻿using System;
using System.Threading.Tasks;
using Reborn.IdentityServer4.Admin.AuditLogging.Configuration;
using Reborn.IdentityServer4.Admin.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.AuditLogging.Services
{
    public interface IAuditEventLogger<out TAuditLoggerOptions> 
        where TAuditLoggerOptions : AuditLoggerOptions
    {
        /// <summary>
        /// Log an event
        /// </summary>
        /// <param name="auditEvent">The specific audit event</param>
        /// <param name="loggerOptions"></param>
        /// <returns></returns>
        Task LogEventAsync(AuditEvent auditEvent, Action<TAuditLoggerOptions> loggerOptions = default);
    }

    public interface IAuditEventLogger : IAuditEventLogger<AuditLoggerOptions>
    {

    }
}