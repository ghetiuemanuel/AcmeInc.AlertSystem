using System;
using System.Collections.Generic;
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
        var statuses = await _statusAppService.FetchAllLookups();
        var levels = await _levelAppService.FetchAllLookups();
        var messages = await _messageAppService.FetchAllLookups();
        var rules = await _ruleAppService.FetchAllLookups();

        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<AlertDto, EditAlertViewModel>(dto);

        ViewModel.DepartmentOptions = departments.Select(department => new SelectListItem
        {
            Value = department.Id.ToString(),
            Text = department.Name,
            Selected = department.Id == ViewModel.DepartmentId
        }).ToList();

        var activeStatuses = statuses.Where(status => status.Active).ToList();

        var inactiveStatusesAssignedToAlert = statuses.Where(status => !status.Active && status.Id == ViewModel.StatusId).ToList();

        var availableStatuses = activeStatuses.Concat(inactiveStatusesAssignedToAlert).ToList();

        ViewModel.StatusOptions = new List<SelectListItem>();

        foreach (var status in availableStatuses)
        {
            var statusItem = new SelectListItem
            {
                Value = status.Id.ToString(),
                Selected = status.Id == ViewModel.StatusId
            };

            if (!status.Active && status.Id == ViewModel.StatusId)
            {
                statusItem.Text = status.Name + " (Inactiv)";  
                statusItem.Disabled = true;  
            }
            else
            {
                statusItem.Text = status.Name;  
                statusItem.Disabled = !status.Active;  
            }

            ViewModel.StatusOptions.Add(statusItem);
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
