using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.Lookup;
using OptionOneTech.AlertSystem.Messages.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Messages;


public interface IMessageAppService :
        ICrudAppService<
        MessageDto,
        Guid,
        MessageGetListInput,
        CreateMessageDto,
        UpdateMessageDto>,
        ILookupAppService<Guid>
{
    Task<List<MessageNavigationDto>> GetNavigationListAsync(PagedResultRequestDto input);
}