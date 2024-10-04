using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OptionOneTech.AlertSystem.EntityFrameworkCore;
using OptionOneTech.AlertSystem.Lookup;
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
        
        public async Task<List<LookupDto<Guid>>> GetLookupListAsync(long skip, long take)
        {
            return await (await GetQueryableAsync())
                .AsNoTracking() 
                .Where(department => department.Active) 
                .Select(department => new LookupDto<Guid>
                {
                    Id = department.Id,
                    Name = department.Name 
                })
                .Skip((int)skip)
                .Take((int)take)
                .ToListAsync();
        }
    }
}

