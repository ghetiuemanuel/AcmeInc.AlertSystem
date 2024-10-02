using System;
using System.Linq;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.Permissions;
using OptionOneTech.AlertSystem.Departments.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Departments;


public class DepartmentAppService : CrudAppService<Department, DepartmentDto, Guid, DepartmentGetListInput, DepartmentCreateDto, DepartmentUpdateDto>,
    IDepartmentAppService
{
    protected override string GetPolicyName { get; set; } = AlertSystemPermissions.Department.Default;
    protected override string GetListPolicyName { get; set; } = AlertSystemPermissions.Department.Default;
    protected override string CreatePolicyName { get; set; } = AlertSystemPermissions.Department.Create;
    protected override string UpdatePolicyName { get; set; } = AlertSystemPermissions.Department.Update;
    protected override string DeletePolicyName { get; set; } = AlertSystemPermissions.Department.Delete;

    private readonly IDepartmentRepository _repository;

    public DepartmentAppService(IDepartmentRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Department>> CreateFilteredQueryAsync(DepartmentGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(!input.Description.IsNullOrWhiteSpace(), x => x.Description.Contains(input.Description))
            .WhereIf(input.Active != null, x => x.Active == input.Active)
            ;
    }
}
