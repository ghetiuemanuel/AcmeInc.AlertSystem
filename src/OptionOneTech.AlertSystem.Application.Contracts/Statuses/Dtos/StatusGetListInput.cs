﻿using Volo.Abp.Application.Dtos;

namespace OptionOneTech.AlertSystem.Statuses.Dtos
{
    public class StatusGetListInput : PagedAndSortedResultRequestDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool? Active { get; set; }
    }
}