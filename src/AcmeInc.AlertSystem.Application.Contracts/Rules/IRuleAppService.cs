using System;
using System.Threading.Tasks;
using AcmeInc.AlertSystem.Lookup;
using AcmeInc.AlertSystem.Rules.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AcmeInc.AlertSystem.Rules;


public interface IRuleAppService :
    ICrudAppService< 
        RuleDto, 
        Guid, 
        RuleGetListInput,
        RuleCreateDto,
        RuleUpdateDto>,
        ILookupAppService<Guid>
{
   Task<PagedResultDto<RuleNavigationDto>> GetNavigationListAsync(RuleGetListInput input);
}