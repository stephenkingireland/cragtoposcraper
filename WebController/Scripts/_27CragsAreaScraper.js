


var cragList = []
var elements = $("#mw-content-text").children;

for (i = 0; i < elements.length; i++) {


    var crag = {};

    crag.name = $(row).find(".name").html();
    crag.url = $(row).attr("href");

    cragList.push(crag);

}

    return cragList;

