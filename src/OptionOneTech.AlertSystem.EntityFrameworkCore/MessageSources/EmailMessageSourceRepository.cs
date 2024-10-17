using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OptionOneTech.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace OptionOneTech.AlertSystem.MessageSources;

public class EmailMessageSourceRepository : EfCoreRepository<AlertSystemDbContext, EmailMessageSource, Guid>, IEmailMessageSourceRepository
{
    public EmailMessageSourceRepository(IDbContextProvider<AlertSystemDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<EmailMessageSource>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
    public async Task<List<EmailMessageSource>> GetLookupListAsync(int skip, int take)
    {
        return await (await GetQueryableAsync())
            .AsNoTracking()
            .Where(emailMessageSource => emailMessageSource.Active)
            .Select(emailMessageSource => new EmailMessageSource(emailMessageSource.Id, "", 0 ,true, emailMessageSource.Username, "","", true, true))
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
}