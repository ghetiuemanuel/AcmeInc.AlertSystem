using AcmeInc.AlertSystem.Departments;
using AcmeInc.AlertSystem.Levels;
using AcmeInc.AlertSystem.Rules;
using AcmeInc.AlertSystem.Statuses;

namespace AcmeInc.AlertSystem.Alerts
{
    public class RuleNavigation
    {
        public Rule Rule { get; set; }
        public Department Department { get; set; }
        public Level Level { get; set; }    
        public Status Status { get; set; }
    }
}
