using System;
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
    [TextArea(Rows = 4)]
    public string AlertBody { get; set; }

    [Display(Name = "RuleAlertDepartmentId")]
    public Guid AlertDepartmentId { get; set; }

    [Display(Name = "RuleAlertStatusId")]
    public Guid AlertStatusId { get; set; }

    [Display(Name = "RuleAlertLevelId")]
    public Guid AlertLevelId { get; set; }
}
