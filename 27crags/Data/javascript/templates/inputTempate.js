var data = '{{jsonData}}';

var count = 1;

var climbs = $.parseJSON(data);

$(climbs).each(function (i, climb) {

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
});


