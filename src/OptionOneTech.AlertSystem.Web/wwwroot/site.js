async function fetchAll(apiFunction, options = {}) {
    var pageSize = 1000;
    var totalItemCount = 0;
    var currentPage = 0;
    var allItems = [];

    var params = {
        skipCount: currentPage * pageSize,
        maxResultCount: pageSize,
    };

    for (var key in options) {
        params[key] = options[key];
    }

    var page = await apiFunction(params);

    totalItemCount = page.totalCount;

    for (var i = 0; i < page.items.length; i++) {
        allItems.push(page.items[i]);
    }

    var totalPages = totalItemCount / pageSize;

    while (currentPage < totalPages - 1) {
        currentPage++;

        params.skipCount = currentPage * pageSize;

        page = await apiFunction(params);

        for (var i = 0; i < page.items.length; i++) {
            allItems.push(page.items[i]);
        }
    }
    return { totalItemCount, items: allItems };
}