using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
    public async Task<List<Rule>> GetLookupListAsync(int skip, int take)
    {
        return await (await GetQueryableAsync())
            .AsNoTracking()
            .Select(rule => new Rule(rule.Id, "", "", "", true, rule.AlertTitle, "", Guid.Empty, Guid.Empty, Guid.Empty))
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
}