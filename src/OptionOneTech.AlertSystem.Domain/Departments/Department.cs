using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace OptionOneTech.AlertSystem.Departments
{
    public class Department : FullAuditedEntity<Guid>
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        public bool Active { get; set; }

        protected Department()
        {
        }

        public Department(
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
