using OptionOneTech.AlertSystem.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace OptionOneTech.AlertSystem.Permissions;

public class AlertSystemPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AlertSystemPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AlertSystemPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AlertSystemResource>(name);
    }
}
