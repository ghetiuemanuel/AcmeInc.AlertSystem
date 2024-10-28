using OptionOneTech.AlertSystem.Lookup;
using System;
using System.Linq;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.Alerts;
using System.Collections.Generic;


namespace OptionOneTech.AlertSystem.Messages;

public interface IMessageRepository : IRepository<Message, Guid>, ILookupRepository<Message>
{
    Task<IQueryable<MessageNavigation>> GetNavigationList();
    Task<List<Message>> GetUnprocessedMessagesAsync();
}
