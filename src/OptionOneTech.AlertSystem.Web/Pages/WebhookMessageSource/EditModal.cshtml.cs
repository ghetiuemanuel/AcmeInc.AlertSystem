using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.MessageSources;
using OptionOneTech.AlertSystem.MessageSources.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.WebhookMessageSource.ViewModels;

namespace OptionOneTech.AlertSystem.Web.Pages.WebhookMessageSource;

public class EditModalModel : AlertSystemPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditWebhookMessageSourceViewModel ViewModel { get; set; }

    private readonly IWebhookMessageSourceAppService _service;

    public EditModalModel(IWebhookMessageSourceAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<WebhookMessageSourceDto, EditWebhookMessageSourceViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditWebhookMessageSourceViewModel, UpdateWebhookMessageSourceDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}