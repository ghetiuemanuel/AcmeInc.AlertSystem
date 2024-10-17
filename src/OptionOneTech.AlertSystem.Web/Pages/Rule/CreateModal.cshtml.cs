using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Rules;
using OptionOneTech.AlertSystem.Rules.Dtos;
using OptionOneTech.AlertSystem.Web.Pages;
using OptionOneTech.AlertSystem.Web.Pages.Rule.ViewModels;

namespace OptionOneTech.AlertSystem.Web.ViewModels.Rule;

public class CreateModalModel : AlertSystemPageModel
{
    [BindProperty]
    public CreateRuleViewModel ViewModel { get; set; }

    private readonly IRuleAppService _service;

    public CreateModalModel(IRuleAppService service)
    {
        _service = service;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateRuleViewModel, RuleCreateDto>(ViewModel);
        await _service.CreateAsync(dto);
        return NoContent();
    }
}