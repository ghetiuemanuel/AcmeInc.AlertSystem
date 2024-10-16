using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Messages.Dtos;
using System;
using System.Threading.Tasks;

namespace OptionOneTech.AlertSystem.Webhooks
{
    [Route("webhook")]
    public class WebhookController : Controller
    {
        private readonly IMessageAppService _messageAppService;

        public WebhookController(IMessageAppService messageAppService)
        {
            _messageAppService = messageAppService;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> ReceiveWebhook(Guid id, [FromBody] WebhookPayload payload)
        {
            if (payload == null)
            {
                return BadRequest("Payload is null");
            }

            var messageDto = new CreateMessageDto
            {
                SourceId = id, 
                Body = payload.Body,
                From = payload.From,
                Title = payload.Title,
                SourceType = SourceType.Webhook
            };

            await _messageAppService.CreateAsync(messageDto);

            return Ok("Message created successfully");
        }
    }
    public class WebhookPayload
    {
        public string Body { get; set; }
        public string From { get; set; }
        public string Title { get; set; }
    }
}
