using System;
using OptionOneTech.AlertSystem.Statuses.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Statuses;


public interface IStatusAppService :
    ICrudAppService< 
        StatusDto, 
        Guid,
        StatusGetListInput,
        CreateStatusDto,
        UpdateStatusDto>
{

}