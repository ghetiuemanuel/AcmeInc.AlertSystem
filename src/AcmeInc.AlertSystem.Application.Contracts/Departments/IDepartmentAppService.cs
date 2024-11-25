using System;
using AcmeInc.AlertSystem.Departments.Dtos;
using AcmeInc.AlertSystem.Lookup;
using Volo.Abp.Application.Services;

namespace AcmeInc.AlertSystem.Departments;


public interface IDepartmentAppService : 
    ICrudAppService< 
        DepartmentDto, 
        Guid, 
        DepartmentGetListInput,
        DepartmentCreateDto,
        DepartmentUpdateDto>,
        ILookupAppService<Guid>
{

}
