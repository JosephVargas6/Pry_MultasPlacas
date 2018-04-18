var colNombreActual = "";
var colOrdenActual = "";

function mListarPlacas(paginaACtual) {
    var nroplaca = $("#txtPlaca").val();

    $.ajax({
        //data: "{'codRegistrador':'" + inCodigoRegistrador + "," + "codCliente':'" + inCodigoCliente + "," + "maxRows':'" + 10 + "," + "pagina':'" + paginaACtual + "," + "colNombre':'" + colNombreActual + "," + "colOrden':'" + colOrdenActual + "," + "codigoRegistrador':'" + idregistrador + "'}",
        data: JSON.stringify({ placa: nroplaca, maxRows: 10, pagina: paginaACtual, colNombre: colNombreActual, colOrden: colOrdenActual}),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "../../PlacasMultas.asmx/wsListarPlacas",

        beforeSend: function () {
        },
        success: function (e) {
            var objCalc = JSON.parse(e.d);
            var var_text = "<tbody>";;
            $("#navigation_all_total").children().remove(),
                    $(".loader").hide(),
                    $("table#table_list_placas").find("thead").remove().fadeOut("slow"),
                    $("table#table_list_placas").find("tbody").remove().fadeOut("slow");

            var t = $("table#table_list_placas").parent();
            t.find("div.alert-null-modal").remove().fadeOut("slow");

            if (var_text == "<tbody>", 0 == objCalc.length) {
                var o = $("table#table_list_placas").parent();
                o.append("<div class='alert-null col-xs-12 col-md-12'><p class='text-center'>No hay datos</p><div>").fadeIn("slow");
            } else {
                var w = $("table#table_list_placas").parent();
                w.find("div.alert-null").remove().fadeOut("slow");
                for (y = 0; y < objCalc.length; y++) {

                    var_text += "<tr>";
                    var_text += '<td>' + objCalc[y].placa + '</td><td>' + objCalc[y].falta + '</td><td>' + objCalc[y].fecfraccion + '</td><td>' + objCalc[y].importe + '</td><td>' + objCalc[y].estado + '</td>';
                    var_text += '</tr>';
                }

                var_text += "</tbody>";


                var_head = "<thead><tr><th>PLACA <span onclick='mOrdenarTablaVisitas(this,\"Placa\")' class='ordenador pull-right glyphicon " + (colOrdenActual == 'ASC' && colNombreActual == 'Placa' ? "glyphicon-arrow-up" : "glyphicon-arrow-down") + "' aria-hidden='true'></span></th><th>FALTA <span onclick='mOrdenarTablaVisitas(this,\"Falta\")' class='ordenador pull-right glyphicon " + (colOrdenActual == 'ASC' && colNombreActual == 'Falta' ? "glyphicon-arrow-up" : "glyphicon-arrow-down") + "' aria-hidden='true'></span></th><th>FECHA INFRACCION  <span onclick='mOrdenarTablaVisitas(this,\"FechaInfraccion\")' class='ordenador pull-right glyphicon " + (colOrdenActual == 'ASC' && colNombreActual == 'FechaInfraccion' ? "glyphicon-arrow-up" : "glyphicon-arrow-down") + "' aria-hidden='true'></span></th><th>IMPORTE <span onclick='mOrdenarTablaVisitas(this,\"Importe\")' class='ordenador pull-right glyphicon " + (colOrdenActual == 'ASC' && colNombreActual == 'Impprte' ? "glyphicon-arrow-up" : "glyphicon-arrow-down") + "' aria-hidden='true'></span></th><th>ESTADO <span onclick='mOrdenarTablaVisitas(this,\"Estado\")' class='ordenador pull-right glyphicon " + (colOrdenActual == 'ASC' && colNombreActual == 'Estado' ? "glyphicon-arrow-up" : "glyphicon-arrow-down") + "'  aria-hidden='true'></span></th></tr></thead>";




                $("table#table_list_placas").append(var_head).fadeIn("slow");
                $("table#table_list_placas").append(var_text).fadeIn("slow");


                var ae = "<ul class='pagination pull-right'>";
                if (paginaACtual > 1) {
                    ae = ae +
                    "<li class='page-item'>" +
                    "<a class='page-link' href='#' onclick='mListarPlacas(" + (paginaACtual - 1) + ")' aria-label='Previous'>" +
                    "<span aria-hidden='true'> « </span>" +
                    "<span class='sr-only'>Previous</span>" +
                    "</a>" +
                    "</li>";
                }
                if (objCalc[0].paginas > 1) {
                    ae = ae +
                    "<li class='page-item'>" +
                    '<input id="pag_buscar_propuestas" class="pag-text-input" type="text" onkeypress="mListarPlanesPag(event)" onkeydown="KeyDownBuscarClientePag(event)" value=' + paginaACtual + ' /> ' +
                    "</li>" +
                    "<li class='page-item pag-text-li'>" +
                    'De ' + objCalc[0].paginas
                    "</li>";
                }
                if (paginaACtual < objCalc[0].paginas) {
                    ae = ae + "" +
                    "<li class='page-item'>" +
                    "<a class='page-link' href='#'  onclick='mListarPlacas(" + (paginaACtual + 1) + ")' aria-label='Next'>" +
                    "<span aria-hidden='true'> » </span>" +
                    "<span class='sr-only'>Next</span>" +
                    "</a>" +
                    "</li>";
                }
                ae = ae + "</ul>";


                $("#navigation_all_total").html(ae);

            }
            console.log(e);
            console.log("exito");
        },
        error: function (e) {
            console.log("Error API")
        }
    });

}

//$(document).ready(function () {
//    $("#btnbuscarplacas").on("click", function () {
//        mListarPlacas(1);
//    });
//});

function mOrdenarTablaVisitas(el, columna) {

    colNombreActual = columna;

    if ($(el).hasClass("glyphicon-arrow-down")) {
        colOrdenActual = "ASC";
        $(el).removeClass("glyphicon-arrow-down");
        $(el).addClass("glyphicon-arrow-up");
    }
    else {
        colOrdenActual = "DESC";
        $(el).removeClass("glyphicon-arrow-up");
        $(el).addClass("glyphicon-arrow-down");
    }
    mListarPlacas(1);
}

function mListarPlanesPag(e, isPosicion) {
    if (13 == e.which) {
        mListarPlacas($("#pag_buscar_propuestas").val(), isPosicion);
    }
}

function KeyDownBuscarClientePag(event) {
    if (event.shiftKey) {
        event.preventDefault();
    }

    if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 13) {
    }
    else {
        if (event.keyCode < 95) {
            if (event.keyCode < 48 || event.keyCode > 57) {
                event.preventDefault();
            }
        }
        else {
            if (event.keyCode < 96 || event.keyCode > 105) {
                event.preventDefault();
            }
        }
    }
}