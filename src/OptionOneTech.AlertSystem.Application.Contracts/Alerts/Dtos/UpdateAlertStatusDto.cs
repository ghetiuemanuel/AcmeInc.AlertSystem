using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionOneTech.AlertSystem.Alerts.Dtos
{
    public class UpdateAlertStatusDto
    {
        public Guid AlertId { get; set; }
        public Guid StatusId { get; set; }
    }
}
