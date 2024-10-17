using OptionOneTech.AlertSystem.Lookup;
using System;
using Volo.Abp.Domain.Repositories;

namespace OptionOneTech.AlertSystem.MessageSources;

public interface IEmailMessageSourceRepository : IRepository<EmailMessageSource, Guid> , ILookupRepository<EmailMessageSource>
{
}
