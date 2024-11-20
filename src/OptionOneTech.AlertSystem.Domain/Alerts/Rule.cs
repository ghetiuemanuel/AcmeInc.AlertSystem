using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace OptionOneTech.AlertSystem.Rules
{
    public class Rule : FullAuditedEntity<Guid>
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
        public string NotificationEmails { get; set; }


    protected Rule()
    {
    }

    public Rule(
            Guid id,
            string fromRegex,
            string titleRegex,
            string bodyRegex,
            bool anyCondition,
            string alertTitle,
            string alertBody,
            Guid alertDepartmentId,
            Guid alertStatusId,     
            Guid alertLevelId,
            int triggerCount,
            int triggerWindowDuration,
            int triggersRequired,
            DateTime? triggerTimestamp,
            bool Active,
            string notificationEmails
        )    : base(id)
        {
            FromRegex = fromRegex;
            TitleRegex = titleRegex;
            BodyRegex = bodyRegex;
            AnyCondition = anyCondition;
            AlertTitle = alertTitle;
            AlertBody = alertBody;
            AlertDepartmentId = alertDepartmentId;
            AlertStatusId = alertStatusId;
            AlertLevelId = alertLevelId; 
            TriggerCount = triggerCount;
            TriggerWindowDuration = triggerWindowDuration;
            TriggersRequired = triggersRequired;
            TriggerTimestamp = triggerTimestamp;
            Active = Active;
            NotificationEmails = notificationEmails;
        }
    }
}
