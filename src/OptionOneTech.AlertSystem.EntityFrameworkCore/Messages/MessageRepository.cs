using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OptionOneTech.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;




namespace OptionOneTech.AlertSystem.Messages
{
    public class MessageRepository : EfCoreRepository<AlertSystemDbContext, Message, Guid>, IMessageRepository
    {

        public MessageRepository(IDbContextProvider<AlertSystemDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public override async Task<IQueryable<Message>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }

        public async Task<List<Message>> GetLookupListAsync(int skip, int take)
        {
            return await (await GetQueryableAsync())
                .AsNoTracking()
                .Select(message => new Message(message.Id, message.Title, "", Guid.Empty, SourceType.Email, ""))
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
        public IQueryable<MessageNavigation> GetNavigationList()
        {
            var dbContext = GetDbContextAsync().Result;
            var query =
                from message in dbContext.Messages
                join webhookMessageSource in dbContext.WebhookMessageSources
                on message.SourceId equals webhookMessageSource.Id into sourceGroup
                from webhookMessageSource in sourceGroup.DefaultIfEmpty()
                select new MessageNavigation
                {
                    Message = message,
                    WebhookMessageSource = webhookMessageSource
                };

            return query; 
        }
    }
}
