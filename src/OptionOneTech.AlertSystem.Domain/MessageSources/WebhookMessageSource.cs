using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace OptionOneTech.AlertSystem.MessageSources
{
    public class WebhookMessageSource : FullAuditedEntity<Guid>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string Body { get; set; }

    protected WebhookMessageSource()
    {
    }

    public WebhookMessageSource(
        Guid id,
        string title,
        string from,
        string body
    ) : base(id)
    {
        Title = title;
        From = from;
        Body = body;
    }
    }
}