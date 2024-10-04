using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionOneTech.AlertSystem.Lookup
{
    public interface ILookupRepository<TEntity>
    {
        Task<List<TEntity>> GetLookupListAsync(int skip, int take);
    }

}
