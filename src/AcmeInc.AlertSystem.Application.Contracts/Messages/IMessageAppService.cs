using System;
using System.Threading.Tasks;
using AcmeInc.AlertSystem.Lookup;
using AcmeInc.AlertSystem.Messages.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AcmeInc.AlertSystem.Messages;


public interface IMessageAppService :
        ICrudAppService<
        MessageDto,
        Guid,
        MessageGetListInput,
        CreateMessageDto,
        UpdateMessageDto>,
        ILookupAppService<Guid>
{ 
    Task<PagedResultDto<MessageNavigationDto>> GetNavigationListAsync(MessageGetListInput input);
}