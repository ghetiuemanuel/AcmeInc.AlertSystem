using System;
using System.Threading.Tasks;
using AcmeInc.AlertSystem.Alerts.Dtos;
using AcmeInc.AlertSystem.Lookup;
using AcmeInc.AlertSystem.Messages.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AcmeInc.AlertSystem.Alerts;


public interface IAlertAppService :
    ICrudAppService< 
        AlertDto, 
        Guid, 
        AlertGetListInput,
        AlertCreateDto,
        AlertUpdateDto>,
        ILookupAppService<Guid>
{
    Task<PagedResultDto<AlertNavigationDto>> GetNavigationListAsync(AlertGetListInput input);
    Task UpdateStatusAsync(Guid Id, Guid statusId);

}