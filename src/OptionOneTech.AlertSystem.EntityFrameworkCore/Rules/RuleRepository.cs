using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OptionOneTech.AlertSystem.Alerts;
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
    public async Task<List<Rule>> GetLookupListAsync(int skip, int take, bool includeInActive)
    {
        return await (await GetQueryableAsync())
            .AsNoTracking()
            .Select(rule => new Rule(rule.Id, "", "", "", true, rule.AlertTitle, "", Guid.Empty, Guid.Empty, Guid.Empty, 0, 0, 0, DateTime.Now , true, ""))
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
    public async Task<IQueryable<RuleNavigation>> GetNavigationList()
    {
        var dbContext = await GetDbContextAsync();

        var query =
            from rule in dbContext.Rules
            join department in dbContext.Departments
            on rule.AlertDepartmentId equals department.Id into departmentGroup
            from department in departmentGroup.DefaultIfEmpty()
            join level in dbContext.Levels
            on rule.AlertLevelId equals level.Id into levelGroup
            from level in levelGroup.DefaultIfEmpty()
            join status in dbContext.Statuses
            on rule.AlertStatusId equals status.Id into statusGroup
            from status in statusGroup.DefaultIfEmpty()
            select new RuleNavigation
            {
                Rule = rule,
                Department = department,
                Level = level,
                Status = status
            };
        return query;
    }
    public async Task<List<Rule>> GetActiveRulesAsync()
    {
        return await (await GetQueryableAsync())
            .AsNoTracking()
            .Where(rule => rule.Active)
            .ToListAsync();
    }

}