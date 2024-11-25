using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AcmeInc.AlertSystem.Departments;
using AcmeInc.AlertSystem.Departments.Dtos;
using AcmeInc.AlertSystem.Web.Pages.Department.ViewModels;

namespace AcmeInc.AlertSystem.Web.Pages.Department;

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