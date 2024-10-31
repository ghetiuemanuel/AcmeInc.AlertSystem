using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Statuses;
using OptionOneTech.AlertSystem.Statuses.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Status.ViewModels;

namespace OptionOneTech.AlertSystem.Web.Pages.Status;

public class CreateModalModel : AlertSystemPageModel
{
    [BindProperty]
    public CreateStatusViewModel ViewModel { get; set; }

    private readonly IStatusAppService _service;

    public CreateModalModel(IStatusAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateStatusViewModel, CreateStatusDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}