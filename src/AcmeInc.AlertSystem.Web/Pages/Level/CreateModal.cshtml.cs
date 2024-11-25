using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AcmeInc.AlertSystem.Levels;
using AcmeInc.AlertSystem.Levels.Dtos;
using AcmeInc.AlertSystem.Web.Pages.Level.ViewModels;

namespace AcmeInc.AlertSystem.Web.Pages.Level;

public class CreateModalModel : AlertSystemPageModel
{
    [BindProperty]
    public CreateLevelViewModel ViewModel { get; set; }

    private readonly ILevelAppService _service;

    public CreateModalModel(ILevelAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateLevelViewModel, CreateLevelDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}