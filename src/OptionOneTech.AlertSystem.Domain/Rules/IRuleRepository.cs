using System;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Rules;

public interface IRuleRepository : IRepository<Rule, Guid>
{
}
