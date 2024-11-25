using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcmeInc.AlertSystem.Departments;
using AcmeInc.AlertSystem.Levels;
using AcmeInc.AlertSystem.Rules;
using AcmeInc.AlertSystem.Rules.Dtos;
using AcmeInc.AlertSystem.Statuses;
using AcmeInc.AlertSystem.Web.Pages.Rule.ViewModels;

namespace AcmeInc.AlertSystem.Web.Pages.Rule;

public class EditModalModel : AlertSystemPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditRuleViewModel ViewModel { get; set; }

    private readonly IRuleAppService _service;
    private readonly IDepartmentAppService _departmentAppService;
    private readonly IStatusAppService _statusAppService;
    private readonly ILevelAppService _levelAppService;

    public EditModalModel(IRuleAppService service, IDepartmentAppService departmentAppService, IStatusAppService statusAppService, ILevelAppService levelAppService)
    {
        _service = service;
        _departmentAppService = departmentAppService;
        _statusAppService = statusAppService;
        _levelAppService = levelAppService;
    }

    public virtual async Task OnGetAsync()
    {
        var departments = await _departmentAppService.FetchAllLookups();
        var statuses = await _statusAppService.FetchAllLookups();
        var levels = await _levelAppService.FetchAllLookups();


        var dto = await _service.GetAsync(Id);

        ViewModel = ObjectMapper.Map<RuleDto, EditRuleViewModel>(dto);

        ViewModel.DepartmentOptions = departments.Select(department => new SelectListItem
        {
            Value = department.Id.ToString(),
            Text = department.Name,
            Selected = department.Id == ViewModel.AlertDepartmentId
        }).ToList();

        ViewModel.StatusOptions = statuses.Select(status => new SelectListItem
        {
            Value = status.Id.ToString(),
            Text = status.Name,
            Selected = status.Id == ViewModel.AlertStatusId
        }).ToList();

        ViewModel.LevelOptions = levels.Select(level => new SelectListItem
        {
            Value = level.Id.ToString(),
            Text = level.Name,
            Selected = level.Id == ViewModel.AlertLevelId
        }).ToList();
    }
    public virtual async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var dto = ObjectMapper.Map<EditRuleViewModel, RuleUpdateDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);

        return NoContent();
    }
}