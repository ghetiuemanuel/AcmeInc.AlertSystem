using System;
using Volo.Abp.Application.Dtos;

namespace OptionOneTech.AlertSystem.Rules.Dtos;

[Serializable]
public class RuleDto : FullAuditedEntityDto<Guid>
{
    public string FromRegex { get; set; }

    public string TitleRegex { get; set; }

    public string BodyRegex { get; set; }

    public bool AnyCondition { get; set; }

    public string AlertTitle { get; set; }

    public string AlertBody { get; set; }

    public Guid AlertDepartmentId { get; set; }

    public Guid AlertStatusId { get; set; }

    public Guid AlertLevelId { get; set; }
    public int TriggerCount { get; set; }
    public int TriggerWindowDuration { get; set; }
    public int TriggersRequired { get; set; }
    public DateTime? TriggerTimestamp { get; set; }
    public bool Active { get; set; }
}