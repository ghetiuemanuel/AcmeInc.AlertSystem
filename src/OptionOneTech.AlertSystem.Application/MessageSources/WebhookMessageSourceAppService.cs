using System;
using OptionOneTech.AlertSystem.Permissions;
using OptionOneTech.AlertSystem.MessageSources.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.MessageSources;


public class WebhookMessageSourceAppService : CrudAppService<WebhookMessageSource, WebhookMessageSourceDto, Guid, PagedAndSortedResultRequestDto, CreateWebhookMessageSourceDto, UpdateWebhookMessageSourceDto>,
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

}
