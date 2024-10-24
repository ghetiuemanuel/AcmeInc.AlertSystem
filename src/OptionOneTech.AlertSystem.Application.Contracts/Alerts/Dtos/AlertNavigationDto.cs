using OptionOneTech.AlertSystem.Departments.Dtos;
using OptionOneTech.AlertSystem.Levels.Dtos;
using OptionOneTech.AlertSystem.Messages.Dtos;
using OptionOneTech.AlertSystem.Rules.Dtos;
using OptionOneTech.AlertSystem.Statuses.Dtos;
using static OptionOneTech.AlertSystem.Permissions.AlertSystemPermissions;

namespace OptionOneTech.AlertSystem.Alerts.Dtos
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
