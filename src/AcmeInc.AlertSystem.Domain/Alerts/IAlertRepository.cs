using AcmeInc.AlertSystem.Lookup;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AcmeInc.AlertSystem.Alerts;

public interface IAlertRepository : IRepository<Alert, Guid>, ILookupRepository<Alert>
{
    Task<IQueryable<AlertNavigation>> GetNavigationList();
}
