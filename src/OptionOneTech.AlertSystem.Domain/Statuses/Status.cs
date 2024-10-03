using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace OptionOneTech.AlertSystem.Statuses
{
    public class Status : FullAuditedEntity<Guid>
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
