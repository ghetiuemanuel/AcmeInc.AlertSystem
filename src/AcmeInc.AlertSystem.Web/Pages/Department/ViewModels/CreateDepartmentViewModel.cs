using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace AcmeInc.AlertSystem.Web.Pages.Department.ViewModels;

public class CreateDepartmentViewModel
{
    [Display(Name = "DepartmentName", Order = 1)]
    public string Name { get; set; }

    [Display(Name = "DepartmentDescription", Order = 2)]
    [TextArea(Rows = 4)] 
    [MaxLength(512, ErrorMessage = "DepartmentDescriptionMaxLengthError")]
    public string Description { get; set; }

    [Display(Name = "DepartmentActive", Order = 3)]
    public bool Active { get; set; }
}

