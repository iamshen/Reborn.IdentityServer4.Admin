using System;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.Log;

public class LogsDeletedEvent : AuditEvent
{
    public LogsDeletedEvent(DateTime deleteOlderThan)
    {
        DeleteOlderThan = deleteOlderThan;
    }

    public DateTime DeleteOlderThan { get; set; }
}