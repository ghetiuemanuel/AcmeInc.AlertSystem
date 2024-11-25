using System;
using AcmeInc.AlertSystem.Levels.Dtos;
using AcmeInc.AlertSystem.Lookup;
using Volo.Abp.Application.Services;

namespace AcmeInc.AlertSystem.Levels;


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