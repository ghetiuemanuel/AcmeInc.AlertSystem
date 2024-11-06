using OptionOneTech.AlertSystem.Lookup;
using OptionOneTech.AlertSystem.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Alerts;

public interface IRuleRepository : IRepository<Rule, Guid>, ILookupRepository<Rule>
{
    public Task<List<Rule>> GetActiveRulesAsync();
    Task<IQueryable<RuleNavigation>> GetNavigationList();
}
