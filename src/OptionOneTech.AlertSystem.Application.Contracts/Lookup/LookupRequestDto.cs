﻿using Volo.Abp.Application.Dtos;

namespace OptionOneTech.AlertSystem.Lookup
{
    public class LookupRequestDto: PagedResultRequestDto
    {
        public bool IncludeInActive { get; set; }
    }
}
