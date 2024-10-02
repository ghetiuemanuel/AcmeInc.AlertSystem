using Volo.Abp.Modularity;

namespace OptionOneTech.AlertSystem;

/* Inherit from this class for your domain layer tests. */
public abstract class AlertSystemDomainTestBase<TStartupModule> : AlertSystemTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
