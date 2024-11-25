using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AcmeInc.AlertSystem.MessageSources;

public static class WebhookMessageSourceEfCoreQueryableExtensions
{
    public static IQueryable<WebhookMessageSource> IncludeDetails(this IQueryable<WebhookMessageSource> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            // .Include(x => x.xxx) // TODO: AbpHelper generated
            ;
    }
}
