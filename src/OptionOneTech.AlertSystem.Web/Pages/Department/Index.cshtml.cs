using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace OptionOneTech.AlertSystem.Web.Pages.Department;

public class IndexModel : AlertSystemPageModel
{
    public DepartmentFilterInput DepartmentFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class DepartmentFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "Name")]
    public string? Name { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "Description")]
    public string? Description { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "Active")]
    public bool? Active { get; set; }
}
