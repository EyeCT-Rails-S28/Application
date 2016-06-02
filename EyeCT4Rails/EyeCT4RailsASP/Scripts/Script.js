﻿(function ($, window) {

    $.fn.contextMenu = function (settings) {

        return this.each(function () {

            // Open context menu
            $(this).on("contextmenu", function (e) {
                // return native menu if pressing control
                if (e.ctrlKey) return false;

                //open menu
                var $menu = $(settings.menuSelector)
                    .data("invokedOn", $(e.target))
                    .show()
                    .css({
                        position: "absolute",
                        left: getMenuPosition(e.clientX, "width", "scrollLeft"),
                        top: getMenuPosition(e.clientY, "height", "scrollTop")
                    })
                    .off("click")
                    .on("click", "a", function (e) {
                        $menu.hide();

                        var $invokedOn = $menu.data("invokedOn");
                        var $selectedMenu = $(e.target);

                        settings.menuSelected.call(this, $invokedOn, $selectedMenu);
                    });

                return false;
            });

            //make sure menu closes on any click
            $('body').click(function () {
                $(settings.menuSelector).hide();
            });
        });

        function getMenuPosition(mouse, direction, scrollDir) {
            var win = $(window)[direction](),
                scroll = $(window)[scrollDir](),
                menu = $(settings.menuSelector)[direction](),
                position = mouse + scroll;

            // opening menu would pass the side of the page
            if (mouse + menu > win && menu < mouse)
                position -= menu;

            return position;
        }

    };
})(jQuery, window);

String.prototype.isEmpty = function () {
    return (this.length === 0 || !this.trim());
};

$(".context").contextMenu({
    menuSelector: "#contextMenu",
    menuSelected: function (invokedOn, selectedMenu) {
        var option = selectedMenu.text();
        if (option.isEmpty()) {
            return;
        }

        var trackId = invokedOn.attr("trackId");
        if (trackId.isEmpty() || trackId.isNaN) {
            return;
        }

        var sectionId = invokedOn.attr("sectionId");
        if (sectionId.isEmpty() || sectionId.isNaN) {
            return;
        }

        if (option === "Sectie (de)blokkeren") {
            var blocked = invokedOn.hasClass("blocked");

            $.post("/Depot/SetSectionBlocked", { trackId: trackId, sectionId: sectionId }, function (data) {
                if (data === "success") {
                    if (!blocked) {
                        invokedOn.addClass("blocked");
                    } else {
                        invokedOn.removeClass("blocked");
                    }
                } else {
                    alert(data);
                }
            });
        } else if (option === "Track (de)blokkeren") {
            $.post("/Depot/SetTrackBlocked", { trackId: trackId }, function (data) {
                if (data === "success") {
                    var allBlocked = true;

                    var list = invokedOn.parent().children();
                    list.each(function () {
                        var item = $(this);
                        if (item.attr("trackId") != null && !item.attr("trackId").isEmpty() && !item.attr("trackId").isNaN && !item.hasClass("blocked")) {
                            allBlocked = false;
                        }
                    });

                    list.each(function () {
                        var item = $(this);
                        if (item.attr("trackId") != null && !item.attr("trackId").isEmpty() && !item.attr("trackId").isNaN) {
                            if (!allBlocked) {
                                item.addClass("blocked");
                            } else {
                                item.removeClass("blocked");
                            }
                        }
                    });
                } else {
                    alert(data);
                }
            });
        } else {
            var tramId;

            if (option === "Tram plaatsen" || option === "Tram reserveren") {
                if (invokedOn.hasClass("blocked") || !invokedOn.text().isEmpty()) {
                    alert("Op deze sectie kan geen tram geplaatst worden.");
                    return;
                }

                tramId = prompt("Voeg hier a.u.b. het gewenste tramnummer in.", "");
                if (tramId.isEmpty() || isNaN(tramId)) {
                    alert("Dit is geen juist gestructureerd tramnummer.");
                } else {
                    $.post("/Depot/AddTram", { trackId: trackId, sectionId: sectionId, tramId: tramId, reserved: option === "Tram reserveren" }, function (data) {
                        if (data.startsWith("success")) {
                            var status = data.substring(8);
                            invokedOn.text(tramId);
                        
                            if (invokedOn.hasClass("Dienst")) {
                                invokedOn.removeClass("Dienst");
                            } else if (invokedOn.hasClass("Remise")) {
                                invokedOn.removeClass("Remise");
                            } else if (invokedOn.hasClass("Defect")) {
                                invokedOn.removeClass("Defect");
                            } else if (invokedOn.hasClass("Schoonmaak")) {
                                invokedOn.removeClass("Schoonmaak");
                            }

                            invokedOn.addClass(status);
                        } else {
                            alert(data);
                        }
                    });
                }
            } else if (option === "Tram verwijderen") {
                $.post("/Depot/RemoveTram", { trackId: trackId, sectionId: sectionId }, function (data) {
                    if (data === "success") {
                        invokedOn.text("");
                    } else {
                        alert(data);
                    }
                });
            } else if (option.startsWith("Verander status")) {
                tramId = invokedOn.text();
                if (tramId.isEmpty() || tramId.isNaN) {
                    return;
                }

                var status = option.substring(18);
                if (status.isEmpty()) {
                    return;
                }

                $.post("/Depot/ChangeStatus", { tramId: tramId, status: status }, function (data) {
                    if (data === "success") {
                        if (invokedOn.hasClass("Dienst")) {
                            invokedOn.removeClass("Dienst");
                        } else if (invokedOn.hasClass("Remise")) {
                            invokedOn.removeClass("Remise");
                        } else if (invokedOn.hasClass("Defect")) {
                            invokedOn.removeClass("Defect");
                        } else if (invokedOn.hasClass("Schoonmaak")) {
                            invokedOn.removeClass("Schoonmaak");
                        }

                        invokedOn.addClass(status);
                    } else {
                        alert(data);
                    }
                });
            } else {
                alert("Onbekende optie: " + option);
            }
        }
    }
});

function alert(error)
{
    if (error != null && !error.isEmpty()) {
        $("#overview-alert").text(error).fadeIn("slow");
        $("html, body").animate({ scrollTop: 0 }, "slow");
    }
}