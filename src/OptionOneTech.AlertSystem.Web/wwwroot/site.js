async function fetchAll(apiFunction, options = {}) {
    var pageSize = 1000;
    var totalItemCount = 0;
    var currentPage = 0;
    var allItems = [];

    var params = {
        skipCount: currentPage * pageSize,
        maxResultCount: pageSize
    };

    for (var key in options) {
        params[key] = options[key];
    }

    var page = await apiFunction(params);
    totalItemCount = page.totalCount;

    allItems = allItems.concat(page.items);

    var totalPages = Math.ceil(totalItemCount / pageSize);

    while (currentPage < totalPages - 1) {
        currentPage++;
        params.skipCount = currentPage * pageSize;
        page = await apiFunction(params);
        allItems = allItems.concat(page.items);
    }
    return { totalItemCount: totalItemCount, items: allItems };
}
