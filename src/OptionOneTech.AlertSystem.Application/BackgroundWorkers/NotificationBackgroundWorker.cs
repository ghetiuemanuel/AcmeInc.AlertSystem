﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OptionOneTech.AlertSystem.Alerts;
using System.Threading.Tasks;
using System.Threading;
using System;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.Threading;
using System.Linq;

public class NotificationBackgroundWorker : AsyncPeriodicBackgroundWorkerBase, ITransientDependency
{
    private readonly ILogger<NotificationBackgroundWorker> _logger;

    public NotificationBackgroundWorker(AbpAsyncTimer timer, IServiceScopeFactory serviceScopeFactory, ILogger<NotificationBackgroundWorker> logger)
        : base(timer, serviceScopeFactory)
    {
        _logger = logger;
        Timer.Period = 10000;
    }

    protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
    {
        _logger.LogInformation("Periodic task started.");

        try
        {
            var emailSender = workerContext.ServiceProvider.GetRequiredService<IEmailSender>();
            var alertRepository = workerContext.ServiceProvider.GetRequiredService<IAlertRepository>();
            var ruleRepository = workerContext.ServiceProvider.GetRequiredService<IRuleRepository>();

            var alerts = await alertRepository.GetListAsync(alert => !alert.NotificationSent);

            if (alerts.Count == 0)
            {
                _logger.LogInformation("No pending alerts to process.");
                return;
            }

            foreach (var alert in alerts)
            {
                _logger.LogInformation($"Processing alert ID: {alert.Id}");
                await ProcessAlertAsync(alert, emailSender, ruleRepository, alertRepository, workerContext.CancellationToken);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred during periodic task execution.");
        }

        _logger.LogInformation("Periodic task finished.");
    }

    public async Task ProcessAlertAsync(Alert alert, IEmailSender emailSender, IRuleRepository ruleRepository, IAlertRepository alertRepository, CancellationToken cancellationToken)
    {
        try
        {
            var rule = await ruleRepository.GetAsync(alert.RuleId);

            if (string.IsNullOrEmpty(rule.NotificationEmails))
            {
                _logger.LogWarning($"No emails configured for rule ID: {rule.Id}");
                return;
            }

            var emails = rule.NotificationEmails
                .Split(',')
                .Select(email => email.Trim())
                .ToList();

            var subject = $"Alert Notification: {alert.Title}";
            var body = $"Dear User,\n\nWe would like to inform you about the following alert:\n\n" +
                       $"Alert Title: {alert.Title}\n" +
                       $"Alert Body: {alert.Body}\n\n" +
                       $"Please review the alert details and take necessary actions.";

            foreach (var email in emails)
            {
                cancellationToken.ThrowIfCancellationRequested();

                    _logger.LogInformation($"Sending email to: {email}");

                try
                {
                    await emailSender.SendAsync(
                        to: email,
                        subject: subject,
                        body: body,
                        isBodyHtml: false
                    );

                    _logger.LogInformation($"Email sent successfully to {email}.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error occurred while sending email to {email}.");
                }

                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogWarning("Cancellation requested. Stopping execution after sending email.");
                    return;
                }
            }

            alert.NotificationSent = true;
            await alertRepository.UpdateAsync(alert);

            _logger.LogInformation($"Notification sent successfully for alert ID: {alert.Id}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while processing alert ID: {alert.Id}");
        }
    }
}
