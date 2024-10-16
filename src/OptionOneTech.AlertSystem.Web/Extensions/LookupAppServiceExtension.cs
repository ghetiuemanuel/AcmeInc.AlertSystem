using OptionOneTech.AlertSystem.Lookup;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

public static class LookupAppServiceExtension
{
    public static async Task<List<LookupDto<TKey>>> FetchAll<TKey>(this ILookupAppService<TKey> service)
    {
        var pageSize = 1000;
        var totalItemsCount = 0;
        var currentPage = 0;
        var allItems = new List<LookupDto<TKey>>();

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


