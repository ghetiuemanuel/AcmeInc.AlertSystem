using OptionOneTech.AlertSystem.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace OptionOneTech.AlertSystem.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AlertSystemController : AbpControllerBase
{
    protected AlertSystemController()
    {
        LocalizationResource = typeof(AlertSystemResource);
    }
}
