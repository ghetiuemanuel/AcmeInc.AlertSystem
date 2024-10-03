using System;
using System.Linq;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace OptionOneTech.AlertSystem.Messages;

public class MessageRepository : EfCoreRepository<AlertSystemDbContext, Message, Guid>, IMessageRepository
{
    public MessageRepository(IDbContextProvider<AlertSystemDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Message>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}