using System;
using OptionOneTech.AlertSystem.Levels.Dtos;
using OptionOneTech.AlertSystem.Lookup;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Levels;


public interface ILevelAppService :
    ICrudAppService< 
        LevelDto, 
        Guid,
        LevelGetListInput,
        CreateLevelDto,
        UpdateLevelDto>,
        ILookupAppService<Guid>
{

}