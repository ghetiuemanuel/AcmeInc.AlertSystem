using System;
using Volo.Abp.Application.Dtos;

namespace OptionOneTech.AlertSystem.Departments.Dtos;

[Serializable]
public class DepartmentDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public bool Active { get; set; }
}