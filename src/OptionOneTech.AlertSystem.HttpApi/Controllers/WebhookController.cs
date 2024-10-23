using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Controllers;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.MessageSources;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Guids;

namespace OptionOneTech.AlertSystem.Webhooks
{
    [Route("webhook")]
    public class WebhookController : AlertSystemController
    {
        private readonly IMessageRepository _messageRepository;

        private readonly IWebhookMessageSourceRepository _webhookMessageSourceRepository;
        public WebhookController(IMessageRepository messageRepository, IWebhookMessageSourceRepository webhookMessageSourceRepository, IGuidGenerator guidGenerator)
        {
            _messageRepository = messageRepository;
            _webhookMessageSourceRepository = webhookMessageSourceRepository;
        }

        [HttpPost("{id}")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Handle(Guid id)
        {
            try
            {
                var webhookData = await _webhookMessageSourceRepository.GetAsync(id);

                var message = new Message(
                    id: id,
                    title: webhookData.Title,
                    from: webhookData.From,
                    sourceId: id,                    
                    sourceType: SourceType.Webhook,
                    body: webhookData.Body,
                    processedAt: DateTime.Now
                );

                await _messageRepository.InsertAsync(message, autoSave: true);
                return Ok("Message created successfully");
            }
            catch (EntityNotFoundException)
            {
                return BadRequest("Webhook entity not found");
            }
        }
    }
}
