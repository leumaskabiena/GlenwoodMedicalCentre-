﻿$("#addItem").click(function () {
    $.ajax({
        url: this.href,
        cache: false,
        success: function (html) { $("#editorRows").append(html); }
    });
    return false;
});

$("a.deleteRow").live("click", function () {
    $(this).parents("div.editorRow:first").remove();
    return false;
});