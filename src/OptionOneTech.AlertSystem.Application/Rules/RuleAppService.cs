using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.Lookup;
using OptionOneTech.AlertSystem.Permissions;
using OptionOneTech.AlertSystem.Rules.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using OptionOneTech.AlertSystem.Alerts;

namespace OptionOneTech.AlertSystem.Rules;

public class RuleAppService : CrudAppService<Rule, RuleDto, Guid, RuleGetListInput, RuleCreateDto, RuleUpdateDto>,
    IRuleAppService
{
    protected override string GetPolicyName { get; set; } = AlertSystemPermissions.Rule.Default;
    protected override string GetListPolicyName { get; set; } = AlertSystemPermissions.Rule.Default;
    protected override string CreatePolicyName { get; set; } = AlertSystemPermissions.Rule.Create;
    protected override string UpdatePolicyName { get; set; } = AlertSystemPermissions.Rule.Update;
    protected override string DeletePolicyName { get; set; } = AlertSystemPermissions.Rule.Delete;

    private readonly IRuleRepository _repository;

    public RuleAppService(IRuleRepository repository) : base(repository)
    {
        _repository = repository;
    }
    protected override async Task<IQueryable<Rule>> CreateFilteredQueryAsync(RuleGetListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.FromRegex.IsNullOrWhiteSpace(), x => x.FromRegex.Contains(input.FromRegex))
            .WhereIf(!input.TitleRegex.IsNullOrWhiteSpace(), x => x.TitleRegex.Contains(input.TitleRegex))
            .WhereIf(!input.BodyRegex.IsNullOrWhiteSpace(), x => x.BodyRegex.Contains(input.BodyRegex))
            .WhereIf(input.AnyCondition != null, x => x.AnyCondition == input.AnyCondition)
            .WhereIf(!input.AlertTitle.IsNullOrWhiteSpace(), x => x.AlertTitle.Contains(input.AlertTitle))
            .WhereIf(!input.AlertBody.IsNullOrWhiteSpace(), x => x.AlertBody.Contains(input.AlertBody))
            .WhereIf(input.AlertDepartmentId != null, x => x.AlertDepartmentId == input.AlertDepartmentId)
            .WhereIf(input.AlertStatusId != null, x => x.AlertStatusId == input.AlertStatusId)
            .WhereIf(input.AlertLevelId != null, x => x.AlertLevelId == input.AlertLevelId)
            .WhereIf(input.TriggerCount != null, x => x.TriggerCount >= input.TriggerCount)
            .WhereIf(input.TriggerWindowDuration != null, x => x.TriggerWindowDuration == input.TriggerWindowDuration)
            .WhereIf(input.TriggersRequired != null, x => x.TriggersRequired == input.TriggersRequired)
            .WhereIf(input.TriggerTimestamp != null, x => x.TriggerTimestamp.Value.Date == input.TriggerTimestamp.Value.Date)
            .WhereIf(input.Active != null, x => x.Active == input.Active);
    }
    public async Task<PagedResultDto<LookupDto<Guid>>> GetLookupAsync(LookupRequestDto input)
    {
        var list = await _repository.GetLookupListAsync(input.SkipCount, input.MaxResultCount, input.IncludeInactive);

        int totalCount = await (input.IncludeInactive ? _repository.CountAsync() : _repository.CountAsync(p => p.Active));

        return new PagedResultDto<LookupDto<Guid>>(
            totalCount,
            ObjectMapper.Map<List<Rule>, List<LookupDto<Guid>>>(list)
        );
    }
    public async Task<PagedResultDto<RuleNavigationDto>> GetNavigationListAsync(RuleGetListInput input)
    {
        var query = await _repository.GetNavigationList();

        query = query
            .WhereIf(!input.FromRegex.IsNullOrWhiteSpace(), x => x.Rule.FromRegex.Contains(input.FromRegex))
            .WhereIf(!input.TitleRegex.IsNullOrWhiteSpace(), x => x.Rule.TitleRegex.Contains(input.TitleRegex))
            .WhereIf(!input.BodyRegex.IsNullOrWhiteSpace(), x => x.Rule.BodyRegex.Contains(input.BodyRegex))
            .WhereIf(input.AnyCondition != null, x => x.Rule.AnyCondition == input.AnyCondition)
            .WhereIf(input.AlertDepartmentId != null, x => x.Rule.AlertDepartmentId == input.AlertDepartmentId)
            .WhereIf(input.AlertStatusId != null, x => x.Rule.AlertStatusId == input.AlertStatusId)
            .WhereIf(input.AlertLevelId != null, x => x.Rule.AlertLevelId == input.AlertLevelId)
            .WhereIf(!input.AlertTitle.IsNullOrWhiteSpace(), x => x.Rule.AlertTitle.Contains(input.AlertTitle))
            .WhereIf(!input.AlertBody.IsNullOrWhiteSpace(), x => x.Rule.AlertBody.Contains(input.AlertBody))
            .WhereIf(input.TriggerCount != null, x => x.Rule.TriggerCount >= input.TriggerCount)
            .WhereIf(input.TriggerWindowDuration != null, x => x.Rule.TriggerWindowDuration >= input.TriggerWindowDuration)
            .WhereIf(input.TriggersRequired != null, x => x.Rule.TriggersRequired == input.TriggersRequired)
            .WhereIf(input.TriggerTimestamp != null, x => x.Rule.TriggerTimestamp.Value.Date == input.TriggerTimestamp.Value.Date)
            .WhereIf(input.Active != null, x => x.Rule.Active == input.Active);

        if (!input.Sorting.IsNullOrWhiteSpace())
        {
            query = query.OrderBy(input.Sorting);
        }
        else
        {
            query = query.OrderBy(x => x.Rule.AlertTitle);
        }

        var totalCount = await query.CountAsync();

        var ruleNavigations = await query
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .ToListAsync();

        return new PagedResultDto<RuleNavigationDto>(
            totalCount,
            ObjectMapper.Map<List<RuleNavigation>, List<RuleNavigationDto>>(ruleNavigations)
        );
    }
}

