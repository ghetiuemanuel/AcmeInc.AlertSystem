using OptionOneTech.AlertSystem.Lookup;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.MessageSources;

public interface IWebhookMessageSourceRepository : IRepository<WebhookMessageSource, Guid>, ILookupRepository<WebhookMessageSource>
{
}
