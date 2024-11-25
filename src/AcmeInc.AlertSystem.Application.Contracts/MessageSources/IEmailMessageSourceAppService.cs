using System;
using AcmeInc.AlertSystem.Lookup;
using AcmeInc.AlertSystem.MessageSources.Dtos;
using Volo.Abp.Application.Services;

namespace AcmeInc.AlertSystem.MessageSources;


public interface IEmailMessageSourceAppService :
    ICrudAppService< 
        EmailMessageSourceDto, 
        Guid, 
        EmailMessageSourceGetListInput,
        EmailMessageSourceCreateDto,
        EmailMessageSourceUpdateDto>,
        ILookupAppService<Guid>
{

}