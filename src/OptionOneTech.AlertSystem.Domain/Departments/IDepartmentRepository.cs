using System;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Departments;

public interface IDepartmentRepository : IRepository<Department, Guid>
{
}
