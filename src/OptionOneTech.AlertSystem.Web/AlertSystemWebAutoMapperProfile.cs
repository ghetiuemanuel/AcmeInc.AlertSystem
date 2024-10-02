using OptionOneTech.AlertSystem.Departments.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Departments.Department.ViewModels;
using AutoMapper;

namespace OptionOneTech.AlertSystem.Web;

public class AlertSystemWebAutoMapperProfile : Profile
{
    public AlertSystemWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<DepartmentDto, EditDepartmentViewModel>();
        CreateMap<CreateDepartmentViewModel, DepartmentCreateDto>();
        CreateMap<EditDepartmentViewModel, DepartmentUpdateDto>();
    }
}
