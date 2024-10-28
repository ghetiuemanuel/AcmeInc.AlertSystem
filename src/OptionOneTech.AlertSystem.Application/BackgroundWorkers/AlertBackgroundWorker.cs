﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Rules;
using OptionOneTech.AlertSystem.Alerts;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Threading;
using Volo.Abp.Guids;

namespace OptionOneTech.AlertSystem.BackgroundWorkers
{
    public class AlertBackgroundWorker : AsyncPeriodicBackgroundWorkerBase, ITransientDependency
    {
        private readonly ILogger<AlertBackgroundWorker> _logger;

        public AlertBackgroundWorker(
            AbpAsyncTimer timer,
            IServiceScopeFactory serviceScopeFactory,
            ILogger<AlertBackgroundWorker> logger)
            : base(timer, serviceScopeFactory)
        {
            _logger = logger;
            Timer.Period = (int)TimeSpan.FromSeconds(10).TotalMilliseconds;
        }

        protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
        {
            _logger.LogInformation("Starting to process messages in AlertBackgroundWorker.");
            try
            {
                using (var scope = workerContext.ServiceProvider.CreateScope())
                {
                    var messageRepository = scope.ServiceProvider.GetRequiredService<IMessageRepository>();
                    var ruleRepository = scope.ServiceProvider.GetRequiredService<IRuleRepository>();
                    var alertRepository = scope.ServiceProvider.GetRequiredService<IAlertRepository>();
                    var guidGenerator = workerContext.ServiceProvider.GetRequiredService<IGuidGenerator>();
                    var messages = await messageRepository.GetUnprocessedMessagesAsync();

                    _logger.LogInformation($"Found {messages.Count} unprocessed messages.");

                    var rules = await ruleRepository.GetActiveRulesAsync();
                    _logger.LogInformation($"Found {rules.Count} active rules.");

                    foreach (var message in messages)
                    {
                        foreach (var rule in rules)
                        {
                            try
                            {
                                if (EvaluateRule(message, rule))
                                {
                                    _logger.LogInformation($"Message '{message.Title}' matched rule '{rule.AlertTitle}'.");
                                    Guid alertId = guidGenerator.Create();
                                    var alert = new Alert(
                                        id: alertId,
                                        rule.AlertTitle,
                                        rule.AlertBody,
                                        message.Id,
                                        rule.Id,
                                        rule.AlertDepartmentId,
                                        rule.AlertStatusId,
                                        rule.AlertLevelId
                                    );

                                    await alertRepository.InsertAsync(alert);
                                    _logger.LogInformation($"Alert created for message '{message.Title}'.");

                                    message.ProcessedAt = DateTime.Now;
                                    await messageRepository.UpdateAsync(message);
                                    _logger.LogInformation($"Message '{message.Title}' marked as processed.");

                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, $"Error processing message '{message.Title}' with rule '{rule.AlertTitle}'.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing messages in AlertBackgroundWorker.");
            }
        }
        private bool EvaluateRule(Message message, Rule rule)
        {
            bool fromMatches = System.Text.RegularExpressions.Regex.IsMatch(message.From, rule.FromRegex);
            bool titleMatches = System.Text.RegularExpressions.Regex.IsMatch(message.Title, rule.TitleRegex);
            bool bodyMatches = System.Text.RegularExpressions.Regex.IsMatch(message.Body, rule.BodyRegex);

            return rule.AnyCondition ? fromMatches || titleMatches || bodyMatches : fromMatches && titleMatches && bodyMatches;
        }
    }
}
