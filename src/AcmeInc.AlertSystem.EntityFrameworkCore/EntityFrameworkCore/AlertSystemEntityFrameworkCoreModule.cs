using AcmeInc.AlertSystem.Alerts;
using AcmeInc.AlertSystem.Rules;
using AcmeInc.AlertSystem.MessageSources;
using AcmeInc.AlertSystem.Messages;
using AcmeInc.AlertSystem.Statuses;
using AcmeInc.AlertSystem.Levels;
using AcmeInc.AlertSystem.Departments;
using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace AcmeInc.AlertSystem.EntityFrameworkCore;

[DependsOn(
    typeof(AlertSystemDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreMySQLModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule)
    )]
public class AlertSystemEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AlertSystemEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AlertSystemDbContext>(options =>
        {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
            options.AddRepository<Department, DepartmentRepository>();
            options.AddRepository<Level, LevelRepository>();
            options.AddRepository<Status, StatusRepository>();
            options.AddRepository<Message, MessageRepository>();
            options.AddRepository<WebhookMessageSource, WebhookMessageSourceRepository>();
            options.AddRepository<EmailMessageSource, EmailMessageSourceRepository>();
            options.AddRepository<Rule, RuleRepository>();
            options.AddRepository<Alert, AlertRepository>();
        });

        Configure<AbpDbContextOptions>(options =>
        {
                /* The main point to change your DBMS.
                 * See also AlertSystemMigrationsDbContextFactory for EF Core tooling. */
            options.UseMySQL();
        });

    }
}
