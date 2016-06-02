$(document).ready(function () {
    bindEvents();
    //Means you're on the overview page of the depot.
    if ($("#contextMenu").hasClass("dropdown")) {
        function loop() {
            refreshDepot();

            setTimeout(loop, 2500);
        }

        loop();
    }
});

(function ($, window) {
    $.fn.contextMenu = function (settings) {
        return this.each(function () {

            $(this).on("contextmenu", function (e) {
                if (e.ctrlKey) {
                    return false;
                }

                var menu = $(settings.menuSelector)
                    .data("invokedOn", $(e.target))
                    .show()
                    .css({
                        position: "absolute",
                        left: getMenuPosition(e.clientX, "width", "scrollLeft"),
                        top: getMenuPosition(e.clientY, "height", "scrollTop")
                    })
                    .off("click")
                    .on("click", "a", function (e) {
                        menu.hide();

                        var invokedOn = menu.data("invokedOn");
                        var selectedMenu = $(e.target);

                        settings.menuSelected.call(this, invokedOn, selectedMenu);
                    });

                return false;
            });

            $("body").click(function () {
                $(settings.menuSelector).hide();
            });
        });

        function getMenuPosition(mouse, direction, scrollDir) {
            var win = $(window)[direction](),
                scroll = $(window)[scrollDir](),
                menu = $(settings.menuSelector)[direction](),
                position = mouse + scroll;

            if (mouse + menu > win && menu < mouse) {
                position -= menu;
            }

            return position;
        }

    };
})(jQuery, window);

function bindEvents() {
    $("#overview").contextMenu({
        menuSelector: "#contextMenu",
        menuSelected: handleOption
    });
}

function handleOption (invokedOn, selectedMenu) {
    var option = selectedMenu.text();
    var trackId = invokedOn.attr("trackid");
    if (trackId.isEmpty() || trackId.isNaN) {
        return;
    }

    var sectionId = invokedOn.attr("sectionid");
    if (sectionId.isEmpty() || sectionId.isNaN) {
        return;
    }

    if (option === "Sectie (de)blokkeren") {
        $.post("/Depot/SetSectionBlocked", { trackId: trackId, sectionId: sectionId }, function (data) {
            var json = JSON.parse(data);
            if (json.status === "success") {
                resetAlert();
                refreshDepot();
            } else {
                showAlert(json.message);
            }
        });
    } else if (option === "Track (de)blokkeren") {
        $.post("/Depot/SetTrackBlocked", { trackId: trackId }, function (data) {
            var json = JSON.parse(data);
            if (json.status === "success") {
                resetAlert();
                refreshDepot();
            } else {
                showAlert(json.message);
            }
        });
    } else {
        var tramId;

        if (option === "Tram plaatsen" || option === "Tram reserveren") {
            if (invokedOn.hasClass("blocked") || !invokedOn.text().isEmpty()) {
                showAlert("Op deze sectie kan geen tram geplaatst worden.");
                return;
            }

            tramId = prompt("Voeg hier a.u.b. het gewenste tramnummer in.", "");
            if (tramId.isEmpty() || isNaN(tramId)) {
                showAlert("Dit is geen juist gestructureerd tramnummer.");
            } else {
                $.post("/Depot/AddTram", { trackId: trackId, sectionId: sectionId, tramId: tramId, reserved: option === "Tram reserveren" }, function (data) {
                    var json = JSON.parse(data);
                    if (json.status === "success") {
                        resetAlert();
                        refreshDepot();
                    } else {
                        showAlert(json.message);
                    }
                });
            }
        } else if (option === "Tram verwijderen") {
            $.post("/Depot/RemoveTram", { trackId: trackId, sectionId: sectionId }, function (data) {
                var json = JSON.parse(data);
                if (json.status === "success") {
                    resetAlert();
                    refreshDepot();
                } else {
                    showAlert(json.message);
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
                var json = JSON.parse(data);
                if (json.status === "success") {
                    resetAlert();
                    refreshDepot();
                } else {
                    showAlert(json.message);
                }
            });
        } else {
            showAlert("Onbekende optie: " + option);
        }
    }
}

function refreshDepot() {
    $.post("/Depot/GetTracks", function (data) {
        var json = JSON.parse(data);
        if (json.status === "success") {
            var line = "";
            for (var i = 0; i <= (json.tracks.length / 12) ; i++) {
                line += '<div class="row">';

                var toDraw = json.tracks.length - 12 * i;
                var count = toDraw > 12 ? 12 : toDraw;

                for (var j = 0; j < count; j++) {
                    var index = j + 12 * i;
                    var track = json.tracks[index];

                    line += '<div class="col-md-1">';
                    line += '<div class="list-group overview">';

                    line += '<a class="list-group-item active text-center">' + track.Id + '</a>';

                    for (var k = 0; k < track.Sections.length; k++) {
                        var section = track.Sections[k];

                        line += '<a trackid="' + track.Id + '" sectionid="' + section.Id + '" class="list-group-item context' + (section.Tram != null ? (" " + section.Tram.Status) : "") + (section.Blocked ? (" blocked") : "") + ' text-center">' + (section.Tram != null ? section.Tram.Id : "") + '</a>';
                    }

                    line += "</div>";
                    line += "</div>";
                }

                line += "</div>";
                $("#overview").html(line);
            }
        } else {
            showAlert(json.message);
        }
    });
}

function showAlert(error) {
    if (error != null && !error.isEmpty()) {
        $("#overview-alert").text(error).fadeIn("slow");
        $("html, body").animate({ scrollTop: 0 }, "slow");
    }
}

function resetAlert() {
    $("#overview-alert").fadeOut("slow");
}

String.prototype.isEmpty = function () {
    return (this.length === 0 || !this.trim());
};