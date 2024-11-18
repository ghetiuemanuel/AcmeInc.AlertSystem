using OptionOneTech.AlertSystem.Lookup;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class LookupAppServiceExtension
{
    public static async Task<List<LookupDto<TKey>>> FetchAllLookups<TKey>(this ILookupAppService<TKey> service, bool includeInactive = true)
    {
        var pageSize = 1000;
        var totalItemsCount = 0;
        var currentPage = 0;
        var allItems = new List<LookupDto<TKey>>();

        var page = await service.GetLookupAsync(new LookupRequestDto() { SkipCount = currentPage * pageSize, MaxResultCount = pageSize, IncludeInactive = includeInactive});

        totalItemsCount = (int)page.TotalCount;

        allItems.AddRange(page.Items);

        var totalPages = totalItemsCount / pageSize;

        while (currentPage < totalPages - 1)
        {
            currentPage++;
            page = await service.GetLookupAsync(new LookupRequestDto()
            {
                SkipCount = currentPage * pageSize,
                MaxResultCount = pageSize,
                IncludeInactive = includeInactive
            });

            allItems.AddRange(page.Items);
        }
        return allItems;
    }
}


