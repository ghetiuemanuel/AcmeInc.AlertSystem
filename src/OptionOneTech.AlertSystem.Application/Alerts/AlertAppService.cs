using System;
using System.Linq;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.Permissions;
using OptionOneTech.AlertSystem.Alerts.Dtos;
using Volo.Abp.Application.Services;
using OptionOneTech.AlertSystem.Lookup;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Departments.Dtos;
using OptionOneTech.AlertSystem.Levels.Dtos;
using OptionOneTech.AlertSystem.Messages.Dtos;
using OptionOneTech.AlertSystem.Rules.Dtos;
using OptionOneTech.AlertSystem.Statuses.Dtos;
using OptionOneTech.AlertSystem.Rules;
using OptionOneTech.AlertSystem.Departments;
using OptionOneTech.AlertSystem.Levels;
using OptionOneTech.AlertSystem.Statuses;

namespace OptionOneTech.AlertSystem.Alerts;

public class AlertAppService : CrudAppService<Alert, AlertDto, Guid, AlertGetListInput, AlertCreateDto, AlertUpdateDto>,
    IAlertAppService
{
    protected override string GetPolicyName { get; set; } = AlertSystemPermissions.Alert.Default;
    protected override string GetListPolicyName { get; set; } = AlertSystemPermissions.Alert.Default;
    protected override string CreatePolicyName { get; set; } = AlertSystemPermissions.Alert.Create;
    protected override string UpdatePolicyName { get; set; } = AlertSystemPermissions.Alert.Update;
    protected override string DeletePolicyName { get; set; } = AlertSystemPermissions.Alert.Delete;

    private readonly IAlertRepository _repository;

    public AlertAppService(IAlertRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Alert>> CreateFilteredQueryAsync(AlertGetListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Title.IsNullOrWhiteSpace(), x => x.Title.Contains(input.Title))
            .WhereIf(!input.Body.IsNullOrWhiteSpace(), x => x.Body.Contains(input.Body))
            .WhereIf(input.MessageId != null, x => x.MessageId == input.MessageId)
            .WhereIf(input.RuleId != null, x => x.RuleId == input.RuleId)
            .WhereIf(input.DepartmentId != null, x => x.DepartmentId == input.DepartmentId)
            .WhereIf(input.StatusId != null, x => x.StatusId == input.StatusId)
            .WhereIf(input.LevelId != null, x => x.LevelId == input.LevelId)
            ;
    }
    public async Task<PagedResultDto<LookupDto<Guid>>> GetLookupAsync(PagedResultRequestDto input)
    {
        var list = await _repository.GetLookupListAsync(input.SkipCount, input.MaxResultCount);
        var totalCount = await _repository.CountAsync();

        return new PagedResultDto<LookupDto<Guid>>(
            totalCount,
            ObjectMapper.Map<List<Alert>, List<LookupDto<Guid>>>(list)
        );
    }
    public async Task<PagedResultDto<AlertNavigationDto>> GetNavigationListAsync(AlertGetListInput input)
    {
        var query = await _repository.GetNavigationList();

        query = query
            .WhereIf(!input.Title.IsNullOrWhiteSpace(), x => x.Alert.Title.Contains(input.Title))
            .WhereIf(!input.Body.IsNullOrWhiteSpace(), x => x.Alert.Body.Contains(input.Body))
            .WhereIf(input.MessageId != null, x => x.Alert.MessageId == input.MessageId)
            .WhereIf(input.RuleId != null, x => x.Alert.RuleId == input.RuleId)
            .WhereIf(input.DepartmentId != null, x => x.Alert.DepartmentId == input.DepartmentId)
            .WhereIf(input.StatusId != null, x => x.Alert.StatusId == input.StatusId)
            .WhereIf(input.LevelId != null, x => x.Alert.LevelId == input.LevelId);

        if (!input.Sorting.IsNullOrWhiteSpace())
        {
            query = query.OrderBy(input.Sorting);
        }
        else
        {
            query = query.OrderBy(x => x.Alert.Title);
        }

        var totalCount = await query.CountAsync();

        var alerts = await query // selecteaza alertele si le mapeaza intr-un nou tip de DTO
            .Select(alert => new AlertNavigationDto
            {
                Alert = ObjectMapper.Map<Alert, AlertDto>(alert.Alert),// mapeaza alert la dto-ul bun
                Department = ObjectMapper.Map<Department, DepartmentDto>(alert.Department),
                Level = ObjectMapper.Map<Level, LevelDto>(alert.Level),
                Status = ObjectMapper.Map<Status, StatusDto>(alert.Status), 
                Message = ObjectMapper.Map<Message, MessageDto>(alert.Message), 
                Rule = ObjectMapper.Map<Rule, RuleDto>(alert.Rule) 
            })
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .ToListAsync();
        //returneaza rezultatul paginat
        return new PagedResultDto<AlertNavigationDto>(
            totalCount,
            alerts
        );
    }
    public async Task UpdateAlertStatusAsync(Guid alertId, Guid statusId)// e creata pentru a actualiza statusul fara edit
    {
        var alert = await _repository.GetAsync(alertId);// ia alerta dupa id
        alert.StatusId = statusId;// modifica statusid al alertei
        await _repository.UpdateAsync(alert);// salveaza schimbarile in repository
    }
}
