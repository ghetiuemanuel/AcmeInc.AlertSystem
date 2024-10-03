using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Levels;
using OptionOneTech.AlertSystem.Levels.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Level.ViewModels;

namespace OptionOneTech.AlertSystem.Web.Pages.Level;

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