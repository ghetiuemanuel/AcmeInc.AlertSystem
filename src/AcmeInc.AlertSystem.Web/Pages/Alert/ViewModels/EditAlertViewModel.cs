using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcmeInc.AlertSystem.Web.Pages.Alert.ViewModels;

public class EditAlertViewModel
{
    [Display(Name = "AlertTitle")]
    public string Title { get; set; }

    [Display(Name = "AlertBody")]
    [TextArea(Rows = 4)]
    public string Body { get; set; }

    [SelectItems(nameof(DepartmentOptions))]
    [Display(Name = "AlertDepartmentId")]
    public Guid DepartmentId { get; set; }

    [SelectItems(nameof(StatusOptions))]
    [Display(Name = "AlertStatusId")]
    public Guid StatusId { get; set; }

    [SelectItems(nameof(LevelOptions))]
    [Display(Name = "AlertLevelId")]
    public Guid LevelId { get; set; }

    [SelectItems(nameof(MessageOptions))]
    [Display(Name = "AlertMessageId")]
    public Guid MessageId { get; set; }

    [SelectItems(nameof(RuleOptions))]
    [Display(Name = "AlertRuleId")]
    public Guid RuleId { get; set; }

    [Display(Name = "AlertNotificationSent")]
    public bool NotificationSent { get; set; }


    public List<SelectListItem> RuleOptions { get; set; } = new List<SelectListItem>();

    public List<SelectListItem> MessageOptions { get; set; } = new List<SelectListItem>();

    public List<SelectListItem> DepartmentOptions { get; set; } = new List<SelectListItem>();

    public List<SelectListItem> StatusOptions { get; set; } = new List<SelectListItem>();

    public List<SelectListItem> LevelOptions { get; set; } = new List<SelectListItem>();
}
