using AcmeInc.AlertSystem.Departments.Dtos;
using AcmeInc.AlertSystem.Levels.Dtos;
using AcmeInc.AlertSystem.Messages.Dtos;
using AcmeInc.AlertSystem.Rules.Dtos;
using AcmeInc.AlertSystem.Statuses.Dtos;
using System.Collections.Generic;

namespace AcmeInc.AlertSystem.Alerts.Dtos
{
    public class AlertNavigationDto
    {
        public AlertDto? Alert { get; set; }
        public MessageDto? Message { get; set; }
        public RuleDto? Rule { get; set; }
        public DepartmentDto? Department { get; set; }
        public StatusDto? Status { get; set; }
        public LevelDto? Level { get; set; }
    }
}
