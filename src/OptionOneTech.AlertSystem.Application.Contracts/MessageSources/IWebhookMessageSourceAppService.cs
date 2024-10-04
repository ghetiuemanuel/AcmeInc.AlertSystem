using System;
using OptionOneTech.AlertSystem.MessageSources.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.MessageSources;


public interface IWebhookMessageSourceAppService :
    ICrudAppService< 
                WebhookMessageSourceDto, 
        Guid, 
        PagedAndSortedResultRequestDto,
        CreateWebhookMessageSourceDto,
        UpdateWebhookMessageSourceDto>
{

}