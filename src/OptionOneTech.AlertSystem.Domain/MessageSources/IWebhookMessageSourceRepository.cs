using System;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.MessageSources;

public interface IWebhookMessageSourceRepository : IRepository<WebhookMessageSource, Guid>
{
}
