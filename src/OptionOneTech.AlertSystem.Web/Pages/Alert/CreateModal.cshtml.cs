using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OptionOneTech.AlertSystem.Alerts;
using OptionOneTech.AlertSystem.Alerts.Dtos;
using OptionOneTech.AlertSystem.Departments;
using OptionOneTech.AlertSystem.Levels;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Rules;
using OptionOneTech.AlertSystem.Statuses;
using OptionOneTech.AlertSystem.Web.Pages.Alert.ViewModels;

namespace OptionOneTech.AlertSystem.Web.Pages.Alert;

public class CreateModalModel : AlertSystemPageModel
{
    [BindProperty]
    public CreateAlertViewModel ViewModel { get; set; }

    private readonly IAlertAppService _service;
    private readonly IDepartmentAppService _departmentAppService;
    private readonly IStatusAppService _statusAppService;
    private readonly ILevelAppService _levelAppService;
    private readonly IMessageAppService _messageAppService;
    private readonly IRuleAppService _ruleAppService;



    public CreateModalModel(
        IAlertAppService service,
        IDepartmentAppService departmentAppService,
        IStatusAppService statusAppService,
        ILevelAppService levelAppService,
        IMessageAppService messageAppService,
        IRuleAppService ruleAppService)
    {
        _service = service;
        _departmentAppService = departmentAppService;
        _statusAppService = statusAppService;
        _levelAppService = levelAppService;
        _messageAppService = messageAppService;
        _ruleAppService = ruleAppService;
    }
    public virtual async Task OnGetAsync()
    {
        ViewModel = new CreateAlertViewModel();

        var departments = await _departmentAppService.FetchAllLookups();
        var statuses = await _statusAppService.FetchAllLookups();
        var levels = await _levelAppService.FetchAllLookups();
        var messages = await _messageAppService.FetchAllLookups();
        var rules = await _ruleAppService.FetchAllLookups();

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

        ViewModel.MessageOptions = messages.Select(message => new SelectListItem
        {
            Value = message.Id.ToString(),
            Text = message.Name,
        }).ToList();

        ViewModel.RuleOptions = rules.Select(rule => new SelectListItem
        {
            Value = rule.Id.ToString(),
            Text = rule.Name,
        }).ToList();
    }
    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateAlertViewModel, AlertCreateDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}
