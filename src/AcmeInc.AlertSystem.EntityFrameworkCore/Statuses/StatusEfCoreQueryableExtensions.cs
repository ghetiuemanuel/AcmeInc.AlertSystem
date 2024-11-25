using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AcmeInc.AlertSystem.Statuses;

public static class StatusEfCoreQueryableExtensions
{
    public static IQueryable<Status> IncludeDetails(this IQueryable<Status> queryable, bool include = true)
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
