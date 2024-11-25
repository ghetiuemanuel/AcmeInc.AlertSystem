using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcmeInc.AlertSystem.Alerts;
using AcmeInc.AlertSystem.Alerts.Dtos;
using AcmeInc.AlertSystem.Departments;
using AcmeInc.AlertSystem.Levels;
using AcmeInc.AlertSystem.Lookup;
using AcmeInc.AlertSystem.Messages;
using AcmeInc.AlertSystem.Rules;
using AcmeInc.AlertSystem.Statuses;
using AcmeInc.AlertSystem.Web.Pages.Alert.ViewModels;


namespace AcmeInc.AlertSystem.Web.Pages.Alert;

public class EditModalModel : AlertSystemPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditAlertViewModel ViewModel { get; set; }

    private readonly IAlertAppService _service;
    private readonly IDepartmentAppService _departmentAppService;
    private readonly IStatusAppService _statusAppService;
    private readonly ILevelAppService _levelAppService;
    private readonly IMessageAppService _messageAppService;
    private readonly IRuleAppService _ruleAppService;

    public EditModalModel(
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
        var departments = await _departmentAppService.FetchAllLookups();
        var levels = await _levelAppService.FetchAllLookups();
        var messages = await _messageAppService.FetchAllLookups();
        var rules = await _ruleAppService.FetchAllLookups();
        var allStatuses = await _statusAppService.FetchAllLookups(includeInactive: true);
        var activeStatuses = await _statusAppService.FetchAllLookups(includeInactive: false);

        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<AlertDto, EditAlertViewModel>(dto);

        ViewModel.DepartmentOptions = departments.Select(department => new SelectListItem
        {
            Value = department.Id.ToString(),
            Text = department.Name,
            Selected = department.Id == ViewModel.DepartmentId
        }).ToList();

        LookupDto<Guid> currentStatus = null;

        foreach (var status in allStatuses)
        {
            if (status.Id == ViewModel.StatusId)
            {
                currentStatus = status;
            }
        }

        LookupDto<Guid> inactiveStatus = null;

        if (currentStatus != null)
        {
            bool isActive = false;

            foreach (var active in activeStatuses)
            {
                if (active.Id == currentStatus.Id)
                {
                    isActive = true;
                }
            }

            if (!isActive)
            {
                inactiveStatus = currentStatus ;
            }
        }

        ViewModel.StatusOptions = new List<SelectListItem>();

        foreach (var status in activeStatuses)
        {
            ViewModel.StatusOptions.Add(new SelectListItem
            {
                Value = status.Id.ToString(),
                Text = status.Name,
                Selected = status.Id == ViewModel.StatusId 
            });
        }

        if (inactiveStatus != null)
        {
            ViewModel.StatusOptions.Add(new SelectListItem
            {
                Value = inactiveStatus.Id.ToString(),
                Text = $"{inactiveStatus.Name} (Inactiv)",
                Selected = inactiveStatus.Id == ViewModel.StatusId,
                Disabled = true 
            });
        }

        ViewModel.LevelOptions = levels.Select(level => new SelectListItem
        {
            Value = level.Id.ToString(),
            Text = level.Name,
            Selected = level.Id == ViewModel.LevelId
        }).ToList();

        ViewModel.MessageOptions = messages.Select(message => new SelectListItem
        {
            Value = message.Id.ToString(),
            Text = message.Name,
            Selected = message.Id == ViewModel.MessageId
        }).ToList();

        ViewModel.RuleOptions = rules.Select(rule => new SelectListItem
        {
            Value = rule.Id.ToString(),
            Text = rule.Name,
            Selected = rule.Id == ViewModel.RuleId
        }).ToList();
    }
    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditAlertViewModel, AlertUpdateDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}
