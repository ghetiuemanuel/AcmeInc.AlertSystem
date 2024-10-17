using System;
using OptionOneTech.AlertSystem.Rules.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Rules;


public interface IRuleAppService :
    ICrudAppService< 
        RuleDto, 
        Guid, 
        RuleGetListInput,
        RuleCreateDto,
        RuleUpdateDto>
{

}