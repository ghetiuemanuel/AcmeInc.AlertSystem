using OptionOneTech.AlertSystem.Lookup;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Statuses;

public interface IStatusRepository : IRepository<Status, Guid>, ILookupRepository<Status>
{
}
