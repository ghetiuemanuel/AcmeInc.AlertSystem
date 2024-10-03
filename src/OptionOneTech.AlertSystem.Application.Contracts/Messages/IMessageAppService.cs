using System;
using OptionOneTech.AlertSystem.Messages.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Messages;


public interface IMessageAppService :
    ICrudAppService< 
                MessageDto, 
        Guid, 
        PagedAndSortedResultRequestDto,
        CreateMessageDto,
        UpdateMessageDto>
{

}