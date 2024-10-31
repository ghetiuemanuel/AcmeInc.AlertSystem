using System;
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
            Timer.Period = 10000;
        }
        protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
        {
            _logger.LogInformation("Starting to process messages in AlertBackgroundWorker.");
            try
            {
                var messageRepository = workerContext.ServiceProvider.GetRequiredService<IMessageRepository>();
                var ruleRepository = workerContext.ServiceProvider.GetRequiredService<IRuleRepository>();
                var alertRepository = workerContext.ServiceProvider.GetRequiredService<IAlertRepository>();
                var guidGenerator = workerContext.ServiceProvider.GetRequiredService<IGuidGenerator>();


                var messages = await messageRepository.GetAllMessagesAsync();
                _logger.LogInformation($"Found {messages.Count} messages to evaluate.");

                var rules = await ruleRepository.GetActiveRulesAsync();
                _logger.LogInformation($"Found {rules.Count} active rules.");

                foreach (var message in messages)
                {
                    _logger.LogInformation($"Message found: {message.Title}, From: {message.From}, Body: {message.Body}");

                    foreach (var rule in rules)
                    {
                        _logger.LogInformation($"Active rule found: {rule.AlertTitle}, FromRegex: {rule.FromRegex}, TitleRegex: {rule.TitleRegex}, BodyRegex: {rule.BodyRegex}");
                        if (EvaluateRule(message, rule))
                        {
                            if (LogicOfCreateAlert(message, rule))
                            {
                                var existingAlert = await alertRepository.GetExistingAlertAsync(message.Id, rule.Id);
                                if (existingAlert == null)
                                {
                                    await CreateAlert(message, rule, alertRepository, guidGenerator);
                                }
                            }
                            await ruleRepository.UpdateAsync(rule);
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

            _logger.LogInformation($"Evaluating rule for message '{message.Title}' with rule '{rule.AlertTitle}'.");

            bool fromMatches = System.Text.RegularExpressions.Regex.IsMatch(message.From, rule.FromRegex);
            bool titleMatches = System.Text.RegularExpressions.Regex.IsMatch(message.Title, rule.TitleRegex);
            bool bodyMatches = System.Text.RegularExpressions.Regex.IsMatch(message.Body, rule.BodyRegex);

            _logger.LogInformation($"From matches: {fromMatches}, Title matches: {titleMatches}, Body matches: {bodyMatches}");

            if (rule.AnyCondition)
            {
                return fromMatches || titleMatches || bodyMatches;
            }
            else
            {
                return fromMatches && titleMatches && bodyMatches;
            }
        }
        private bool LogicOfCreateAlert(Message message, Rule rule)
        {
            var currentTime = DateTime.Now;

            if (rule.TriggerTimestamp == null || (currentTime - rule.TriggerTimestamp.Value).TotalSeconds > rule.TriggerWindowDuration)
            {
                rule.TriggerCount = 0;
            }

            rule.TriggerTimestamp = currentTime;
            rule.TriggerCount++;


            if (rule.TriggerCount >= rule.TriggersRequired)
            {
                return true; 
            }

            return false; 
        }

        private async Task CreateAlert(Message message, Rule rule, IAlertRepository alertRepository, IGuidGenerator guidGenerator)
        {
            _logger.LogInformation($"Creating alert for message '{message.Title}' with rule '{rule.AlertTitle}'.");

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

            _logger.LogInformation("Alert created!!!");
            await alertRepository.InsertAsync(alert);
        }
    }
}
