using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Messages;
using OptionOneTech.AlertSystem.Messages.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Message.ViewModels;

namespace OptionOneTech.AlertSystem.Web.Pages.Message;

public class CreateModalModel : AlertSystemPageModel
{
    [BindProperty]
    public CreateMessageViewModel ViewModel { get; set; }

    private readonly IMessageAppService _service;

    public CreateModalModel(IMessageAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateMessageViewModel, CreateMessageDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}