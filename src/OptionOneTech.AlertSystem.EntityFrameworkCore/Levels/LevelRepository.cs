using System;
using System.Linq;
using System.Threading.Tasks;
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
}