using AcmeInc.AlertSystem.MessageSources;
using WebhookMessageSource = AcmeInc.AlertSystem.MessageSources.WebhookMessageSource;

namespace AcmeInc.AlertSystem.Messages
{
    public class MessageNavigation
    {
        public Message Message { get; set; }
        public WebhookMessageSource WebhookMessageSource { get; set; }
        public EmailMessageSource EmailMessageSource { get; set; }
    }
}
