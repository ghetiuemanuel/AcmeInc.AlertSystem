using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace OptionOneTech.AlertSystem.Web.Pages.Message.ViewModels;

public class CreateMessageViewModel
{
    [Display(Name = "MessageTitle")]
    public string Title { get; set; }

    [Display(Name = "MessageFrom")]
    public string From { get; set; }

    [Display(Name = "MessageSourceId")]
    public Guid SourceId { get; set; }

    [Display(Name = "MessageSourceType")]
    public string SourceType { get; set; }

    [Display(Name = "MessageBody")]
    public string Body { get; set; }
}
