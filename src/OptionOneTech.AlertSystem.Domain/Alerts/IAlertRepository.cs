using OptionOneTech.AlertSystem.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Alerts;

public interface IAlertRepository : IRepository<Alert, Guid>, ILookupRepository<Alert>
{
    Task<IQueryable<AlertNavigation>> GetNavigationList();
}
