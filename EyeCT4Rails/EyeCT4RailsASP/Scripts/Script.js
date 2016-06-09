var selectedTrackId;
var selectedSectionId;
var selectedTramId;

$(document)
    .ready(function () {
        //Means you're on the overview page of the depot.
        if ($("#contextMenu").hasClass("dropdown")) {
            bindEvents();

            function loop() {
                getReservedTrams();
                refreshDepot();

                setTimeout(loop, 2500);
            }

            loop();

            $(document)
                .on("click",
                    "a.list-group-item.reservation",
                    function () {
                        selectedTramId = $(this).attr("tramid");
                        getReservedTrams();
                    });


            $(document)
                .on("click",
                    "a.list-group-item.context",
                    function () {
                        if (selectedTramId != null) {
                            selectedTrackId = $(this).parent().children().first().text();
                            selectedSectionId = $(this).attr("sectionid");
                            refreshDepot();

                            $("#reservedButton").prop("disabled", false);
                        }
                    });

            $(document)
                .on("click",
                    "#reservedButton",
                    function () {
                        if (selectedSectionId != null && selectedTramId != null) {

                            $.post("/Depot/ReserveTram",
                                { trackId: selectedTrackId, sectionId: selectedSectionId, tramId: selectedTramId },
                                function (data) {
                                    var json = JSON.parse(data);
                                    if (json.status === "success") {
                                        selectedTrackId = null;
                                        selectedSectionId = null;
                                        selectedTramId = null;

                                        $("#reservedButton").prop("disabled", true);

                                        getReservedTrams();
                                        refreshDepot();
                                    } else {
                                        showAlert(json.message);
                                    }
                                });
                        }
                    });

        }

        if ($("#ride").length !== 0) {
            var tramId = -1;

            $(document).on("click", "#rideButton", function () {
                resetAlert();
                var assist = $("select[name='assist'] option:selected").val();
                tramId = parseInt($("#tramnumber").val());

                $.post("/Ride/GetSection", { tramnumber: tramId, assist: assist}, function (data) {
                    var json = JSON.parse(data);

                    if (json.status === "success") {
                        $("#trackId").html("<strong>Ga naar spoor: " + json.trackId + "</strong>");
                        $("#sectionId").html("<strong>Ga naar sectie: " + json.sectionId + "</strong>");
                    }
                    else if (json.instruction === true) {
                        $("#modal").modal("show");
                        $("#tramnumber").prop("disabled", true);
                        $("#rideButton").prop("disabled", true);

                        timer();
                    }
                    else
                    {
                        showAlert(json.message);
                    }
                });
            });

            function timer() {
                if (tramId == -1) {
                    return false;
                }

                $.post("/Ride/GetAssignedSection", { tramId: tramId }, function (data) {
                    var json = JSON.parse(data);

                    if (json.status === "success") {
                        $("#trackId").html("<strong>Ga naar spoor: " + json.trackId + "</strong>");
                        $("#sectionId").html("<strong>Ga naar sectie: " + json.sectionId + "</strong>");

                        $("#modal").modal("hide");
                        $("#tramnumber").prop("disabled", false);
                        $("#rideButton").prop("disabled", false);
                    }
                });

                if (tramId >= 0) {
                    setTimeout(timer, 2500);
                }
            }
        }
    });

(function ($, window) {
    $.fn.contextMenu = function (settings) {
        return this.each(function () {

            $(this).on("contextmenu", function (e) {
                if (e.ctrlKey) {
                    return true;
                }

                if ($(e.target).attr("sectionid") == null) {
                    return true;
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

function handleOption(invokedOn, selectedMenu) {
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
                refreshDepot();
                resetAlert();
            } else {
                showAlert(json.message);
            }
        });
    } else if (option === "Track (de)blokkeren") {
        $.post("/Depot/SetTrackBlocked", { trackId: trackId }, function (data) {
            var json = JSON.parse(data);
            if (json.status === "success") {
                refreshDepot();
                resetAlert();
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
                        refreshDepot();
                        resetAlert();
                    } else {
                        showAlert(json.message);
                    }
                });
            }
        } else if (option === "Tram verwijderen") {
            $.post("/Depot/RemoveTram", { trackId: trackId, sectionId: sectionId }, function (data) {
                var json = JSON.parse(data);
                if (json.status === "success") {
                    refreshDepot();
                    resetAlert();
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
                    refreshDepot();
                    resetAlert();
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

                        line += '<a trackid="' + track.Id + '" sectionid="' + section.Id + '" class="list-group-item ' + ((parseInt(section.Id) === parseInt(selectedSectionId) && selectedTramId != null) ? ("list-group-item-info ") : "") + 'context' + (section.Tram != null ? (" " + section.Tram.Status) : "") + (section.Blocked ? (" blocked") : "") + ' text-center">' + (section.Tram != null ? section.Tram.Id : "") + '</a>';
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

function getReservedTrams() {
    $.post("/Depot/GetReservedTrams", function (data) {
        var json = JSON.parse(data);
        if (json.status === "success") {
            var line = "";
            if (json.trams.length === 0) {
                line = '<a class="list-group-item"><h4 class="list-group-item-heading">Geen reserveringen</h4><p class="list-group-item-text">Er zijn op dit moment geen trams die assistentie nodig hebben.</p></a>';
            } else {
                var modalShown = false;
                for (var i = 0; i < json.trams.length; i++) {
                    var tram = json.trams[i];

                    if ($("a.list-group-item.reservation[tramid='" + parseInt(tram.Id) + "']").length === 0 && !modalShown) {
                        $("#modal").modal("show");
                        modalShown = true;
                    }

                    line += '<a tramid="' + tram.Id + '" class="list-group-item reservation' + (parseInt(tram.Id) === parseInt(selectedTramId) ? " active" : "") + '">' +
                        '<h4 class="list-group-item-heading">Tram #' + tram.Id + '</h4>' +
                        '<p class="list-group-item-text">' +
                        "Status: " + tram.Status + '<br/>' +
                        "Type: " + tram.TramType +
                        "</p>" +
                        "</a>";
                }
            }

            $("#reservedTrams").html(line);
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