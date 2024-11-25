using Microsoft.Extensions.DependencyInjection;
using AcmeInc.AlertSystem.BackgroundWorkers;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace AcmeInc.AlertSystem;

[DependsOn(
    typeof(AlertSystemDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(AlertSystemApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpBackgroundWorkersModule)
)]
public class AlertSystemApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AlertSystemApplicationModule>();
        });
        context.Services.AddTransient<EmailSourceBackgroundWorker>();
    }
    public override async Task OnApplicationInitializationAsync(
        ApplicationInitializationContext context)
    {
        await context.AddBackgroundWorkerAsync<NotificationBackgroundWorker>();
        await context.AddBackgroundWorkerAsync<EmailSourceBackgroundWorker>();
        await context.AddBackgroundWorkerAsync<AlertBackgroundWorker>();
    }
}
