using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OptionOneTech.AlertSystem.Lookup;
using OptionOneTech.AlertSystem.Statuses.Dtos;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Statuses;


public interface IStatusAppService :
    ICrudAppService<
        StatusDto,
        Guid,
        StatusGetListInput,
        CreateStatusDto,
        UpdateStatusDto>,
        ILookupAppService<Guid>
{
    Task<List<StatusDto>> GetAllAsync();
}