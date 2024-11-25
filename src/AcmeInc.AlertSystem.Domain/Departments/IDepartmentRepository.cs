using AcmeInc.AlertSystem.Lookup;
using System;
using Volo.Abp.Domain.Repositories;

namespace AcmeInc.AlertSystem.Departments
{
    public interface IDepartmentRepository : IRepository<Department, Guid>, ILookupRepository<Department>
    {
       
    }
}

