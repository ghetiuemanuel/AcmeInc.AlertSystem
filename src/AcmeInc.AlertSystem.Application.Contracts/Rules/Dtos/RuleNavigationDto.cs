using AcmeInc.AlertSystem.Departments.Dtos;
using AcmeInc.AlertSystem.Levels.Dtos;
using AcmeInc.AlertSystem.Statuses.Dtos;

namespace AcmeInc.AlertSystem.Rules.Dtos
{
    public class RuleNavigationDto
    {
        public RuleDto? Rule { get; set; }
        public DepartmentDto? Department { get; set; }
        public LevelDto? Level { get; set; }
        public StatusDto? Status { get; set; }
    }
}
