using OptionOneTech.AlertSystem.Lookup;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Departments
{
    public interface IDepartmentRepository : IRepository<Department, Guid>, ILookupRepository<Department>
    {
       
    }
}

