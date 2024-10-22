using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Messages.Dtos;
using OptionOneTech.AlertSystem.MessageSources;
using OptionOneTech.AlertSystem.Web.Pages.Message.ViewModels;

namespace OptionOneTech.AlertSystem.Web.Pages.Message;

public class CreateModalModel : AlertSystemPageModel
{
    [BindProperty]
    public CreateMessageViewModel ViewModel { get; set; }

    private readonly IMessageAppService _service;
    private readonly IEmailMessageSourceAppService _emailMessageSourceService;
    private readonly IWebhookMessageSourceAppService _webhookMessageSourceService;
    public CreateModalModel(IMessageAppService service, IEmailMessageSourceAppService emailMessageSourceAppService, IWebhookMessageSourceAppService webhookMessageSourceService)
    {
        _service = service;
        _emailMessageSourceService = emailMessageSourceAppService;
        _webhookMessageSourceService = webhookMessageSourceService;
    }
    public virtual async Task OnGet()
    {
        ViewModel = new CreateMessageViewModel();

        var emailSources = await _emailMessageSourceService.FetchAllLookups();
        var webhookSources = await _webhookMessageSourceService.FetchAllLookups();

        ViewModel.SourceOptions = new List<SelectListItem>();

        if (emailSources != null)
        {
            ViewModel.SourceOptions.AddRange(emailSources.Select(email => new SelectListItem
            {
                Value = email.Id.ToString(),
                Text = email.Name,
            }));
        }
        if (webhookSources != null)
        {
            ViewModel.SourceOptions.AddRange(webhookSources.Select(webhook => new SelectListItem
            {
                Value = webhook.Id.ToString(),
                Text = webhook.Name,
            }));
        }
    }
    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateMessageViewModel, CreateMessageDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}