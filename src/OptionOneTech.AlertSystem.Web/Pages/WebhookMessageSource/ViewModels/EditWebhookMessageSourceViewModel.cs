using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace OptionOneTech.AlertSystem.Web.Pages.WebhookMessageSource.ViewModels;

public class EditWebhookMessageSourceViewModel
{
    [Display(Name = "WebhookMessageSourceTitle")]
    public string Title { get; set; }

    [Display(Name = "WebhookMessageSourceFrom")]
    public string From { get; set; }

    [Display(Name = "WebhookMessageSourceBody")]
    [TextArea(Rows = 4)]
    public string Body { get; set; }

    public bool Active { get; set; }
}
