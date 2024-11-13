async function fetchAll(getLookup, options) {
    var pageSize = 1000;
    var totalItemCount = 0;
    var currentPage = 0;
    var allItems = [];

    var page = await getLookup({ skipCount: currentPage * pageSize, maxResultCount: pageSize, IncludeInactive: options.includeInactive });
    totalItemCount = page.totalCount;

    for (var i = 0; i < page.items.length; i++) {
        allItems.push(page.items[i]);
    }
    var pages = totalItemCount / pageSize;

    while (currentPage < pages - 1) {
        currentPage++;
        page = await getLookup({ skipCount: currentPage * pageSize, maxResultCount: pageSize, IncludeInactive: options.includeInactive })
        for (var i = 0; i < page.items.length; i++) {
            allItems.push(page.items[i]);
        }
    }
    return { totalItemCount, items: allItems };
}