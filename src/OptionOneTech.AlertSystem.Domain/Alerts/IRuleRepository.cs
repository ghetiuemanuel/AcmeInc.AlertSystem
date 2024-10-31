using OptionOneTech.AlertSystem.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Alerts;

public interface IRuleRepository : IRepository<Rule, Guid>
{
    public Task<List<Rule>> GetActiveRulesAsync();
    Task<List<Rule>> GetLookupListAsync(int skipCount, int maxResultCount);
    Task<IQueryable<RuleNavigation>> GetNavigationList();
}
