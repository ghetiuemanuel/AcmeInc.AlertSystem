using System;
using System.ComponentModel.DataAnnotations;

namespace OptionOneTech.AlertSystem.Web.Pages.Department.ViewModels;

public class EditDepartmentViewModel
{
    [Display(Name = "DepartmentName")]
    public string Name { get; set; }

    [Display(Name = "DepartmentDescription")]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    [Display(Name = "DepartmentActive")]
    public bool Active { get; set; }
}
