using System;
using System.Threading.Tasks;

namespace AcmeInc.AlertSystem.Web.Pages.Level;

public class IndexModel : AlertSystemPageModel
{
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

