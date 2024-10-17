using OptionOneTech.AlertSystem.Localization;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem;

/* Inherit your application services from this class.
 */
public abstract class AlertSystemAppService : ApplicationService
{
    protected AlertSystemAppService()
    {
        LocalizationResource = typeof(AlertSystemResource);
    }
}
