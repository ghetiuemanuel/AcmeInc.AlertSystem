using OptionOneTech.AlertSystem.Departments.Dtos;
using OptionOneTech.AlertSystem.Levels.Dtos;
using OptionOneTech.AlertSystem.Statuses.Dtos;

namespace OptionOneTech.AlertSystem.Rules.Dtos
{
    public class RuleNavigationDto
    {
        public RuleDto? Rule { get; set; }
        public DepartmentDto? Department { get; set; }
        public LevelDto? Level { get; set; }
        public StatusDto? Status { get; set; }
    }
}
