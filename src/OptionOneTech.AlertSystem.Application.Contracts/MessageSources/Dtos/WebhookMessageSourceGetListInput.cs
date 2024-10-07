using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace OptionOneTech.AlertSystem.MessageSources.Dtos
{
    public class WebhookMessageSourceGetListInput : PagedAndSortedResultRequestDto
    {
        public string? Title { get; set; }

        public string? From { get; set; }

        public string? Body { get; set; }
    }

}
