using System;

namespace OptionOneTech.AlertSystem.Alerts.Dtos;

[Serializable]
public class AlertCreateDto
{
    public string Title { get; set; }

    public string Body { get; set; }

    public Guid MessageId { get; set; }

    public Guid RuleId { get; set; }

    public Guid DepartmentId { get; set; }

    public Guid StatusId { get; set; }

    public Guid LevelId { get; set; }
    public bool NotificationSent { get; set; }

}