using System;
using OptionOneTech.AlertSystem.Permissions;
using OptionOneTech.AlertSystem.Levels.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using OptionOneTech.AlertSystem.Lookup;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Levels;


public class LevelAppService : CrudAppService<Level, LevelDto, Guid, LevelGetListInput, CreateLevelDto, UpdateLevelDto>,
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
    protected override async Task<IQueryable<Level>> CreateFilteredQueryAsync(LevelGetListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(!input.Description.IsNullOrWhiteSpace(), x => x.Description.Contains(input.Description))
            .WhereIf(input.Active != null, x => x.Active == input.Active);
    }

    // implement GetLookupAsync from ILookupAppService<Guid>
    public async Task<PagedResultDto<LookupDto<Guid>>> GetLookupAsync(PagedAndSortedResultRequestDto input)
    {
        // get the list of levels using the repository
        var levels = await _repository.GetLookupListAsync(input.SkipCount, input.MaxResultCount);

        // get total number of levels
        var totalCount = await _repository.CountAsync(p => p.Active);

        // mapping levels to LookupDto and return PagedResultDto
        return new PagedResultDto<LookupDto<Guid>>(
           totalCount,
           ObjectMapper.Map<List<Level>, List<LookupDto<Guid>>>(levels)
        );

    }

}
