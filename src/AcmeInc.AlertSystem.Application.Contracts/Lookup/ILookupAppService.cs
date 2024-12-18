﻿using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace AcmeInc.AlertSystem.Lookup
{
    public interface ILookupAppService<TKey>
    {
        Task<PagedResultDto<LookupDto<TKey>>> GetLookupAsync(LookupRequestDto input);
        
    }
}
