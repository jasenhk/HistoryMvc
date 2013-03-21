// site.js
if (window.console == "undefined" || window.console == null) {
    window.console = {
        log: function () { }
    };
}

var History = window.History;
var State = History.getState();
var rootUrl = History.getRootUrl();

History.log('initial:', State.data, State.title, State.url);

$(function () {
    var $window = $(window);
    var $body = $(document.body);

    History.Adapter.bind(window, "statechange", function () {
        var state = History.getState();
        History.log("stateshange", state);
        $.ajax({
            url: state.url,
            method: 'POST',
            data: {},
            success: function (response) {
                $("#section-body").html(response)
            }
        });
    });

    $("body").on("click", "a", function (e) {
        e.preventDefault();
        var url = $(this).attr("href");
        var title = $(this).attr("title");
        var state = { data: title, url: url };
        History.log("pushstate", state)
        History.pushState(state, title, url);
    });
});