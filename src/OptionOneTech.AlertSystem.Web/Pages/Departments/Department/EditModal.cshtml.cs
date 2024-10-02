using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Departments;
using OptionOneTech.AlertSystem.Departments.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Departments.Department.ViewModels;

namespace OptionOneTech.AlertSystem.Web.Pages.Departments.Department;

public class EditModalModel : AlertSystemPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditDepartmentViewModel ViewModel { get; set; }

    private readonly IDepartmentAppService _service;

    public EditModalModel(IDepartmentAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<DepartmentDto, EditDepartmentViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditDepartmentViewModel, DepartmentUpdateDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}