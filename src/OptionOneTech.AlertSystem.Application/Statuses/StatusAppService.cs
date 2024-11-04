using System;
using OptionOneTech.AlertSystem.Lookup;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.Permissions;
using OptionOneTech.AlertSystem.Statuses.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Statuses;

public class StatusAppService : CrudAppService<Status, StatusDto, Guid, StatusGetListInput, CreateStatusDto, UpdateStatusDto>,
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
    protected override async Task<IQueryable<Status>> CreateFilteredQueryAsync(StatusGetListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(!input.Description.IsNullOrWhiteSpace(), x => x.Description.Contains(input.Description))
            .WhereIf(input.Active != null, x => x.Active == input.Active);
    }
    public async Task<PagedResultDto<LookupDto<Guid>>> GetLookupAsync(PagedResultRequestDto input)
    {
        var statuses = await _repository.GetLookupListAsync(input.SkipCount, input.MaxResultCount);

        var totalCount = await _repository.CountAsync(p => p.Active);

        return new PagedResultDto<LookupDto<Guid>>(
          totalCount,
          ObjectMapper.Map<List<Status>, List<LookupDto<Guid>>>(statuses)
        );
    }
}
