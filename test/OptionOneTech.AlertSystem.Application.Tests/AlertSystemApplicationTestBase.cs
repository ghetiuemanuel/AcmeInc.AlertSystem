using Volo.Abp.Modularity;

namespace OptionOneTech.AlertSystem;

public abstract class AlertSystemApplicationTestBase<TStartupModule> : AlertSystemTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
