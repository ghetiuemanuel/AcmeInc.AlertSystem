using System;
using System.ComponentModel.DataAnnotations;

namespace OptionOneTech.AlertSystem.Web.Pages.Departments.Department.ViewModels;

public class CreateDepartmentViewModel
{
    [Display(Name = "DepartmentName")]
    public string Name { get; set; }

    [Display(Name = "DepartmentDescription")]
    public string Description { get; set; }

    [Display(Name = "DepartmentActive")]
    public bool Active { get; set; }
}
