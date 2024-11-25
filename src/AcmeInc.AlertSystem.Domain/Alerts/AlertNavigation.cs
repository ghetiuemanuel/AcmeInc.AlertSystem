using AcmeInc.AlertSystem.Departments;
using AcmeInc.AlertSystem.Levels;
using AcmeInc.AlertSystem.Messages;
using AcmeInc.AlertSystem.Rules;
using AcmeInc.AlertSystem.Statuses;

namespace AcmeInc.AlertSystem.Alerts
{
    public class AlertNavigation
    {
        public Alert Alert { get; set; }
        public Message Message { get; set; }
        public Rule Rule { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }
        public Level Level { get; set; }
    }
}
