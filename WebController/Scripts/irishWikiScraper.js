


    var cragList = []

    $('.crag-card a').each(
        function (i, row) {
            var crag = {};

            crag.name = $(row).find(".name").html();
            crag.url = $(row).attr("href");

            cragList.push(crag);

        });


    return cragList;

