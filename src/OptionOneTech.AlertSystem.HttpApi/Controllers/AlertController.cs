using Microsoft.AspNetCore.Mvc;
using OptionOneTech.AlertSystem.Alerts;
using OptionOneTech.AlertSystem.Alerts.Dtos;
using OptionOneTech.AlertSystem.Statuses.Dtos;
using OptionOneTech.AlertSystem.Statuses;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;



namespace OptionOneTech.AlertSystem.Controllers
{
    [Route("api/alert")]
    [ApiController]
    public class AlertController: ControllerBase
    {
        private readonly IAlertAppService _alertAppService;

        public AlertController(IAlertAppService alertAppService)
        {
            _alertAppService = alertAppService;
        }
        [Route("update-status")]
        [HttpPost]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateAlertStatusDto input)
        {
            if (input == null)
                return BadRequest("Invalid request data!");
            await _alertAppService.UpdateAlertStatusAsync(input.AlertId, input.StatusId);
            return NoContent();
        }
    }
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusAppService _statusAppService;

        public StatusController(IStatusAppService statusAppService)
        {
            _statusAppService = statusAppService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusDto>>> GetStatuses([FromQuery] PagedResultRequestDto input)
        {
            var statuses = await _statusAppService.GetLookupAsync(input);
            return Ok(statuses);
        }
    }
}
