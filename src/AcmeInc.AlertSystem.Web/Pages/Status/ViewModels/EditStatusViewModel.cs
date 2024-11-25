using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace AcmeInc.AlertSystem.Web.Pages.Status.ViewModels;

public class EditStatusViewModel
{
    [Display(Name = "StatusName")]
    public string Name { get; set; }

    [Display(Name = "StatusDescription")]
    [TextArea(Rows = 4)]
    [MaxLength(512, ErrorMessage = "StatusDescriptionMaxLengthError")]

    public string Description { get; set; }

    [Display(Name = "StatusActive")]
    public bool Active { get; set; }
}