using AcmeInc.AlertSystem.Lookup;
using System;
using Volo.Abp.Domain.Repositories;

namespace AcmeInc.AlertSystem.MessageSources;

public interface IEmailMessageSourceRepository : IRepository<EmailMessageSource, Guid> , ILookupRepository<EmailMessageSource>
{
}
