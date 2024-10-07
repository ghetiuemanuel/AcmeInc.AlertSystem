using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace OptionOneTech.AlertSystem.Lookup
{
    public interface ILookupAppService<TKey>
    {
        Task<PagedResultDto<LookupDto<TKey>>> GetLookupAsync(PagedAndSortedResultRequestDto input);
    }
}
