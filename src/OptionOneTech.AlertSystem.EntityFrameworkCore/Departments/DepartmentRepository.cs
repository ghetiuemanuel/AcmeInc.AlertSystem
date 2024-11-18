using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OptionOneTech.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;


namespace OptionOneTech.AlertSystem.Departments
{
    public class DepartmentRepository : EfCoreRepository<AlertSystemDbContext, Department, Guid>, IDepartmentRepository
    {
        public DepartmentRepository(IDbContextProvider<AlertSystemDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
        public override async Task<IQueryable<Department>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
        public async Task<List<Department>> GetLookupListAsync(int skip, int take, bool includeInactive)
        {
            return await (await GetQueryableAsync())
                .AsNoTracking()
                .Where(department => includeInactive || department.Active)
                .Select(department => new Department(department.Id, department.Name, "", true))
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
    }
}

