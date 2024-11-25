using System;
using AcmeInc.AlertSystem.Lookup;
using AcmeInc.AlertSystem.MessageSources.Dtos;
using Volo.Abp.Application.Services;

namespace AcmeInc.AlertSystem.MessageSources;


public interface IWebhookMessageSourceAppService :
    ICrudAppService< 
        WebhookMessageSourceDto, 
        Guid,
        WebhookMessageSourceGetListInput,
        CreateWebhookMessageSourceDto,
        UpdateWebhookMessageSourceDto>,
        ILookupAppService<Guid>
{

}