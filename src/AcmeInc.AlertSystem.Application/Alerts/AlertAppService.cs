using System;
using System.Linq;
using System.Threading.Tasks;
using AcmeInc.AlertSystem.Permissions;
using AcmeInc.AlertSystem.Alerts.Dtos;
using Volo.Abp.Application.Services;
using AcmeInc.AlertSystem.Lookup;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace AcmeInc.AlertSystem.Alerts;

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

    public async Task<PagedResultDto<LookupDto<Guid>>> GetLookupAsync(LookupRequestDto input)
    {
        var list = await _repository.GetLookupListAsync(input.SkipCount, input.MaxResultCount, input.IncludeInactive);
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

        var alerts = await query
           .Skip(input.SkipCount)
           .Take(input.MaxResultCount)
           .ToListAsync();

        return new PagedResultDto<AlertNavigationDto>(
            totalCount,
            ObjectMapper.Map<List<AlertNavigation>, List<AlertNavigationDto>>(alerts)
        );
    }
    public async Task UpdateStatusAsync(Guid Id, Guid statusId)
    {
        var alert = await _repository.GetAsync(Id);
        alert.StatusId = statusId;
        await _repository.UpdateAsync(alert);
    }
}
