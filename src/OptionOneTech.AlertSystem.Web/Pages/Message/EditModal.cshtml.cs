using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Messages.Dtos;
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

    public EditModalModel(IMessageAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<MessageDto, EditMessageViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditMessageViewModel, UpdateMessageDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}