using System;
using OptionOneTech.AlertSystem.Permissions;
using OptionOneTech.AlertSystem.MessageSources.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using OptionOneTech.AlertSystem.Lookup;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.MessageSources;


public class WebhookMessageSourceAppService : CrudAppService<WebhookMessageSource, WebhookMessageSourceDto, Guid, WebhookMessageSourceGetListInput, CreateWebhookMessageSourceDto, UpdateWebhookMessageSourceDto>,
    IWebhookMessageSourceAppService
{
    protected override string GetPolicyName { get; set; } = AlertSystemPermissions.WebhookMessageSource.Default;
    protected override string GetListPolicyName { get; set; } = AlertSystemPermissions.WebhookMessageSource.Default;
    protected override string CreatePolicyName { get; set; } = AlertSystemPermissions.WebhookMessageSource.Create;
    protected override string UpdatePolicyName { get; set; } = AlertSystemPermissions.WebhookMessageSource.Update;
    protected override string DeletePolicyName { get; set; } = AlertSystemPermissions.WebhookMessageSource.Delete;

    private readonly IWebhookMessageSourceRepository _repository;

    public WebhookMessageSourceAppService(IWebhookMessageSourceRepository repository) : base(repository)
    {
        _repository = repository;
    }
    protected override async Task<IQueryable<WebhookMessageSource>> CreateFilteredQueryAsync(WebhookMessageSourceGetListInput input)
    {
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Title.IsNullOrWhiteSpace(), x => x.Title.Contains(input.Title))
            .WhereIf(!input.From.IsNullOrWhiteSpace(), x => x.From.Contains(input.From))
            .WhereIf(!input.Body.IsNullOrWhiteSpace(), x => x.Body.Contains(input.Body))
            .WhereIf(input.Active != null, x => x.Active == input.Active);


    }
    public async Task<PagedResultDto<LookupDto<Guid>>> GetLookupAsync(LookupRequestDto input)
    {
        var list = await _repository.GetLookupListAsync(input.SkipCount, input.MaxResultCount, input.IncludeInactive);

        int totalCount = await _repository.CountAsync(s => input.IncludeInactive || s.Active);

        return new PagedResultDto<LookupDto<Guid>>(
           totalCount,
           ObjectMapper.Map<List<WebhookMessageSource>, List<LookupDto<Guid>>>(list)
        );

    }

}
