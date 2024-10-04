using System;
using System.Threading.Tasks;

namespace OptionOneTech.AlertSystem.Web.Pages.MessageSources.WebhookMessageSource;

public class IndexModel : AlertSystemPageModel
{
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

