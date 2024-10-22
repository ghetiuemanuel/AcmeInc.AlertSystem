using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using OptionOneTech.AlertSystem.Departments;
using OptionOneTech.AlertSystem.Levels;
using OptionOneTech.AlertSystem.Statuses;

namespace OptionOneTech.AlertSystem.Web.Pages.Rule
{
    public class IndexModel : AlertSystemPageModel
    {
        private readonly IDepartmentAppService _departmentAppService;
        private readonly IStatusAppService _statusAppService;
        private readonly ILevelAppService _levelAppService;

        public RuleFilterInput RuleFilter { get; set; } = new RuleFilterInput();

        public IndexModel(
            IDepartmentAppService departmentAppService,
            IStatusAppService statusAppService,
            ILevelAppService levelAppService)
        {
            _departmentAppService = departmentAppService;
            _statusAppService = statusAppService;
            _levelAppService = levelAppService;
        }

        public virtual async Task OnGetAsync()
        {
            var departments = await _departmentAppService.FetchAllLookups();
            var statuses = await _statusAppService.FetchAllLookups();
            var levels = await _levelAppService.FetchAllLookups();

            RuleFilter.DepartmentOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "All" } 
            };

            foreach (var department in departments)
            {
                RuleFilter.DepartmentOptions.Add(new SelectListItem
                {
                    Value = department.Id.ToString(),
                    Text = department.Name,
                });
            }

            RuleFilter.StatusOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "All" } 
            };

            foreach (var status in statuses)
            {
                RuleFilter.StatusOptions.Add(new SelectListItem
                {
                    Value = status.Id.ToString(),
                    Text = status.Name,
                });
            }

            RuleFilter.LevelOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "All" }
            };

            foreach (var level in levels)
            {
                RuleFilter.LevelOptions.Add(new SelectListItem
                {
                    Value = level.Id.ToString(),
                    Text = level.Name,
                });
            }
        }

        public class RuleFilterInput
        {
            [FormControlSize(AbpFormControlSize.Small)]
            [Display(Name = "RuleFromRegex")]
            public string? FromRegex { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [Display(Name = "RuleTitleRegex")]
            public string? TitleRegex { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [Display(Name = "RuleBodyRegex")]
            public string? BodyRegex { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [Display(Name = "RuleAnyCondition")]
            public bool? AnyCondition { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [Display(Name = "RuleAlertTitle")]
            public string? AlertTitle { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [Display(Name = "RuleAlertBody")]
            public string? AlertBody { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [SelectItems(nameof(DepartmentOptions))]
            [Display(Name = "RuleAlertDepartmentId")]
            public Guid? AlertDepartmentId { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [SelectItems(nameof(StatusOptions))]
            [Display(Name = "RuleAlertStatusId")]
            public Guid? AlertStatusId { get; set; }

            [FormControlSize(AbpFormControlSize.Small)]
            [SelectItems(nameof(LevelOptions))]
            [Display(Name = "RuleAlertLevelId")]
            public Guid? AlertLevelId { get; set; }

            public List<SelectListItem> DepartmentOptions { get; set; } = new List<SelectListItem>();
            public List<SelectListItem> StatusOptions { get; set; } = new List<SelectListItem>();
            public List<SelectListItem> LevelOptions { get; set; } = new List<SelectListItem>();
        }
    }
}
