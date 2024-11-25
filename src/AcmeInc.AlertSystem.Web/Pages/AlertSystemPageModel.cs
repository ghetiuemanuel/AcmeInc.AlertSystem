using AcmeInc.AlertSystem.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AcmeInc.AlertSystem.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class AlertSystemPageModel : AbpPageModel
{
    protected AlertSystemPageModel()
    {
        LocalizationResourceType = typeof(AlertSystemResource);
    }
}
