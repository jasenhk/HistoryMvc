// site.js

var History = window.History;
var State = History.getState();
var rootUrl = History.getRootUrl();

History.log('initial:', State.data, State.title, State.url);
console.log("outer");

$(function () {
    var $window = $(window);
    var $body = $(document.body);

    History.Adapter.bind(window, "statechange", function () {
        var state = History.getState();
        History.log("stateChange", state);
        $.ajax({
            url: state.url,
            method: 'POST',
            data: {},
            success: function (response) {
                $("#section-body").html(response)
            }
        });
    });

    $("a").on("click", function (e) {
        e.preventDefault();
        var url = $(this).attr("href");
        var title = "ajax";
        History.pushState({ data: title }, title, url);
    });
});