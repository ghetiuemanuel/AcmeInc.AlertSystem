using System;
using OptionOneTech.AlertSystem.Lookup;
using OptionOneTech.AlertSystem.MessageSources.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.MessageSources;


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