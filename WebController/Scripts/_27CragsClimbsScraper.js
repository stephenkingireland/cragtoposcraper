

var climbList = []
if (window.config.rowsCopy) (

    $(window.config.rowsCopy).each(
        function (i, row) {

            var climb = {};

            climb.name = $(row[0]).find(".txt .hidden").text();
            climb.grade = $(row[0]).find(".grade").text();
            climb.sector = $(row[0]).find("td:nth-child(6)").text();
            climb.type = $(row[0]).find("td:nth-child(3)").text();

            climbList.push(climb);


        })
);

return climbList;
