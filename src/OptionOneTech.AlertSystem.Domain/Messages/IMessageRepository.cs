using OptionOneTech.AlertSystem.Lookup;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;


namespace OptionOneTech.AlertSystem.Messages;

public interface IMessageRepository : IRepository<Message, Guid>, ILookupRepository<Message>
{
    Task<List<MessageNavigation>> GetNavigationListAsync(int skip, int take);
}
