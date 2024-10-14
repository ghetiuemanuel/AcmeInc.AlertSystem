using OptionOneTech.AlertSystem.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace OptionOneTech.AlertSystem.Lookup
{
    public interface ILookupRepository<TEntity>
    {
        Task<List<TEntity>> GetLookupListAsync(int skip, int take);
    }

}
