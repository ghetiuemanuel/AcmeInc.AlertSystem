using System.ComponentModel.DataAnnotations;

namespace AcmeInc.AlertSystem.Web.Pages.EmailMessageSource.ViewModels;

public class CreateEmailMessageSourceViewModel
{
    [Display(Name = "EmailMessageSourceHostname")]
    public string Hostname { get; set; }

    [Display(Name = "EmailMessageSourcePort")]
    public int Port { get; set; }

    [Display(Name = "EmailMessageSourceSSL")]
    public bool SSL { get; set; }

    [Display(Name = "EmailMessageSourceUsername")]
    public string Username { get; set; }

    [Display(Name = "EmailMessageSourcePassword")]
    public string Password { get; set; }

    [Display(Name = "EmailMessageSourceFolder")]
    public string Folder { get; set; }

    [Display(Name = "EmailMessageSourceDeleteAfterDownload")]
    public bool DeleteAfterDownload { get; set; }

    [Display(Name = "EmailMessageSourceActive")]
    public bool Active { get; set; }
}
