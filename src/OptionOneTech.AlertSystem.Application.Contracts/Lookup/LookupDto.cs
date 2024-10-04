using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionOneTech.AlertSystem.Lookup
{
    public class LookupDto<T>
    {
       public T Id { get; set; }
       public string Name { get; set; }
       public override string ToString()
       {
          return Name;
       }
    }
}
