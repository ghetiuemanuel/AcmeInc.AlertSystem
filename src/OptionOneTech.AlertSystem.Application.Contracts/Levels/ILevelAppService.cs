using System;
using OptionOneTech.AlertSystem.Levels.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Levels;


public interface ILevelAppService :
    ICrudAppService< 
                LevelDto, 
        Guid, 
        PagedAndSortedResultRequestDto,
        CreateLevelDto,
        UpdateLevelDto>
{

}