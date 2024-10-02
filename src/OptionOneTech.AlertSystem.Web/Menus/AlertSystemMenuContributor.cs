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
            "/Departments/Department",
            icon: "fas fa-users",
            requiredPermissionName: AlertSystemPermissions.Department.Default
        ));
    }
}