using OptionOneTech.AlertSystem.Departments;
using OptionOneTech.AlertSystem.Levels;
using OptionOneTech.AlertSystem.Rules;
using OptionOneTech.AlertSystem.Statuses;

namespace OptionOneTech.AlertSystem.Alerts
{
    public class RuleNavigation
    {
        public Rule Rule { get; set; }
        public Department Department { get; set; }
        public Level Level { get; set; }    
        public Status Status { get; set; }
    }
}
