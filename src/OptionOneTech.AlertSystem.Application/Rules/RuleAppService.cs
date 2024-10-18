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
        // TODO: AbpHelper generated
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
            ;
    }
    public async Task<PagedResultDto<LookupDto<Guid>>> GetLookupAsync(PagedResultRequestDto input)
    {
        var list = await _repository.GetLookupListAsync(input.SkipCount, input.MaxResultCount);

        var totalCount = await _repository.CountAsync();

        return new PagedResultDto<LookupDto<Guid>>(
           totalCount,
           ObjectMapper.Map<List<Rule>, List<LookupDto<Guid>>>(list)
        );
    }
}
