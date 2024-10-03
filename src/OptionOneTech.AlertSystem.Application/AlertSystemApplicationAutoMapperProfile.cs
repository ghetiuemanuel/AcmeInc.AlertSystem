using OptionOneTech.AlertSystem.Departments;
using OptionOneTech.AlertSystem.Departments.Dtos;
using OptionOneTech.AlertSystem.Levels;
using OptionOneTech.AlertSystem.Levels.Dtos;
using AutoMapper;

namespace OptionOneTech.AlertSystem;

public class AlertSystemApplicationAutoMapperProfile : Profile
{
    public AlertSystemApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Department, DepartmentDto>();
        CreateMap<DepartmentCreateDto, Department>(MemberList.Source);
        CreateMap<DepartmentUpdateDto, Department>(MemberList.Source);
        CreateMap<Level, LevelDto>();
        CreateMap<CreateLevelDto, Level>(MemberList.Source);
        CreateMap<UpdateLevelDto, Level>(MemberList.Source);
    }
}
