using System.Threading.Tasks;
using OptionOneTech.AlertSystem.Permissions;
using OptionOneTech.AlertSystem.Localization;
using OptionOneTech.AlertSystem.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using System.Collections.Generic;
using System.Linq;

namespace OptionOneTech.AlertSystem.Web.Menus;

public class AlertSystemMenuContributor : IMenuContributor
{
    public string Permissions { get; private set; }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<AlertSystemResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AlertSystemMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        context.Menu.Items.Add(new ApplicationMenuItem(
            AlertSystemMenus.Department,
            l["Menu:Department"],
            "/Department",
            icon: "fas fa-users",
            requiredPermissionName: AlertSystemPermissions.Department.Default
        ));
        context.Menu.Items.Add(new ApplicationMenuItem(
            AlertSystemMenus.Level,
            l["Menu:Level"],
            "/Level",
            icon: "fas fa-signal",
            requiredPermissionName: AlertSystemPermissions.Level.Default            
        ));

        context.Menu.Items.Add(new ApplicationMenuItem(
           AlertSystemMenus.Status,
           l["Menu:Status"],
           "/Status",
           icon: "fas fa-clock",
           requiredPermissionName: AlertSystemPermissions.Status.Default
        ));
        context.Menu.Items.Add(new ApplicationMenuItem(
           AlertSystemMenus.Message,
           l["Menu:Message"],
           "/Message",
           icon: "fas fa-envelope",
           requiredPermissionName: AlertSystemPermissions.Message.Default
        ));
        context.Menu.Items.Add(new ApplicationMenuItem(
          AlertSystemMenus.WebhookMessageSource,
          l["Menu:WebhookMessageSource"],
          "/WebhookMessageSource",
          icon: "fas fa-bell",
          requiredPermissionName: AlertSystemPermissions.WebhookMessageSource.Default
        ));
        context.Menu.Items.Add(new ApplicationMenuItem(
          AlertSystemMenus.EmailMessageSource,
          l["Menu:EmailMessageSource"],
          "/EmailMessageSource",
          icon: "fas fa-paper-plane",
          requiredPermissionName: AlertSystemPermissions.EmailMessageSource.Default
        ));
        context.Menu.Items.Add(new ApplicationMenuItem(
          AlertSystemMenus.Rule,
          l["Menu:Rule"],
          "/Rule",
          icon: "fas fa-exclamation-triangle",
          requiredPermissionName: AlertSystemPermissions.Rule.Default
        ));
        context.Menu.Items.Add(new ApplicationMenuItem(
           AlertSystemMenus.Alert,
           l["Menu:Alert"],
           "/Alert",
           icon: "fas fa-shield-alt",
           requiredPermissionName: AlertSystemPermissions.Alert.Default
         ));
    }
}
