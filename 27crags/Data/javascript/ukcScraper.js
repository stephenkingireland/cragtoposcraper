var list = [];

var currentSection ="";
var ajaxRunning = 0;

$(".climb").each(
    function (i, val) {
        var climb = {};

        var section = $(val).prevAll(".buttress").first().text().trim();

        var grade = $(val).find("[nowrap*='nowrap']").text();

        var name = $(val).find(".name > a").text();


        climb.grade = grade.trim();
        climb.name = name;
        climb.section = !section ? currentSection : section;

        currentSection = climb.section;

        //Not working, just goes into infinite loop

        // var infoButton = $(val).find(".climb_info_button");


        //if (infoButton)
        //{
        //    var s = $(infoButton).parent().parent().data("id");
        //
        //            var i = $.ajax({
        //                url: API + "/site/logbook/v1/climb_ukc/",
        //                method: "GET",
        //                data: {
        //                    id: s,
        //                    crag: id,
        //                    auth: auth
        //                }
        //            });
        //            ajaxRunning++;
        //
        //            i.done(function (t) {
        //                climb.info = t;
        //                ajaxRunning--;
        //
        //           });
        //        }




        list.push(climb);
    }
);


JSON.stringify(list);

