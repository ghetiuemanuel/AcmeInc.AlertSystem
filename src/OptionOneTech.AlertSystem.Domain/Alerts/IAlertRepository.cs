using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Alerts;

public interface IAlertRepository : IRepository<Alert, Guid>
{
    Task<List<Alert>> GetLookupListAsync(int skipCount, int maxResultCount, bool includeIsActive);
    Task<IQueryable<AlertNavigation>> GetNavigationList();
}
