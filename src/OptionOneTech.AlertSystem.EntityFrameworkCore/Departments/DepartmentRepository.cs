using System;
using System.Linq;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace OptionOneTech.AlertSystem.Departments;

public class DepartmentRepository : EfCoreRepository<AlertSystemDbContext, Department, Guid>, IDepartmentRepository
{
    public DepartmentRepository(IDbContextProvider<AlertSystemDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Department>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}