using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace OptionOneTech.AlertSystem.Alerts.Dtos;

[Serializable]
public class AlertGetListInput : PagedAndSortedResultRequestDto
{
    public string? Title { get; set; }

    public string? Body { get; set; }

    public Guid? MessageId { get; set; }

    public Guid? RuleId { get; set; }

    public Guid? DepartmentId { get; set; }

    public Guid? StatusId { get; set; }

    public Guid? LevelId { get; set; }
}