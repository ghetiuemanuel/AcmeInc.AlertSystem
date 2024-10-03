using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Departments;
using OptionOneTech.AlertSystem.Departments.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Department.ViewModels;

namespace OptionOneTech.AlertSystem.Web.Pages.Department;

public class CreateModalModel : AlertSystemPageModel
{
    [BindProperty]
    public CreateDepartmentViewModel ViewModel { get; set; }

    private readonly IDepartmentAppService _service;

    public CreateModalModel(IDepartmentAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateDepartmentViewModel, DepartmentCreateDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}