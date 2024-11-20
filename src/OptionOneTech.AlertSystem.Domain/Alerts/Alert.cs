using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace OptionOneTech.AlertSystem.Alerts
{
    public class Alert : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public Guid MessageId { get; set; }
        public Guid RuleId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid StatusId { get; set; }
        public Guid LevelId { get; set; }
        public bool NotificationSent { get; set; }

        protected Alert()
    {
    }

    public Alert(
        Guid id,
        string title,
        string body,
        Guid messageId,
        Guid ruleId,
        Guid departmentId,
        Guid statusId,
        Guid levelId,
        bool notificationSent
    ) : base(id)
    {
        Title = title;
        Body = body;
        MessageId = messageId;
        RuleId = ruleId;
        DepartmentId = departmentId;
        StatusId = statusId;
        LevelId = levelId;
        NotificationSent = notificationSent;
    }
    }
}
