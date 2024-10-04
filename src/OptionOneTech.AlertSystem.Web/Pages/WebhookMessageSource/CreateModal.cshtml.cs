using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.MessageSources;
using OptionOneTech.AlertSystem.MessageSources.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.WebhookMessageSource.ViewModels;

namespace OptionOneTech.AlertSystem.Web.Pages.WebhookMessageSource;

public class CreateModalModel : AlertSystemPageModel
{
    [BindProperty]
    public CreateWebhookMessageSourceViewModel ViewModel { get; set; }

    private readonly IWebhookMessageSourceAppService _service;

    public CreateModalModel(IWebhookMessageSourceAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateWebhookMessageSourceViewModel, CreateWebhookMessageSourceDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}