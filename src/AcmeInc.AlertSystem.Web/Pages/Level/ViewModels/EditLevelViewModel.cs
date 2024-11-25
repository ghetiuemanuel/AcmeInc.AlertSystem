using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace AcmeInc.AlertSystem.Web.Pages.Level.ViewModels;

public class EditLevelViewModel
{
    [Display(Name = "LevelName")]
    public string Name { get; set; }

    [Display(Name = "LevelDescription")]
    [DataType(DataType.MultilineText)]
    [TextArea(Rows = 4)]
    [MaxLength(512, ErrorMessage = "LevelDescriptionMaxLengthError")]
    public string Description { get; set; }

    [Display(Name = "LevelActive")]
    public bool Active { get; set; }
}
