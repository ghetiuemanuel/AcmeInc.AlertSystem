using System;
using System.ComponentModel.DataAnnotations;
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

        public bool Active { get; set; }

    protected WebhookMessageSource()
    {
    }

    public WebhookMessageSource(
            Guid id,
            string title,
            string from,
            string body,
            bool active = true
        ) : base(id)
        {
            Title = title;
            From = from;
            Body = body;
            Active = active;
        }
    }
}
