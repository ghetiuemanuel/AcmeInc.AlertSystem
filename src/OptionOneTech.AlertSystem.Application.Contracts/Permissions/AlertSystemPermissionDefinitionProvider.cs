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

        var departmentPermission = myGroup.AddPermission(AlertSystemPermissions.Department.Default, L("Permission:Department"));
        departmentPermission.AddChild(AlertSystemPermissions.Department.Create, L("Permission:Create"));
        departmentPermission.AddChild(AlertSystemPermissions.Department.Update, L("Permission:Update"));
        departmentPermission.AddChild(AlertSystemPermissions.Department.Delete, L("Permission:Delete"));

        var levelPermission = myGroup.AddPermission(AlertSystemPermissions.Level.Default, L("Permission:Level"));
        levelPermission.AddChild(AlertSystemPermissions.Level.Create, L("Permission:Create"));
        levelPermission.AddChild(AlertSystemPermissions.Level.Update, L("Permission:Update"));
        levelPermission.AddChild(AlertSystemPermissions.Level.Delete, L("Permission:Delete"));

        var statusPermission = myGroup.AddPermission(AlertSystemPermissions.Status.Default, L("Permission:Status"));
        statusPermission.AddChild(AlertSystemPermissions.Status.Create, L("Permission:Create"));
        statusPermission.AddChild(AlertSystemPermissions.Status.Update, L("Permission:Update"));
        statusPermission.AddChild(AlertSystemPermissions.Status.Delete, L("Permission:Delete"));

        var messagePermission = myGroup.AddPermission(AlertSystemPermissions.Message.Default, L("Permission:Message"));
        messagePermission.AddChild(AlertSystemPermissions.Message.Create, L("Permission:Create"));
        messagePermission.AddChild(AlertSystemPermissions.Message.Update, L("Permission:Update"));
        messagePermission.AddChild(AlertSystemPermissions.Message.Delete, L("Permission:Delete"));

        var webhookMessageSourcePermission = myGroup.AddPermission(AlertSystemPermissions.WebhookMessageSource.Default, L("Permission:WebhookMessageSource"));
        webhookMessageSourcePermission.AddChild(AlertSystemPermissions.WebhookMessageSource.Create, L("Permission:Create"));
        webhookMessageSourcePermission.AddChild(AlertSystemPermissions.WebhookMessageSource.Update, L("Permission:Update"));
        webhookMessageSourcePermission.AddChild(AlertSystemPermissions.WebhookMessageSource.Delete, L("Permission:Delete"));

        var emailMessageSourcePermission = myGroup.AddPermission(AlertSystemPermissions.EmailMessageSource.Default, L("Permission:EmailMessageSource"));
        emailMessageSourcePermission.AddChild(AlertSystemPermissions.EmailMessageSource.Create, L("Permission:Create"));
        emailMessageSourcePermission.AddChild(AlertSystemPermissions.EmailMessageSource.Update, L("Permission:Update"));
        emailMessageSourcePermission.AddChild(AlertSystemPermissions.EmailMessageSource.Delete, L("Permission:Delete"));

        var rulePermission = myGroup.AddPermission(AlertSystemPermissions.Rule.Default, L("Permission:Rule"));
        rulePermission.AddChild(AlertSystemPermissions.Rule.Create, L("Permission:Create"));
        rulePermission.AddChild(AlertSystemPermissions.Rule.Update, L("Permission:Update"));
        rulePermission.AddChild(AlertSystemPermissions.Rule.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AlertSystemResource>(name);
    }
}
