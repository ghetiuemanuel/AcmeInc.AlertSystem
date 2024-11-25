using AcmeInc.AlertSystem.Lookup;
using System;
using Volo.Abp.Domain.Repositories;

namespace AcmeInc.AlertSystem.MessageSources;

public interface IWebhookMessageSourceRepository : IRepository<WebhookMessageSource, Guid>, ILookupRepository<WebhookMessageSource>
{
}
