using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.MessageSources;
using OptionOneTech.AlertSystem.MessageSources.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.EmailMessageSource.ViewModels;

namespace OptionOneTech.AlertSystem.Web.Pages.EmailMessageSource;

public class EditModalModel : AlertSystemPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditEmailMessageSourceViewModel ViewModel { get; set; }

    private readonly IEmailMessageSourceAppService _service;

    public EditModalModel(IEmailMessageSourceAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<EmailMessageSourceDto, EditEmailMessageSourceViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditEmailMessageSourceViewModel, EmailMessageSourceUpdateDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}