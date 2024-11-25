using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace AcmeInc.AlertSystem.Web.Pages.WebhookMessageSource.ViewModels;

public class CreateWebhookMessageSourceViewModel
{
    [Display(Name = "WebhookMessageSourceTitle")]
    public string Title { get; set; }

    [Display(Name = "WebhookMessageSourceFrom")]
    public string From { get; set; }

    [Display(Name = "WebhookMessageSourceBody")]
    [TextArea(Rows = 4)]
    public string Body { get; set; }

    [Display(Name = "WebhookMessageSourceActive")]
    public bool Active { get; set; }
}
