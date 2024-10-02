using Volo.Abp.Modularity;

namespace OptionOneTech.AlertSystem;

[DependsOn(
    typeof(AlertSystemDomainModule),
    typeof(AlertSystemTestBaseModule)
)]
public class AlertSystemDomainTestModule : AbpModule
{

}
