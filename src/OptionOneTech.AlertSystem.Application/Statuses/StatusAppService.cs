using System;
using OptionOneTech.AlertSystem.Permissions;
using OptionOneTech.AlertSystem.Statuses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Statuses;


public class StatusAppService : CrudAppService<Status, StatusDto, Guid, PagedAndSortedResultRequestDto, CreateStatusDto, UpdateStatusDto>,
    IStatusAppService
{
    protected override string GetPolicyName { get; set; } = AlertSystemPermissions.Status.Default;
    protected override string GetListPolicyName { get; set; } = AlertSystemPermissions.Status.Default;
    protected override string CreatePolicyName { get; set; } = AlertSystemPermissions.Status.Create;
    protected override string UpdatePolicyName { get; set; } = AlertSystemPermissions.Status.Update;
    protected override string DeletePolicyName { get; set; } = AlertSystemPermissions.Status.Delete;

    private readonly IStatusRepository _repository;

    public StatusAppService(IStatusRepository repository) : base(repository)
    {
        _repository = repository;
    }

}
