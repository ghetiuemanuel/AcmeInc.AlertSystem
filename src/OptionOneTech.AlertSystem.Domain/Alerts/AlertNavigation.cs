using OptionOneTech.AlertSystem.Departments;
using OptionOneTech.AlertSystem.Levels;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Rules;
using OptionOneTech.AlertSystem.Statuses;

namespace OptionOneTech.AlertSystem.Alerts
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
