using System;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Levels;

public interface ILevelRepository : IRepository<Level, Guid>
{
}
