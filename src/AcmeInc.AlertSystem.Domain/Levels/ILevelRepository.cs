using AcmeInc.AlertSystem.Lookup;
using System;
using Volo.Abp.Domain.Repositories;

namespace AcmeInc.AlertSystem.Levels;

public interface ILevelRepository : IRepository<Level, Guid>, ILookupRepository<Level>
{

}
