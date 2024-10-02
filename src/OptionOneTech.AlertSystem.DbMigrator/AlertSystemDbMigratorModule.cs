using OptionOneTech.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace OptionOneTech.AlertSystem.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AlertSystemEntityFrameworkCoreModule),
    typeof(AlertSystemApplicationContractsModule)
    )]
public class AlertSystemDbMigratorModule : AbpModule
{
}
