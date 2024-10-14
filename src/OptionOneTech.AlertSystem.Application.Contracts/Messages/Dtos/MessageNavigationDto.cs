using OptionOneTech.AlertSystem.MessageSources.Dtos;

namespace OptionOneTech.AlertSystem.Messages.Dtos
{
    public class MessageNavigationDto
    {
        public MessageDto? Message { get; set; }
        public WebhookMessageSourceDto? WebhookMessageSource { get; set; }
    }
}
