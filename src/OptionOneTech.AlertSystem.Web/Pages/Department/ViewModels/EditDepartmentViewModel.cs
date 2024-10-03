using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace OptionOneTech.AlertSystem.Web.Pages.Department.ViewModels;

public class EditDepartmentViewModel
{
    [Display(Name = "DepartmentName")]
    public string Name { get; set; }

    [Display(Name = "DepartmentDescription")]
    [DataType(DataType.MultilineText)]
    [TextArea(Rows = 4)]
    [MaxLength(512, ErrorMessage = "Too many characters!")]
    public string Description { get; set; }

    [Display(Name = "DepartmentActive")]
    public bool Active { get; set; }
}
