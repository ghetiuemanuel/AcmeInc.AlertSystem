using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.MessageSources;
using OptionOneTech.AlertSystem.MessageSources.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.EmailMessageSource.ViewModels;

namespace OptionOneTech.AlertSystem.Web.Pages.EmailMessageSource;

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