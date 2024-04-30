namespace Reborn.IdentityServer4.AuditLogging.Events
{
    public interface IAuditAction
    {
        object Action { get; set; }
    }
}