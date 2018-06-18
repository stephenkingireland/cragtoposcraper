

var cragList = []

$('.location ').each(
    function (i, row) {
        var crag = {};

        crag.name = $(row).find(".crag-name").html();
        crag.url = $(row).attr("href");

       cragList.push(crag);

    });


return cragList;
