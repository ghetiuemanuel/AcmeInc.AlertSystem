using System;
using Volo.Abp.Application.Dtos;

namespace AcmeInc.AlertSystem.MessageSources.Dtos;

[Serializable]
public class WebhookMessageSourceDto : FullAuditedEntityDto<Guid>
{
    public string Title { get; set; }

    public string From { get; set; }

    public string Body { get; set; }

    public bool Active { get; set; }
}