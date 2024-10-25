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
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public EmailSourceBackgroundWorker(
            AbpAsyncTimer timer,
            IServiceScopeFactory serviceScopeFactory,
            ILogger<EmailSourceBackgroundWorker> logger
             )
            : base(timer, serviceScopeFactory)
        {
            Timer.Period = 10000;
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
        {
            _logger.LogInformation("Starting to check email sources...");

            var emailMessageSourceRepository = workerContext.ServiceProvider.GetRequiredService<IEmailMessageSourceRepository>();
            var emailSources = await emailMessageSourceRepository.GetListAsync(x => x.Active);
            var messageRepository = workerContext.ServiceProvider.GetRequiredService<IMessageRepository>();


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

                                await CreateEmailMessageAsync(message, emailSource.Id, messageRepository);
                                await inbox.AddFlagsAsync(uid, MessageFlags.Seen, true);
                            }

                            await client.DisconnectAsync(true);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, $"Could not check emails for source {emailSource.Hostname}");
                        }
                    }
                
            }

            _logger.LogInformation("Finished checking email sources.");
        }

        private async Task CreateEmailMessageAsync(MimeMessage message, Guid sourceId, IMessageRepository messageRepository)
        {
            var newMessage = new Message(
                Guid.Empty,
                message.Subject,
                message.From.ToString(),
                sourceId,
                SourceType.Email,
                message.TextBody,
                DateTime.Now
            );

            await messageRepository.InsertAsync(newMessage);
            _logger.LogInformation($"Saved new message to database: Title: {newMessage.Title}, From: {newMessage.From}, Date: {message.Date}");
        }
    }
}
