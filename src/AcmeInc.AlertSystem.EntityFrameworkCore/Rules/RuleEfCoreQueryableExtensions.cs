using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AcmeInc.AlertSystem.Rules;

public static class RuleEfCoreQueryableExtensions
{
    public static IQueryable<Rule> IncludeDetails(this IQueryable<Rule> queryable, bool include = true)
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
