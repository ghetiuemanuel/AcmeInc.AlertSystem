using AcmeInc.AlertSystem.MessageSources.Dtos;

namespace AcmeInc.AlertSystem.Messages.Dtos
{
    public class MessageNavigationDto
    {
        public MessageDto? Message { get; set; }
        public WebhookMessageSourceDto? WebhookMessageSource { get; set; }
        public EmailMessageSourceDto? EmailMessageSource { get; set; }
    }
}
