using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OptionOneTech.AlertSystem.MessageSources;

public static class EmailMessageSourceEfCoreQueryableExtensions
{
    public static IQueryable<EmailMessageSource> IncludeDetails(this IQueryable<EmailMessageSource> queryable, bool include = true)
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
