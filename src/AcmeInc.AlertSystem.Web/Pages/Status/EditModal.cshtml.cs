using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AcmeInc.AlertSystem.Statuses;
using AcmeInc.AlertSystem.Statuses.Dtos;
using AcmeInc.AlertSystem.Web.Pages.Status.ViewModels;

namespace AcmeInc.AlertSystem.Web.Pages.Status;

public class EditModalModel : AlertSystemPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditStatusViewModel ViewModel { get; set; }

    private readonly IStatusAppService _service;

    public EditModalModel(IStatusAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<StatusDto, EditStatusViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditStatusViewModel, UpdateStatusDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}