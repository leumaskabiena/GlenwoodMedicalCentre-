$(document).ready(function () {
        var url = "";
        $("#dialog-alert").dialog({
            autoOpen: false,
            resizable: false,
            height: 170,
            width: 350,
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(".ui-dialog-titlebar-close").hide();
            },
            buttons: {
                "OK": function () {
                    $(this).dialog("close");

                },
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });

        if ('@TempData["msg"]' != "") {
            $("#dialog-alert").dialog('open');
        }

        $("#dialog-edit").dialog({
            title: 'Create User',
            autoOpen: false,
            resizable: false,
            width: 650,
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).load(url);
            }
        });

        $("#dialog-editdetails").dialog({
            title: 'Edit Dependent Details',
            autoOpen: false,
            resizable: false,
            width: 700,
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).load(url);
            }
        });

        $("#dialog-delete").dialog({
            title: 'Delete ?',
            autoOpen: false,
            resizable: false,
            width: 600,
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).load(url);
            }
        });

        $("#dialog-confirm").dialog({
            autoOpen: false,
            resizable: false,
            height: 170,
            width: 350,
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(".ui-dialog-titlebar-close").hide();

            },
            buttons: {
                "OK": function () {
                    $(this).dialog("close");
                    window.location.href = url;
                },
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });

        $("#dialog-detail").dialog({
            title: 'Dependent Details',
            autoOpen: false,
            resizable: false,
            width: 600,
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).load(url);
            },
            buttons: {
                "Close": function () {
                    $(this).dialog("close");
                }
            }
        });

        $(document).on("click", "#lnkCreate", function (e) {
            //e.preventDefault(); //use this or return false
            url = $(this).attr('href');
            $("#dialog-edit").dialog('open');

            return false;
        });

        $(document).on("click", ".lnkEdit", function (e) {
            // e.preventDefault(); use this or return false
            url = $(this).attr('href');
            //$(".ui-dialog-title").html("Edit Patient Dependent");
            $("#dialog-editdetails").dialog('open');

            return false;
        });

        $(document).on("click", ".lnkDelete", function (e) {
        //$(".lnkDelete").live("click", function (e) {
            // e.preventDefault(); use this or return false
            url = $(this).attr('href');
            $("#dialog-delete").dialog('open');

            return false;
        });

        $(document).on("click", ".lnkDetail", function (e) {
        //$(".lnkDetail").live("click", function (e) {
            // e.preventDefault(); use this or return false
            url = $(this).attr('href');
            $("#dialog-detail").dialog('open');

            return false;
        });

        $(document).on("click", "#btncancel", function (e) {
            $("#dialog-edit").dialog('close');
            return false;
        });

        $(document).on("click", "#btncanceldetails", function (e) {
            $("#dialog-editdetails").dialog("close");
            return false;
        });

        $(document).on("click", "#btncanceldelete", function (e) {
            $("#dialog-delete").dialog("close");
            return false;
        });
    });