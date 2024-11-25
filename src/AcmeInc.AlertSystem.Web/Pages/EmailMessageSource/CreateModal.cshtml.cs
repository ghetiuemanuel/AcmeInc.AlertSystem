using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AcmeInc.AlertSystem.MessageSources;
using AcmeInc.AlertSystem.MessageSources.Dtos;
using AcmeInc.AlertSystem.Web.Pages.EmailMessageSource.ViewModels;

namespace AcmeInc.AlertSystem.Web.Pages.EmailMessageSource;

public class CreateModalModel : AlertSystemPageModel
{
    [BindProperty]
    public CreateEmailMessageSourceViewModel ViewModel { get; set; }

    private readonly IEmailMessageSourceAppService _service;

    public CreateModalModel(IEmailMessageSourceAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateEmailMessageSourceViewModel, EmailMessageSourceCreateDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}