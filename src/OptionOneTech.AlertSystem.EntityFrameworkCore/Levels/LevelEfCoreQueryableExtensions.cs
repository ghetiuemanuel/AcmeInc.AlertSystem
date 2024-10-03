using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OptionOneTech.AlertSystem.Levels;

public static class LevelEfCoreQueryableExtensions
{
    public static IQueryable<Level> IncludeDetails(this IQueryable<Level> queryable, bool include = true)
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
