﻿using System;
using System.Threading.Tasks;
using Reborn.IdentityServer4.Admin.AuditLogging.EntityFramework.Entities;
using Reborn.IdentityServer4.Admin.AuditLogging.EntityFramework.Mapping;
using Reborn.IdentityServer4.Admin.AuditLogging.EntityFramework.Repositories;
using Reborn.IdentityServer4.Admin.AuditLogging.Events;
using Reborn.IdentityServer4.Admin.AuditLogging.Services;

namespace Reborn.IdentityServer4.Admin.AuditLogging.EntityFramework.Services
{
    public class DatabaseAuditEventLoggerSink<TAuditLog> : IAuditEventLoggerSink 
        where TAuditLog : AuditLog, new()
    {
        private readonly IAuditLoggingRepository<TAuditLog> _auditLoggingRepository;

        public DatabaseAuditEventLoggerSink(IAuditLoggingRepository<TAuditLog> auditLoggingRepository)
        {
            _auditLoggingRepository = auditLoggingRepository;
        }

        public virtual async Task PersistAsync(AuditEvent auditEvent)
        {
            if (auditEvent == null) throw new ArgumentNullException(nameof(auditEvent));

            var auditLog = auditEvent.MapToEntity<TAuditLog>();

            await _auditLoggingRepository.SaveAsync(auditLog);
        }
    }
}