using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using OptionOneTech.AlertSystem.Departments;
using OptionOneTech.AlertSystem.Levels;
using OptionOneTech.AlertSystem.Statuses;
using OptionOneTech.AlertSystem.Localization;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Rules;

namespace OptionOneTech.AlertSystem.Web.Pages.Alert
{
    public class IndexModel : AlertSystemPageModel
    {
        private readonly IDepartmentAppService _departmentAppService;
        private readonly IStatusAppService _statusAppService;
        private readonly ILevelAppService _levelAppService;
        private readonly IMessageAppService _messageAppService;
        private readonly IRuleAppService _ruleAppService;
        private readonly IStringLocalizer<AlertSystemResource> _localizer;

        public AlertFilterInput AlertFilter { get; set; } = new AlertFilterInput();

        public IndexModel(
            IDepartmentAppService departmentAppService,
            IStatusAppService statusAppService,
            ILevelAppService levelAppService,
            IMessageAppService messageAppService,
            IRuleAppService ruleAppService,
            IStringLocalizer<AlertSystemResource> localizer)
        {
            _departmentAppService = departmentAppService;
            _statusAppService = statusAppService;
            _levelAppService = levelAppService;
            _messageAppService = messageAppService;
            _ruleAppService = ruleAppService;
            _localizer = localizer;
        }

        public virtual async Task OnGetAsync()
        {
            var departments = await _departmentAppService.FetchAllLookups();
            var statuses = await _statusAppService.FetchAllLookups();
            var levels = await _levelAppService.FetchAllLookups();
            var messages = await _messageAppService.FetchAllLookups();
            var rules = await _ruleAppService.FetchAllLookups();

            string allLabel = _localizer["FilterAllText"];

            AlertFilter.DepartmentOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = allLabel }
            };

            foreach (var department in departments)
            {
                AlertFilter.DepartmentOptions.Add(new SelectListItem
                {
                    Value = department.Id.ToString(),
                    Text = department.Name,
                });
            }

            AlertFilter.StatusOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = allLabel }
            };

            foreach (var status in statuses)
            {
                AlertFilter.StatusOptions.Add(new SelectListItem
                {
                    Value = status.Id.ToString(),
                    Text = status.Name,
                });
            }

            AlertFilter.LevelOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = allLabel }
            };

            foreach (var level in levels)
            {
                AlertFilter.LevelOptions.Add(new SelectListItem
                {
                    Value = level.Id.ToString(),
                    Text = level.Name,
                });
            }

            AlertFilter.MessageOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = allLabel }
            };

            foreach (var message in messages)
            {
                AlertFilter.MessageOptions.Add(new SelectListItem
                {
                    Value = message.Id.ToString(),
                    Text = message.Name,
                });
            }

            AlertFilter.RuleOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = allLabel }
            };

            foreach (var rule in rules)
            {
                AlertFilter.RuleOptions.Add(new SelectListItem
                {
                    Value = rule.Id.ToString(),
                    Text = rule.Name,
                });
            }
        }

        public class AlertFilterInput
        {
            [FormControlSize(AbpFormControlSize.Small)]
            [Display(Name = "AlertTitle")]
            public string? Title { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [Display(Name = "AlertBody")]
            public string? Body { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [SelectItems(nameof(MessageOptions))]
            [Display(Name = "AlertMessageId")]
            public Guid? MessageId { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [SelectItems(nameof(RuleOptions))]
            [Display(Name = "AlertRuleId")]
            public Guid? RuleId { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [SelectItems(nameof(DepartmentOptions))]
            [Display(Name = "AlertDepartmentId")]
            public Guid? DepartmentId { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [SelectItems(nameof(StatusOptions))]
            [Display(Name = "AlertStatusId")]
            public Guid? StatusId { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [SelectItems(nameof(LevelOptions))]
            [Display(Name = "AlertLevelId")]
            public Guid? LevelId { get; set; }

            public List<SelectListItem> RuleOptions { get; set; } = new List<SelectListItem>();
            public List<SelectListItem> MessageOptions { get; set; } = new List<SelectListItem>();
            public List<SelectListItem> DepartmentOptions { get; set; } = new List<SelectListItem>();
            public List<SelectListItem> StatusOptions { get; set; } = new List<SelectListItem>();
            public List<SelectListItem> LevelOptions { get; set; } = new List<SelectListItem>();
        }
    }
}
