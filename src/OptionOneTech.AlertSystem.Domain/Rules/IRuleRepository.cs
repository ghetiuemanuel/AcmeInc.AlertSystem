using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Rules;

public interface IRuleRepository : IRepository<Rule, Guid>
{
    Task<List<Rule>> GetLookupListAsync(int skipCount, int maxResultCount);
}
