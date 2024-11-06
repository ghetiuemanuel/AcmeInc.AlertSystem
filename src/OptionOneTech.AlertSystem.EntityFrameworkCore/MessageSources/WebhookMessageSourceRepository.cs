using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OptionOneTech.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OptionOneTech.AlertSystem.MessageSources;

public class WebhookMessageSourceRepository : EfCoreRepository<AlertSystemDbContext, WebhookMessageSource, Guid>, IWebhookMessageSourceRepository
{
    public WebhookMessageSourceRepository(IDbContextProvider<AlertSystemDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<WebhookMessageSource>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
    public async Task<List<WebhookMessageSource>> GetLookupListAsync(int skip, int take, bool includeInActive)
    {
        var query = await GetQueryableAsync();

        if (!includeInActive)
        {
            query = query.Where(webhookMessageSource => webhookMessageSource.Active);
        }
        return await query
            .AsNoTracking()
            .Where(webhookMessageSource => webhookMessageSource.Active)
            .Select(webhookMessageSource => new WebhookMessageSource(webhookMessageSource.Id, webhookMessageSource.Title, "", "", true))
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
}