using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace OptionOneTech.AlertSystem.Web.Pages.EmailMessageSource;

public class IndexModel : AlertSystemPageModel
{
    public EmailMessageSourceFilterInput EmailMessageSourceFilter { get; set; }
    
    public virtual async Task OnGetAsync()
    {
        await Task.CompletedTask;
    }
}

public class EmailMessageSourceFilterInput
{
    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "EmailMessageSourceHostname")]
    public string? Hostname { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "EmailMessageSourcePort")]
    public int? Port { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "EmailMessageSourceSSL")]
    public bool? SSL { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "EmailMessageSourceUsername")]
    public string? Username { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "EmailMessageSourcePassword")]
    public string? Password { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "EmailMessageSourceFolder")]
    public string? Folder { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "EmailMessageSourceDeleteAfterDownload")]
    public bool? DeleteAfterDownload { get; set; }

    [FormControlSize(AbpFormControlSize.Small)]
    [Display(Name = "EmailMessageSourceActive")]
    public bool? Active { get; set; }
}
