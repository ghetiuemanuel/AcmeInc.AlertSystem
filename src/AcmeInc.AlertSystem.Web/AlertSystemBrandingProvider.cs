using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AcmeInc.AlertSystem.Web;

[Dependency(ReplaceServices = true)]
public class AlertSystemBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AlertSystem";
}
