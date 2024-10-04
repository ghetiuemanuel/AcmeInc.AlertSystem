using System;
using System.ComponentModel.DataAnnotations;

namespace OptionOneTech.AlertSystem.Web.Pages.WebhookMessageSource.ViewModels;

public class CreateWebhookMessageSourceViewModel
{
    [Display(Name = "WebhookMessageSourceTitle")]
    public string Title { get; set; }

    [Display(Name = "WebhookMessageSourceFrom")]
    public string From { get; set; }

    [Display(Name = "WebhookMessageSourceBody")]
    public string Body { get; set; }
}
