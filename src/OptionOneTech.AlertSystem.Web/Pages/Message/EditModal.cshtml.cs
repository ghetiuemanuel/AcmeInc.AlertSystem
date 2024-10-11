using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Messages.Dtos;
using OptionOneTech.AlertSystem.MessageSources;
using OptionOneTech.AlertSystem.Web.Extensions.OptionOneTech.AlertSystem.Web.Extensions;
using OptionOneTech.AlertSystem.Web.Pages.Message.ViewModels;


namespace OptionOneTech.AlertSystem.Web.Pages.Message;

public class EditModalModel : AlertSystemPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditMessageViewModel ViewModel { get; set; }

    private readonly IMessageAppService _service;
    private readonly IWebhookMessageSourceAppService _webhookMessageSourceAppService;

    public EditModalModel(IMessageAppService service, IWebhookMessageSourceAppService webhookMessageSourceAppService)
    {
        _service = service;
        _webhookMessageSourceAppService = webhookMessageSourceAppService;
    }

    public virtual async Task OnGetAsync()
    {  
        var allItems = await _webhookMessageSourceAppService.FetchAll();

        var dto = await _service.GetAsync(Id);

        ViewModel = ObjectMapper.Map<MessageDto, EditMessageViewModel>(dto);
        
        ViewModel.SourceOptions = allItems.Select(item => new SelectListItem
        {
            Value = item.Id.ToString(),
            Text = item.Name
        }).ToList();
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditMessageViewModel, UpdateMessageDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}
