using System;
using OptionOneTech.AlertSystem.Departments.Dtos;
using OptionOneTech.AlertSystem.Lookup;
using Volo.Abp.Application.Services;

namespace OptionOneTech.AlertSystem.Departments;


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
