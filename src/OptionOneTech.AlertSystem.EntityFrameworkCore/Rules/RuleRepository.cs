using System;
using System.Linq;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace OptionOneTech.AlertSystem.Rules;

public class RuleRepository : EfCoreRepository<AlertSystemDbContext, Rule, Guid>, IRuleRepository
{
    public RuleRepository(IDbContextProvider<AlertSystemDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Rule>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}