using System;
using OptionOneTech.AlertSystem.Permissions;
using OptionOneTech.AlertSystem.Levels.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Levels;


public class LevelAppService : CrudAppService<Level, LevelDto, Guid, PagedAndSortedResultRequestDto, CreateLevelDto, UpdateLevelDto>,
    ILevelAppService
{
    protected override string GetPolicyName { get; set; } = AlertSystemPermissions.Level.Default;
    protected override string GetListPolicyName { get; set; } = AlertSystemPermissions.Level.Default;
    protected override string CreatePolicyName { get; set; } = AlertSystemPermissions.Level.Create;
    protected override string UpdatePolicyName { get; set; } = AlertSystemPermissions.Level.Update;
    protected override string DeletePolicyName { get; set; } = AlertSystemPermissions.Level.Delete;

    private readonly ILevelRepository _repository;

    public LevelAppService(ILevelRepository repository) : base(repository)
    {
        _repository = repository;
    }

}
