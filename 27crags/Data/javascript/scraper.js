var list = [];

var currentSection ="";

$(".climb").each(
    function(i,val)
    {
        var climb = {};

        var section = $(val).prevAll(".buttress").first().text().trim();

        var grade = $(val).find("[nowrap*='nowrap']").text();

        var name = $(val).find(".name > a").text();
        
        
        climb.grade = grade.trim();
        climb.name = name;
        climb.section = !section ? currentSection : section;

        currentSection = climb.section;

        list.push(climb);
    }
)

JSON.stringify(list);