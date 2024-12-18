namespace AcmeInc.AlertSystem.Permissions;

public static class AlertSystemPermissions
{
    public const string GroupName = "AlertSystem";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public class Department
    {
        public const string Default = GroupName + ".Department";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class Level
    {
        public const string Default = GroupName + ".Level";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class Status
    {
        public const string Default = GroupName + ".Status";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class Message
    {
        public const string Default = GroupName + ".Message";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class WebhookMessageSource
    {
        public const string Default = GroupName + ".WebhookMessageSource";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class EmailMessageSource
    {
        public const string Default = GroupName + ".EmailMessageSource";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class Rule
    {
        public const string Default = GroupName + ".Rule";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class Alert
    {
        public const string Default = GroupName + ".Alert";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}
