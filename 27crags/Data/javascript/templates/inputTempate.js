﻿var data = {0};

var count = 1;

data.each(function (i, climb) {

    $('[id$="' + count + '_name"]').val(climb.name);

    $('[id$="' + count + '_genre"]').val("Traditional");

    $('[id$="' + count + '_grade"]').val(climb.frenchGrade);

    $('[id$="' + count + '_grade_info"]').val(climb.grade);

    $('[id$="' + count + '_sector_id"] option:contains(' + climb.section + ')').attr('selected', true);

    $('[id$="' + count + '_grade"]').val(climb.frenchGrade)

    $('[id$="name"]').last().focus()
    $('[id$="name"]').last().focus()

    count++;
});

