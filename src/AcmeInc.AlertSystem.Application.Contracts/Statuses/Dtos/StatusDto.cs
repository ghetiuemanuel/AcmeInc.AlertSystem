using System;
using Volo.Abp.Application.Dtos;

namespace AcmeInc.AlertSystem.Statuses.Dtos;

[Serializable]
public class StatusDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public bool Active { get; set; }
}