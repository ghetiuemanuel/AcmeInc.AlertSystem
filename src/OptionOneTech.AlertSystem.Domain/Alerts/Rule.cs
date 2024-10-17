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
        Guid alertLevelId
    ) : base(id)
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
    }
    }
}
