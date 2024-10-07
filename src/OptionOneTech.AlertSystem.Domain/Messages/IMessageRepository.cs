using OptionOneTech.AlertSystem.Lookup;
using System;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.Messages;

public interface IMessageRepository : IRepository<Message, Guid>, ILookupRepository<Message>
{
}
