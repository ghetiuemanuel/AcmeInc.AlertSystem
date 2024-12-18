using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AcmeInc.AlertSystem.Levels;
using AcmeInc.AlertSystem.Levels.Dtos;
using AcmeInc.AlertSystem.Web.Pages.Level.ViewModels;

namespace AcmeInc.AlertSystem.Web.Pages.Level;

public class EditModalModel : AlertSystemPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditLevelViewModel ViewModel { get; set; }

    private readonly ILevelAppService _service;

    public EditModalModel(ILevelAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<LevelDto, EditLevelViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditLevelViewModel, UpdateLevelDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}