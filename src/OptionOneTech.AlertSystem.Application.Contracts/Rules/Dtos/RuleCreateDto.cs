using System;

namespace OptionOneTech.AlertSystem.Rules.Dtos;

[Serializable]
public class RuleCreateDto
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
}