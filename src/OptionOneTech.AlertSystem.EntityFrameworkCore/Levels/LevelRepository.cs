using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OptionOneTech.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace OptionOneTech.AlertSystem.Levels;

public class LevelRepository : EfCoreRepository<AlertSystemDbContext, Level, Guid>, ILevelRepository
{
    public LevelRepository(IDbContextProvider<AlertSystemDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Level>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
    public async Task<List<Level>> GetLookupListAsync(int skip, int take)
    {
        return await (await GetQueryableAsync())
            .AsNoTracking()
            .Where(level => level.Active)
            .Select(level => new Level(level.Id, level.Name, "", true))
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
}