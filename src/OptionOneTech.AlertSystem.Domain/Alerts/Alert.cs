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
    }
}
