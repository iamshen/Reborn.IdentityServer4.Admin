namespace Reborn.IdentityServer4.Admin.AuditLogging.Events
{
    public interface IAuditAction
    {
        object Action { get; set; }
    }
}