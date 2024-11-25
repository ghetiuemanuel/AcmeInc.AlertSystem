using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace OptionOneTech.AlertSystem.Web.Pages.Rule.ViewModels;

public class EditRuleViewModel
{
    [Display(Name = "RuleFromRegex")]
    public string FromRegex { get; set; }

    [Display(Name = "RuleTitleRegex")]
    public string TitleRegex { get; set; }

    [Display(Name = "RuleBodyRegex")]
    [TextArea(Rows = 4)]
    public string BodyRegex { get; set; }

    [Display(Name = "RuleAnyCondition")]
    public bool AnyCondition { get; set; }

    [Display(Name = "RuleAlertTitle")]
    public string AlertTitle { get; set; }

    [Display(Name = "RuleAlertBody")]
    public string AlertBody { get; set; }

    [SelectItems(nameof(DepartmentOptions))]
    [Display(Name = "RuleAlertDepartmentId")]
    public Guid AlertDepartmentId { get; set; }

    [SelectItems(nameof(StatusOptions))]
    [Display(Name = "RuleAlertStatusId")]
    public Guid AlertStatusId { get; set; }

    [SelectItems(nameof(LevelOptions))]
    [Display(Name = "RuleAlertLevelId")]
    public Guid AlertLevelId { get; set; }

    [Display(Name = "RuleTriggerCount")]
    public int TriggerCount { get; set; }

    [Display(Name = "RuleTriggerWindowDuration")]
    public int TriggerWindowDuration { get; set; }

    [Display(Name = "RuleTriggersRequired")]
    public int TriggersRequired { get; set; }

    [Display(Name = "RuleTriggerTimestamp")]
    public DateTime? TriggerTimestamp { get; set; }

    [Display(Name = "RuleActive")]
    public bool Active { get; set; }

    [Required(ErrorMessage = "Notification Emails are required.")]
    [RegularExpression(
         @"^([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})(,\s*[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$",
         ErrorMessage = "Please enter valid email addresses separated by commas. e.g.: john@test.com, alice@test.com")]
    [Display(Name = "RuleNotificationEmails")]
    public string NotificationEmails { get; set; }

    public List<SelectListItem> DepartmentOptions { get; set; } = new List<SelectListItem>();

    public List<SelectListItem> StatusOptions { get; set; } = new List<SelectListItem>();

    public List<SelectListItem> LevelOptions { get; set; } = new List<SelectListItem>();
}
