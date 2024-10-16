﻿using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Messages.Dtos;
using OptionOneTech.AlertSystem.MessageSources;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> ReceiveWebhook(Guid id)
        {
            try
            {
                var webhookData = await _webhookMessageSourceAppService.GetAsync(id);

                if (webhookData == null)
                {
                    throw new InvalidOperationException("Bad request!");
                }

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
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: Bad request!");
            }
        }
    }
}
