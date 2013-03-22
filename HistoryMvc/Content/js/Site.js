// Site.js
if (window.console == "undefined" || window.console == null) {
    window.console = {
        log: function () { }
    };
}

var History = window.History;
var State = History.getState();
var rootUrl = History.getRootUrl();

//History.log('initial:', State.data, State.title, State.url);

$(function () {
    var $window = $(window);
    var $body = $(document.body);

    History.Adapter.bind(window, "statechange", function () {
        var state = History.getState();
        History.log("stateshange", state);
        console.log(state.data.data);
        $.ajax({
            url: state.url,
            method: state.method,  // GET is having cache issues with IE
            data: state.data.data || {},
            success: function (response) {
                $("#section-body").html(response)
            }
        });
    });

    $("body").on("click", "a", function (e) {
        e.preventDefault();
        var url = $(this).attr("href");
        var title = $(this).attr("title");
        var state = { title: title, url: url, method: 'GET' };
        History.log("pushstate a", state)
        History.pushState(state, title, url);
    });

    $("body").on("submit", "#search-form", function (e) {
        e.preventDefault();
        var url = $(this).attr("action");
        var title = $(this).attr("title");
        var data = {
            Id: $(this).find("#field-id").val(),
            Name: $(this).find("#field-name").val()
        };
        var state = { title: title, url: url, method: 'GET', data: data };
        History.log("pushstate form", state)
        History.pushState(state, title, url + "?Id=" + data.Id + "&Name=" + data.Name);
    });
});