using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Controllers;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.MessageSources;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Guids;
using Message = OptionOneTech.AlertSystem.Messages.Message;

namespace OptionOneTech.AlertSystem.Webhooks
{
    [Route("webhook")]
    public class WebhookController : AlertSystemController
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IWebhookMessageSourceRepository _webhookMessageSourceRepository;
        private readonly IGuidGenerator _guidGenerator;

        public WebhookController(IMessageRepository messageRepository, IWebhookMessageSourceRepository webhookMessageSourceRepository, IGuidGenerator guidGenerator)
        {
            _messageRepository = messageRepository;
            _webhookMessageSourceRepository = webhookMessageSourceRepository;
            _guidGenerator = guidGenerator;
        }

        [HttpPost("{id}")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Handle(Guid id)
        {
            try
            {
                Guid messageId = _guidGenerator.Create();
               
                var webhookData = await _webhookMessageSourceRepository.GetAsync(messageId);

                var message = new Message(
                    id: messageId,
                    title: webhookData.Title,
                    from: webhookData.From,
                    sourceId: messageId,                    
                    sourceType: SourceType.Webhook,
                    body: webhookData.Body,
                    processedAt: null
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
