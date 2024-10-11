using OptionOneTech.AlertSystem.Lookup;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Dtos;

namespace OptionOneTech.AlertSystem.Web.Extensions
{
    namespace OptionOneTech.AlertSystem.Web.Extensions
    {
        public static class LookupAppServiceExtension
        {
            public static async Task<List<LookupDto<Guid>>> FetchAll(this ILookupAppService<Guid> service)
            {
                var pageSize = 1000;
                var totalItemsCount = 0;
                var currentPage = 0;
                var allItems = new List<LookupDto<Guid>>();

                var page = await service.GetLookupAsync(new PagedResultRequestDto() { SkipCount = currentPage * pageSize, MaxResultCount = pageSize });

                totalItemsCount = (int)page.TotalCount;

                allItems.AddRange(page.Items);

                var totalPages = totalItemsCount / pageSize;

                while (currentPage < totalPages - 1)
                {
                    currentPage++;
                    page = await service.GetLookupAsync(new PagedResultRequestDto()
                    {
                        SkipCount = currentPage * pageSize,
                        MaxResultCount = pageSize
                    });

                    allItems.AddRange(page.Items);
                }
                return allItems;
            }                         
        }
    }
}
