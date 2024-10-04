using OptionOneTech.AlertSystem.Lookup;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Departments;

public interface IDepartmentRepository : IRepository<Department, Guid>
{
    public interface IRepository<TEntity, TKey>
    {
        Task<List<LookupDto<TKey>>> GetLookupListAsync(long skip, long take);
    }

}
