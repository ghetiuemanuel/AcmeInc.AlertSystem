using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcmeInc.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AcmeInc.AlertSystem.MessageSources;

public class WebhookMessageSourceRepository : EfCoreRepository<AlertSystemDbContext, WebhookMessageSource, Guid>, IWebhookMessageSourceRepository
{
    public WebhookMessageSourceRepository(IDbContextProvider<AlertSystemDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<WebhookMessageSource>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
    public async Task<List<WebhookMessageSource>> GetLookupListAsync(int skip, int take, bool includeInactive)
    {
        return await (await GetQueryableAsync())
            .AsNoTracking()
            .Where(webhookMessageSource => includeInactive || webhookMessageSource.Active)
            .Select(webhookMessageSource => new WebhookMessageSource(webhookMessageSource.Id, webhookMessageSource.Title, "", "", true))
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
}