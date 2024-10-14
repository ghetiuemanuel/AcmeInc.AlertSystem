using WebhookMessageSource = OptionOneTech.AlertSystem.MessageSources.WebhookMessageSource;

namespace OptionOneTech.AlertSystem.Messages
{
    public class MessageNavigation
    {
        public Message Message { get; set; }
        public WebhookMessageSource WebhookMessageSource { get; set; }
    }
}
