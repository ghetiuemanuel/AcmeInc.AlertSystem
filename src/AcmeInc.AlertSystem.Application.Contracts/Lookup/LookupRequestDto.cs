using Volo.Abp.Application.Dtos;

namespace AcmeInc.AlertSystem.Lookup
{
    public class LookupRequestDto: PagedResultRequestDto
    {
        public bool IncludeInactive { get; set; }
    }
}
