using AcmeInc.AlertSystem.Lookup;
using System;
using System.Linq;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace AcmeInc.AlertSystem.Messages;

public interface IMessageRepository : IRepository<Message, Guid>, ILookupRepository<Message>
{
    Task<IQueryable<MessageNavigation>> GetNavigationList();
    Task<List<Message>> GetUnprocessedMessagesAsync();
}
