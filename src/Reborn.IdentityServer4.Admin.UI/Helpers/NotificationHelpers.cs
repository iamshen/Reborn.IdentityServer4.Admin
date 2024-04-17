namespace Reborn.IdentityServer4.Admin.UI.Helpers;

public class NotificationHelpers
{
    public enum AlertType
    {
        Info,
        Success,
        Warning,
        Error
    }

    public const string NotificationKey = "IdentityServerAdmin.Notification";

    public class Alert
    {
        public AlertType Type { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
    }
}