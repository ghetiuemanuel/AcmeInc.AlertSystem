using System;
using Volo.Abp.Application.Dtos;

namespace OptionOneTech.AlertSystem.Levels.Dtos;

[Serializable]
public class LevelDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public bool Active { get; set; }
}