﻿using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Reborn.AuditLogging.Events;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Events.ApiResource;

public class ApiResourcePropertyAddedEvent : AuditEvent
{
    public ApiResourcePropertyAddedEvent(ApiResourcePropertiesDto apiResourceProperty)
    {
        ApiResourceProperty = apiResourceProperty;
    }

    public ApiResourcePropertiesDto ApiResourceProperty { get; set; }
}