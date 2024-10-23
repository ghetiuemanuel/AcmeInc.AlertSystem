using Microsoft.AspNetCore.Mvc.Rendering;
using OptionOneTech.AlertSystem.Messages.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace OptionOneTech.AlertSystem.Web.Pages.Message.ViewModels;

public class EditMessageViewModel
{
    [Display(Name = "MessageTitle")]
    [TextArea(Rows = 4)]
    public string Title { get; set; }

    [Display(Name = "MessageFrom")]
    [TextArea(Rows = 4)]
    public string From { get; set; }

    [Display(Name = "MessageSourceType")]
    public SourceType SourceType { get; set; }

    [SelectItems(nameof(SourceOptions))]
    [Display(Name = "MessageSourceId")]
    public Guid SourceId { get; set; }

    [Display(Name = "MessageBody")]
    [TextArea(Rows = 4)]
    public string Body { get; set; }

    [Display(Name = "MessageProcessedAt")]
    public DateTime? ProcessedAt { get; set; }


    public List<SelectListItem> SourceOptions { get; set; } = new List<SelectListItem>();
}
