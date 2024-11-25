using AcmeInc.AlertSystem.Lookup;
using AcmeInc.AlertSystem.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AcmeInc.AlertSystem.Alerts;

public interface IRuleRepository : IRepository<Rule, Guid>, ILookupRepository<Rule>
{
    public Task<List<Rule>> GetActiveRulesAsync();
    Task<IQueryable<RuleNavigation>> GetNavigationList();
}
