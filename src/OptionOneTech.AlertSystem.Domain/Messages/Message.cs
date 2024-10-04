using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.Messages;
using Volo.Abp.Domain.Entities.Auditing;
using OptionOneTech.AlertSystem;

namespace OptionOneTech.AlertSystem.Messages
{
    public class Message : FullAuditedEntity<Guid>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public Guid SourceId { get; set; }

        [Required]
        public SourceType SourceType { get; set; }

        [Required]
        public string Body { get; set; }

    protected Message()
    {
    }

    public Message(
        Guid id,
        string title,
        string from,
        Guid sourceId,
        SourceType sourceType,
        string body
    ) : base(id)
    {
        Title = title;
        From = from;
        SourceId = sourceId;
        SourceType = sourceType;
        Body = body;
    }
    }
}

