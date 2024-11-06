using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OptionOneTech.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace OptionOneTech.AlertSystem.Statuses;

public class StatusRepository : EfCoreRepository<AlertSystemDbContext, Status, Guid>, IStatusRepository
{
    public StatusRepository(IDbContextProvider<AlertSystemDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Status>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
    public async Task<List<Status>> GetLookupListAsync(int skip, int take, bool includeInactive)
    {
        return await (await GetQueryableAsync())
                .AsNoTracking()
                .Where(status => includeInactive || status.Active)
                .Select(status => new Status(status.Id, status.Name, "", true))
                .Skip(skip)
                .Take(take)
                .ToListAsync();
    }
}