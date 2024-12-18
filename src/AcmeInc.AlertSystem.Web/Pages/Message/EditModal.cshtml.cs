using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcmeInc.AlertSystem.Messages;
using AcmeInc.AlertSystem.Messages.Dtos;
using AcmeInc.AlertSystem.MessageSources;
using AcmeInc.AlertSystem.Web.Pages.Message.ViewModels;


namespace AcmeInc.AlertSystem.Web.Pages.Message;

public class EditModalModel : AlertSystemPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditMessageViewModel ViewModel { get; set; }

    private readonly IMessageAppService _service;
    private readonly IWebhookMessageSourceAppService _webhookMessageSourceAppService;
    private readonly IEmailMessageSourceAppService _emailMessageSourceAppService;

    public EditModalModel(IMessageAppService service, IWebhookMessageSourceAppService webhookMessageSourceAppService, IEmailMessageSourceAppService emailMessageSourceAppService)
    {
        _service = service;
        _webhookMessageSourceAppService = webhookMessageSourceAppService;
        _emailMessageSourceAppService = emailMessageSourceAppService;
    }

    public virtual async Task OnGetAsync()
    {
        var allItems = await _webhookMessageSourceAppService.FetchAllLookups();
        var emailItems = await _emailMessageSourceAppService.FetchAllLookups();

        var dto = await _service.GetAsync(Id);

        ViewModel = ObjectMapper.Map<MessageDto, EditMessageViewModel>(dto);
        ViewModel.SourceOptions = new List<SelectListItem>();

        if (ViewModel.SourceType == SourceType.Webhook)
        {
            ViewModel.SourceOptions.AddRange(allItems.Select(item => new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.Name,
                Selected = item.Id == ViewModel.SourceId
            }));
        }
        else if (ViewModel.SourceType == SourceType.Email)
        {
            ViewModel.SourceOptions.AddRange(emailItems.Select(item => new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.Name,
                Selected = item.Id == ViewModel.SourceId
            }));
        }
    }
    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditMessageViewModel, UpdateMessageDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }

}
