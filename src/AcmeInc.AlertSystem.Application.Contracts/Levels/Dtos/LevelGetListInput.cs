using System;
using Volo.Abp.Application.Dtos;

namespace AcmeInc.AlertSystem.Levels.Dtos;

[Serializable]
public class LevelGetListInput : PagedAndSortedResultRequestDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? Active { get; set; }
}