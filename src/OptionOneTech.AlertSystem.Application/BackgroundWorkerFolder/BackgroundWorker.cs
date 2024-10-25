using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.DependencyInjection;
using OptionOneTech.AlertSystem.MessageSources;
using MailKit.Net.Imap;
using MailKit;
using MailKit.Search;
using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Threading;
using MimeKit;

public class EmailBackgroundWorker : AsyncPeriodicBackgroundWorkerBase, ITransientDependency
{
    private readonly ILogger<EmailBackgroundWorker> _logger;

    public EmailBackgroundWorker(
        AbpAsyncTimer timer,
        IServiceScopeFactory serviceScopeFactory,
        ILogger<EmailBackgroundWorker> logger)
        : base(timer, serviceScopeFactory)
    {
        Timer.Period = 10000;
        _logger = logger;
    }

    protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
    {
        _logger.LogInformation("Încep verificarea surselor de email...");

        var emailMessageSourceRepository = workerContext.ServiceProvider.GetRequiredService<IEmailMessageSourceRepository>();
        var emailSources = await emailMessageSourceRepository.GetListAsync(x => x.Active);

        foreach (var emailSource in emailSources)
        {
            _logger.LogInformation($"Verific emailurile pentru sursa: {emailSource.Hostname}");

            using (var client = new ImapClient())
            {
                try
                {
                    await client.ConnectAsync(emailSource.Hostname, emailSource.Port, emailSource.SSL);
                    await client.AuthenticateAsync(emailSource.Username, emailSource.Password);

                    var inbox = client.Inbox;
                    await inbox.OpenAsync(FolderAccess.ReadWrite);  

                    var unreadMessages = await inbox.SearchAsync(SearchQuery.NotSeen);

                    _logger.LogInformation($"Mesaje necitite: {unreadMessages.Count}");

                    foreach (var uid in unreadMessages)
                    {
                        var message = await inbox.GetMessageAsync(uid);
                        _logger.LogInformation($"Subiect: {message.Subject}");

                        await NotifyUserAsync(message);

                        await inbox.AddFlagsAsync(uid, MessageFlags.Seen, true);
                    }

                    await client.DisconnectAsync(true);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Nu am putut verifica emailurile pentru sursa {emailSource.Hostname}: {ex.Message}");
                }
            }
        }

        _logger.LogInformation("Am terminat verificarea surselor de email.");
    }

    private async Task NotifyUserAsync(MimeMessage message)
    {
        _logger.LogInformation($"Notificare: Ai primit un email nou! Subiect: {message.Subject}, De la: {message.From}, Data: {message.Date}");
        await Task.CompletedTask;
    }
}
