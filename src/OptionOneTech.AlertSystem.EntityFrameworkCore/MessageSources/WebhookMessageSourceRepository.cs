using System;
using System.Linq;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

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
}