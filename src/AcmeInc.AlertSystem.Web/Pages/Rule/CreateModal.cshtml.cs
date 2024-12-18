using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcmeInc.AlertSystem.Departments;
using AcmeInc.AlertSystem.Levels;
using AcmeInc.AlertSystem.Rules;
using AcmeInc.AlertSystem.Rules.Dtos;
using AcmeInc.AlertSystem.Statuses;
using AcmeInc.AlertSystem.Web.Pages;
using AcmeInc.AlertSystem.Web.Pages.Rule.ViewModels;

namespace AcmeInc.AlertSystem.Web.ViewModels.Rule;

public class CreateModalModel : AlertSystemPageModel
{

    [BindProperty]
    public CreateRuleViewModel ViewModel { get; set; }


    private readonly IRuleAppService _service;
    private readonly IDepartmentAppService _departmentAppService;
    private readonly IStatusAppService _statusAppService;
    private readonly ILevelAppService _levelAppService;

    public CreateModalModel(IRuleAppService service, IDepartmentAppService departmentAppService, IStatusAppService statusAppService, ILevelAppService levelAppService)
    {
        _service = service;
        _departmentAppService = departmentAppService;
        _statusAppService = statusAppService;
        _levelAppService = levelAppService;
    }
    public virtual async Task OnGetAsync()
    {
        ViewModel = new CreateRuleViewModel();

        var departments = await _departmentAppService.FetchAllLookups();
        var statuses = await _statusAppService.FetchAllLookups();
        var levels = await _levelAppService.FetchAllLookups();

        ViewModel.DepartmentOptions = new List<SelectListItem>();
        ViewModel.StatusOptions = new List<SelectListItem>();
        ViewModel.LevelOptions = new List<SelectListItem>();

        ViewModel.DepartmentOptions = departments.Select(department => new SelectListItem
        {
            Value = department.Id.ToString(),
            Text = department.Name,
        }).ToList();

        ViewModel.StatusOptions = statuses.Select(status => new SelectListItem
        {
            Value = status.Id.ToString(),
            Text = status.Name,
        }).ToList();

        ViewModel.LevelOptions = levels.Select(level => new SelectListItem
        {
            Value = level.Id.ToString(),
            Text = level.Name,
        }).ToList();
    }
    public virtual async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

            var dto = ObjectMapper.Map<CreateRuleViewModel, RuleCreateDto>(ViewModel);
            await _service.CreateAsync(dto);

            return NoContent();
        
    }
}