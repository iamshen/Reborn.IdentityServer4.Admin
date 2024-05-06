using Reborn.IdentityServer4.Admin.AuditLogging.Constants;

namespace Reborn.IdentityServer4.Admin.AuditLogging.Configuration
{
    public class AuditHttpSubjectOptions
    {
        public string SubjectIdentifierClaim { get; set; } = ClaimsConsts.Sub;

        public string SubjectNameClaim { get; set; } = ClaimsConsts.Name;
    }
}