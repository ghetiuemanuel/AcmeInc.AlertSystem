using Volo.Abp.Modularity;

namespace OptionOneTech.AlertSystem;

[DependsOn(
    typeof(AlertSystemApplicationModule),
    typeof(AlertSystemDomainTestModule)
)]
public class AlertSystemApplicationTestModule : AbpModule
{

}
