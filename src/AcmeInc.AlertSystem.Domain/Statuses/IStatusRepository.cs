using AcmeInc.AlertSystem.Lookup;
using System;
using Volo.Abp.Domain.Repositories;

namespace AcmeInc.AlertSystem.Statuses;

public interface IStatusRepository : IRepository<Status, Guid>, ILookupRepository<Status>
{
}
