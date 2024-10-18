using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OptionOneTech.AlertSystem.Lookup;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Messages.Dtos;
using OptionOneTech.AlertSystem.MessageSources;
using OptionOneTech.AlertSystem.Web.Pages.Message.ViewModels;
using Volo.Abp.Application.Dtos;

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

        var pagedRequest = new PagedResultRequestDto
        {
            MaxResultCount = 1000,
            SkipCount = 0
        };

        var emailSources = await _emailMessageSourceService.FetchAllLookups();

        ViewModel.SourceOptions = emailSources.Select(email => new SelectListItem
        {
            Value = email.Id.ToString(), 
            Text = email.Name,
        }).ToList();
    }
    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateMessageViewModel, CreateMessageDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}