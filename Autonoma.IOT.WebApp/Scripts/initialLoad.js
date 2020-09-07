$(document).ready(function () {

    // Configuracion de mensaje de bloqueo
    $.blockUI.defaults.message = "<H2>Cargando ...</H2>";
    $.blockUI.defaults.css.border = 'none';
    $.blockUI.defaults.css.padding = '15px';
    $.blockUI.defaults.css.backgroundColor = '#000';
    $.blockUI.defaults.css.opacity = .5;
    $.blockUI.defaults.css.color = '#fff';

    // Start Ajax global
    $(document).ajaxStart($.blockUI);

    // Stop Ajax global
    $(document).ajaxStop($.unblockUI);

    // Clase con formato de fecha dd-mm-yy
    $(".formatofecha").datepicker({
        dateFormat: "dd-mm-yy"
    });

    $.validator.addMethod('date',
    function (value, element, params) {
        if (this.optional(element)) {
            return true;
        }

        var ok = true;
        try {
            $.datepicker.parseDate('dd-mm-yy', value);
        }
        catch (err) {
            ok = false;
        }
        return ok;
    });
});

// Funcion para dar formato a una fecha 
function FormatoFecha(fecha, formato, conTiempo) {
    var nuevoformato;
    var dia = fecha.getDate();
    var mes = fecha.getMonth();
    mes = mes + 1;
    var anio = fecha.getFullYear();
    var minuto = fecha.getMinutes();
    var hora = fecha.getHours();
    var segundo = fecha.getSeconds();
    if (mes.toString().length === 1)
        mes = "0" + mes;
    if (dia.toString().length === 1)
        dia = "0" + dia;
    if (hora.toString().length === 1)
        hora = "0" + hora;
    if (minuto.toString().length === 1)
        minuto = "0" + minuto;
    if (segundo.toString().length === 1)
        segundo = "0" + segundo;


    switch (formato) {
        case "dd-mm-yyyy":
            nuevoformato = dia + "-" + mes + "-" + anio;
            break;
        case "yyyy-mm-dd":
            nuevoformato = anio + "-" + mes + "-" + dia;
            break;
        case "dd/mm/yyyy":
            nuevoformato = dia + "/" + mes + "/" + anio;
            break;
        case "MM/dd/yyyy":
            nuevoformato = mes + "/" + dia + "/" + anio;
            break;
        default: //"dd-mm-yyyy"
            nuevoformato = dia + "-" + mes + "-" + anio;

    }

    //HH:mm:ss
    if (conTiempo) {
        nuevoformato = nuevoformato + " " + hora + ":" + minuto + ":" + segundo;
    }

    return nuevoformato;
}