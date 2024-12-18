using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace AcmeInc.AlertSystem.Statuses
{
    public class Status : FullAuditedEntity<Guid>
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        public bool Active { get; set; }

        protected Status()
        {
        }

        public Status(
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
