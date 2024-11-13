
namespace OptionOneTech.AlertSystem.Lookup
{
    public class LookupDto<T>
    {
       public T Id { get; set; }
       public string Name { get; set; }
       public bool Active { get; set; }
       public override string ToString()
       {
          return Name;
       }
    }
}
