using System;
using System.Linq;
using System.Threading.Tasks;
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
}