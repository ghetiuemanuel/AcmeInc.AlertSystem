using AcmeInc.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AcmeInc.AlertSystem.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AlertSystemEntityFrameworkCoreModule),
    typeof(AlertSystemApplicationContractsModule)
    )]
public class AlertSystemDbMigratorModule : AbpModule
{
}
