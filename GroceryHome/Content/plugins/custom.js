function ShowNotify(_message, _type, _postion) {
    setTimeout(function () {
        $.notify({
            message: _message
        },
        {
            type: _type,
            placement: {
                from: _postion
            },
            animate: {
                enter: "animated fadeInRight",
                exit: "animated fadeOutRight"
            },
            newest_on_top: false
        });
    }, 500);
}

function isEmpty(str) {
    return (!str || 0 === str.length);
}

$(function () {
    if ($.validator != null) {
        $.validator.addMethod('date',
        function (value, element) {
            if (this.optional(element)) {
                return true;
            }
            var ok = true;
            try {
                $.datepicker.parseDate('dd/mm/yy', value);
            }
            catch (err) {
                ok = false;
            }
            return ok;
        });
        $(".datefield").datepicker({ dateFormat: 'dd/mm/yy', changeYear: true });
    }
});

function createCookie(name, value, minutes) {
    if (minutes) {
        var date = new Date();
        date.setTime(date.getTime() + (minutes * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function eraseCookie(name) {
    createCookie(name, "", -1);
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return "";
}