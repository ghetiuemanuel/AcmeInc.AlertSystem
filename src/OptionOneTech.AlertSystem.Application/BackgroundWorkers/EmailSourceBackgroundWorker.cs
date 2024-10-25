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
using OptionOneTech.AlertSystem.Messages;

namespace OptionOneTech.AlertSystem.BackgroundWorkers
{
    public class EmailSourceBackgroundWorker : AsyncPeriodicBackgroundWorkerBase, ITransientDependency
    {
        private readonly ILogger<EmailSourceBackgroundWorker> _logger;
        private readonly IMessageRepository _messageRepository;

        public EmailSourceBackgroundWorker(
            AbpAsyncTimer timer,
            IServiceScopeFactory serviceScopeFactory,
            ILogger<EmailSourceBackgroundWorker> logger,
            IMessageRepository messageRepository)
            : base(timer, serviceScopeFactory)
        {
            Timer.Period = 10000;
            _logger = logger;
            _messageRepository = messageRepository;
        }

        protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
        {
            _logger.LogInformation("Starting email source check...");

            using (var scope = workerContext.ServiceProvider.CreateScope())
            {
                var emailMessageSourceRepository = scope.ServiceProvider.GetRequiredService<IEmailMessageSourceRepository>();
                var emailSources = await emailMessageSourceRepository.GetListAsync(x => x.Active);

                foreach (var emailSource in emailSources)
                {
                    _logger.LogInformation($"Checking emails for source: {emailSource.Hostname}");

                    using (var client = new ImapClient())
                    {
                        try
                        {
                            await client.ConnectAsync(emailSource.Hostname, emailSource.Port, emailSource.SSL);
                            await client.AuthenticateAsync(emailSource.Username, emailSource.Password);

                            var inbox = client.Inbox;
                            await inbox.OpenAsync(FolderAccess.ReadWrite);

                            var unreadMessages = await inbox.SearchAsync(SearchQuery.NotSeen);
                            _logger.LogInformation($"Unread messages: {unreadMessages.Count}");

                            foreach (var uid in unreadMessages)
                            {
                                var message = await inbox.GetMessageAsync(uid);
                                _logger.LogInformation($"Subject: {message.Subject}");

                                await SaveMessageToDatabaseAsync(message, emailSource.Id); 

                                await inbox.AddFlagsAsync(uid, MessageFlags.Seen, true);
                            }

                            await client.DisconnectAsync(true);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError($"Could not check emails for source {emailSource.Hostname}: {ex.Message}");
                        }
                    }
                }
            }

            _logger.LogInformation("Finished checking email sources.");
        }
        private async Task SaveMessageToDatabaseAsync(MimeMessage email, Guid sourceId)
        {
            var message = new Message
            {
                Title = email.Subject,
                From = email.From.ToString(),
                SourceId = sourceId, 
                SourceType = SourceType.Email,
                Body = email.TextBody ?? email.HtmlBody ?? string.Empty,
                ProcessedAt = DateTime.Now 
            };

            await _messageRepository.InsertAsync(message);
            _logger.LogInformation("Message saved to database.");
        }
    }
}
