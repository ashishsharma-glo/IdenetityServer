$(document).ready(function() {
    var checkOneTouchStatus = function () {
        debugger;
        $.post("/Authy/OneTouchStatus")
            .done(function (data) {
                if (data === "approved" || data === "denied") {
                    debugger;
                    $("form").get(0).submit();
                } else {
                    setTimeout(checkOneTouchStatus, 2000);
                }
            }
        );
    }

    checkOneTouchStatus();
})