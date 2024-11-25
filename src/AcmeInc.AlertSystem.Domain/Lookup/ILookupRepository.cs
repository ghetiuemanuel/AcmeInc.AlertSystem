using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeInc.AlertSystem.Lookup
{
    public interface ILookupRepository<TEntity>
    {
        Task<List<TEntity>> GetLookupListAsync(int skip, int take, bool includeInactive);
    }
}
