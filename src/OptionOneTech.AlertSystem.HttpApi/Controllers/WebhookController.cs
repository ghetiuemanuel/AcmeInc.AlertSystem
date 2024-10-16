using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Messages.Dtos;
using OptionOneTech.AlertSystem.MessageSources;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace OptionOneTech.AlertSystem.Webhooks
{
    [Route("webhook")]
    public class WebhookController : Controller
    {
        private readonly IMessageAppService _messageAppService;

        private readonly IWebhookMessageSourceAppService _webhookMessageSourceAppService;
        public WebhookController(IMessageAppService messageAppService, IWebhookMessageSourceAppService webhookMessageSourceAppService)
        {
            _messageAppService = messageAppService;
            _webhookMessageSourceAppService = webhookMessageSourceAppService;
        }

        [HttpPost("{id}")]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> ReceiveWebhook(Guid id)
        {
            try
            {
                var webhookData = await _webhookMessageSourceAppService.GetAsync(id);

                var messageDto = new CreateMessageDto
                {
                    SourceId = id,
                    Body = webhookData.Body,
                    Title = webhookData.Title,
                    From = webhookData.From,
                    SourceType = SourceType.Webhook
                };

                await _messageAppService.CreateAsync(messageDto);
                return Ok("Message created successfully");
            }
            catch (EntityNotFoundException)
            {
                return BadRequest("Webhook entity not found");
            }
        }
    }
}
