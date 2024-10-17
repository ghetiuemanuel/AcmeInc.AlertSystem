using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace OptionOneTech.AlertSystem.Web.Pages.Rule;

public class IndexModel : AlertSystemPageModel
{
    public RuleFilterInput RuleFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
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
    [Display(Name = "RuleAlertDepartmentId")]
    public Guid? AlertDepartmentId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "RuleAlertStatusId")]
    public Guid? AlertStatusId { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "RuleAlertLevelId")]
    public Guid? AlertLevelId { get; set; }
}
