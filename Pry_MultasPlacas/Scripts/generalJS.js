 
function SetPerfilUsuario() {

    $.ajax({
        type: "POST",
        url: window.location.pathname,
        data: { idPerfilSelected: $("#PerfilSeleccionado").val() },
        success: function (data) {
            window.location.href = "../Posicion/Index";
        },
        dataType: "html"
    });

}

function capitalizar(str) {
    return str.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });
}

$(".numeros").keypress(function (key) {

    if (key.charCode < 48 || key.charCode > 57)
    {
        return false;
    }
});

$('.numeros').on("paste", function (e) {
    var regex = new RegExp("[0-9]");
    var str = e.originalEvent.clipboardData.getData('text');

    if (isNumeric(str))
    {
        return true;
    }
    number = str;
    e.preventDefault();

    return false; 
});

function isNumeric(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

$('.letras').on("cut copy paste", function (e) {
    var regex = new RegExp("^[a-zA ]+$");
    var str = e.originalEvent.clipboardData.getData('text');
    if (regex.test(str)) {
        return true;
    }
    e.preventDefault();
    return false; 
});

$('.alfanumerico').on("paste", function (e) {
    var regex = new RegExp("^[a-zA-Z0-9 .]+$");
    var str = e.originalEvent.clipboardData.getData('text');
    if (regex.test(str)) {
        return true;
    } 
    e.preventDefault();
    return false; 
});

$('.alfanumerico').keypress(function (e) {
    var regex = new RegExp("^[a-zA-Z0-9 .]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(str)) {
        return true;
    } 
    e.preventDefault();
    return false;
});

function MASK(form, n, mask, format) {
    if (format == "undefined") format = false;
    if (format || NUM(n)) {
        dec = 0, point = 0;
        x = mask.indexOf(".") + 1;
        if (x) { dec = mask.length - x; }

        if (dec) {
            n = NUM(n, dec) + "";
            x = n.indexOf(".") + 1;
            if (x) { point = n.length - x; } else { n += "."; }
        } else {
            n = NUM(n, 0) + "";
        }
        for (var x = point; x < dec ; x++) {
            n += "0";
        }
        x = n.length, y = mask.length, XMASK = "";
        while (x || y) {
            if (x) {
                while (y && "#0.".indexOf(mask.charAt(y - 1)) == -1) {
                    if (n.charAt(x - 1) != "-")
                        XMASK = mask.charAt(y - 1) + XMASK;
                    y--;
                }
                XMASK = n.charAt(x - 1) + XMASK, x--;
            } else if (y && "0".indexOf(mask.charAt(y - 1)) + 1) {
                XMASK = mask.charAt(y - 1) + XMASK;
            }
            if (y) { y-- }
        }
    } else {
        XMASK = "";
    }
    if (form) {
        form.value = XMASK;
        if (NUM(n) < 0) {
            form.style.color = "#FF0000";
        } else {
            form.style.color = "#000000";
        }
    }
    return XMASK;
}

function NUM(s, dec) {
    for (var s = s + "", num = "", x = 0 ; x < s.length ; x++) {
        c = s.charAt(x);
        if (".-+/*".indexOf(c) + 1 || c != " " && !isNaN(c)) { num += c; }
    }
    if (isNaN(num)) { num = eval(num); }
    if (num == "") { num = 0; } else { num = parseFloat(num); }
    if (dec != undefined) {
        r = .5; if (num < 0) r = -r;
        e = Math.pow(10, (dec > 0) ? dec : 0);
        return parseInt(num * e + r) / e;
    } else {
        return num;
    }
}

function obtenerNombreMes(inMes)
{
    switch (inMes)
    {
        case 1:
            return "Enero";
            break;
        case 2:
            return "Febrero";
            break;
        case 3:
            return "Marzo";
            break;
        case 4:
            return "Abril";
            break;
        case 5:
            return "Mayo";
            break;
        case 6:
            return "Junio";
            break;
        case 7:
            return "Julio";
            break;
        case 8:
            return "Agosto";
            break;
        case 9:
            return "Setiembre";
            break;
        case 10:
            return "Octubre";
            break;
        case 11:
            return "Noviembre";
            break;
        case 12:
            return "Diciembre";
            break;
        default:
            return "No mes";

    }
}


function validarEmail(strEmail)
{
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return emailReg.test(strEmail);
}



$('.clsValidarMaxLength').keypress(function (key) {
    var maxLength = $(this).attr("maxlength");

    if($(this).val().length == parseInt(maxLength))
    { 
            swal(
                  '¡Aviso!',
                  'Ha superado el número de caracteres permitidos para este campo.',
                  'warning'
            )
        return true
    }
});

function mValidarMaxLength(element)
{
    var maxLength = $(element).attr("maxlength");

    if ($(element).val().length == parseInt(maxLength)) {
        swal(
              '¡Aviso!',
              'Ha superado el número de caracteres permitidos para este campo.',
              'warning'
        )
        return true
    }
} 

function MASK(form, n, mask, format) {
    if (format == "undefined") format = false;
    if (format || NUM(n)) {
        dec = 0, point = 0;
        x = mask.indexOf(".") + 1;
        if (x) { dec = mask.length - x; }

        if (dec) {
            n = NUM(n, dec) + "";
            x = n.indexOf(".") + 1;
            if (x) { point = n.length - x; } else { n += "."; }
        } else {
            n = NUM(n, 0) + "";
        }
        for (var x = point; x < dec ; x++) {
            n += "0";
        }
        x = n.length, y = mask.length, XMASK = "";
        while (x || y) {
            if (x) {
                while (y && "#0.".indexOf(mask.charAt(y - 1)) == -1) {
                    if (n.charAt(x - 1) != "-")
                        XMASK = mask.charAt(y - 1) + XMASK;
                    y--;
                }
                XMASK = n.charAt(x - 1) + XMASK, x--;
            } else if (y && "0".indexOf(mask.charAt(y - 1)) + 1) {
                XMASK = mask.charAt(y - 1) + XMASK;
            }
            if (y) { y-- }
        }
    } else {
        XMASK = "";
    }
    if (form) {
        form.value = XMASK;
        if (NUM(n) < 0) {
            form.style.color = "#FF0000";
        } else {
            form.style.color = "#000000";
        }
    }
    return XMASK;
}