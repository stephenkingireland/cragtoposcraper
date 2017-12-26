var data = '{{jsonData}}';

var count = 1;
var max = 50;
var min = 1;


var climbs = $.parseJSON(data);


for (var i = min; i < max && i < climbs.length ; i++) {

    var climb = climbs[i];

    $('[id$="' + count + '_name"]').val(climb.name);

    $('[id$="' + count + '_genre"]').val("Traditional");

    $('[id$="' + count + '_grade_info"]').val(climb.grade);

    if (climb.section) {
        $('[id$="' + count + '_sector_id"] option:contains(' + climb.section + ')').attr('selected', true);
    }

    $('[id$="' + count + '_grade"]').val(climb.frenchGrade)

    $('[id$="name"]').last().focus()
    $('[id$="name"]').last().focus()

    count++;
}

//just checking length to see if were done
climbs.length