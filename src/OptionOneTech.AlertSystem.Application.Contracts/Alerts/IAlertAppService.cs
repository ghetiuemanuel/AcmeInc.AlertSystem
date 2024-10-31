using System;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.Alerts.Dtos;
using OptionOneTech.AlertSystem.Lookup;
using OptionOneTech.AlertSystem.Messages.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Alerts;


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
    Task UpdateAlertStatusAsync(Guid alertId, Guid statusId);

}