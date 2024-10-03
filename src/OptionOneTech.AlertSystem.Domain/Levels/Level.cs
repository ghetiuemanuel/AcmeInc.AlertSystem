using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace OptionOneTech.AlertSystem.Levels
{
    public class Level : FullAuditedEntity<Guid>
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        public bool Active { get; set; }

    protected Level()
    {
    }

    public Level(
        Guid id,
        string name,
        string description,
        bool active
    ) : base(id)
    {
        Name = name;
        Description = description;
        Active = active;
    }
    }
}
