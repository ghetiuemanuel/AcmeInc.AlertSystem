using System;
using Volo.Abp.Application.Dtos;

namespace OptionOneTech.AlertSystem.Messages.Dtos;

[Serializable]
public class MessageDto : FullAuditedEntityDto<Guid>
{
    public string Title { get; set; }

    public string From { get; set; }

    public Guid SourceId { get; set; }

    public SourceType SourceType { get; set; }

    public string Body { get; set; }
}