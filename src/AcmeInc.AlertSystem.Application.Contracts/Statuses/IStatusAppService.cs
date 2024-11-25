using System;
using AcmeInc.AlertSystem.Lookup;
using AcmeInc.AlertSystem.Statuses.Dtos;
using Volo.Abp.Application.Services;

namespace AcmeInc.AlertSystem.Statuses;


public interface IStatusAppService :
    ICrudAppService<
        StatusDto,
        Guid,
        StatusGetListInput,
        CreateStatusDto,
        UpdateStatusDto>,
        ILookupAppService<Guid>
{
}