using System;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.Lookup;
using OptionOneTech.AlertSystem.Rules.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Rules;


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