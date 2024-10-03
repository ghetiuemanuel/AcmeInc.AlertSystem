using System;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Statuses;

public interface IStatusRepository : IRepository<Status, Guid>
{
}
