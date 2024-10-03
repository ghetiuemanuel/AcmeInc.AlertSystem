namespace OptionOneTech.AlertSystem.Permissions;

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
}
