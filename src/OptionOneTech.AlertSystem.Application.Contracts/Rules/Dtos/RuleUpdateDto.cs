using System;

namespace OptionOneTech.AlertSystem.Rules.Dtos;

[Serializable]
public class RuleUpdateDto
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
    public int? TriggerWindowDuration { get; set; }
    public int? TriggersRequired { get; set; }
    public DateTime? TriggerTimestamp { get; set; }
    public bool Active { get; set; }
    public string NotificationEmails { get; set; }

}