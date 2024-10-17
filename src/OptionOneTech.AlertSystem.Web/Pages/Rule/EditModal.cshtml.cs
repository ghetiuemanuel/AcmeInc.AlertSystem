using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Rules;
using OptionOneTech.AlertSystem.Rules.Dtos;
using OptionOneTech.AlertSystem.Web.Pages.Rule.ViewModels;

namespace OptionOneTech.AlertSystem.Web.Pages.Rule;

public class EditModalModel : AlertSystemPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditRuleViewModel ViewModel { get; set; }

    private readonly IRuleAppService _service;

    public EditModalModel(IRuleAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<RuleDto, EditRuleViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditRuleViewModel, RuleUpdateDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}