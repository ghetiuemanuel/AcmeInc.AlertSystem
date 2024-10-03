using OptionOneTech.AlertSystem.Departments.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Department.ViewModels;
using OptionOneTech.AlertSystem.Levels.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Levels.Level.ViewModels;
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
        CreateMap<LevelDto, EditLevelViewModel>();
        CreateMap<CreateLevelViewModel, CreateLevelDto>();
        CreateMap<EditLevelViewModel, UpdateLevelDto>();
    }
}
