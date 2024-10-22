using OptionOneTech.AlertSystem.MessageSources;
using WebhookMessageSource = OptionOneTech.AlertSystem.MessageSources.WebhookMessageSource;

namespace OptionOneTech.AlertSystem.Messages
{
    public class MessageNavigation
    {
        public Message Message { get; set; }
        public WebhookMessageSource WebhookMessageSource { get; set; }
        public EmailMessageSource EmailMessageSource { get; set; }
    }
}
