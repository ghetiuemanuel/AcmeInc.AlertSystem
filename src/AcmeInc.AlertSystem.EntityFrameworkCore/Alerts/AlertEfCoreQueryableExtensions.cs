using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AcmeInc.AlertSystem.Alerts;

public static class AlertEfCoreQueryableExtensions
{
    public static IQueryable<Alert> IncludeDetails(this IQueryable<Alert> queryable, bool include = true)
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
