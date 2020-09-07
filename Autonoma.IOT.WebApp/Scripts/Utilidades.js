/**
* Autor Juan Manuel Gómez
* Plugin de utilidades para carga de controles, mensajes, ayuda, modales
* Requiere jQuery, bootstrap
* 2018-05-05
**/


(function ($) {

    /**
     * Crea una ventana modal para mostrar mensajes de (alerta, notificacion)
     * @parametros: titulo -> Titulo de la ventana modal
     *              mensaje -> Mensaje de la alerta a mostrar 
    **/
    $.alerta = function (options) {

        var settings = {
            titulo: 'Titulo Alerta',
            mensaje: 'Mensaje html',
            aceptar: function () { },
            alerta: false,
            informacion: false,
            confirmacion: false,
            exitoso: false
        };

        // integramos los valores pasados por parametros con los por defecto
        if (options) { $.extend(settings, options); }

        var nombreContenedor = 'contenMensaje';
        var nombreModal = 'mdlMensaje';
        var imageBase64 = 'icono-alerta';
        var imagen = '';

        var mostrarCancelar = true;
        var eventCerrar = '';

        if (settings.alerta == false && settings.informacion == false && settings.confirmacion == false && settings.exitoso == false) {
            settings.alerta = true;
        }


        if (settings.alerta == true) {

            imageBase64 = 'icono-alerta';
            mostrarCancelar = false;
            eventCerrar = 'data-dismiss="modal"';
            imagen = '<i class="fa fa-exclamation-triangle fa-5x" style="color:#FF9A01"></i>';

        } else if (settings.informacion == true) {

            imageBase64 = 'icono-informacion';
            mostrarCancelar = false;
            eventCerrar = 'data-dismiss="modal"';
            imagen = '<i class="fa fa-exclamation-circle fa-5x" style="color:#0570B2"></i>';

        } else if (settings.confirmacion == true) {

            imageBase64 = 'icono-confirmacion';
            imagen = '<i class="fa fa-question-circle fa-5x" style="color:#FF5801"></i>';

            $("#btnMdlAceptar").click(function () {
                settings.aceptar;
            });

        } else if (settings.exitoso == true) {

            imageBase64 = 'icono-informacion';
            mostrarCancelar = false;
            eventCerrar = 'data-dismiss="modal"';
            imagen = '<i class="fa fa-check-circle fa-5x" style="color:#85C331"></i>';
        }

        /* Si existe la ventana se borra */
        if ($("#" + nombreContenedor).length > 0) {
            $("#" + nombreContenedor).remove();
        }

        /* Generamos el html de la ventana modal*/
        var ventana = '<div id="' + nombreContenedor + '">';
        ventana += '    <div id="' + nombreModal + '" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="modal-title">';
        ventana += '        <div class="modal-dialog" role="document">';
        ventana += '            <div class="modal-content">';
        ventana += '                <div class="modal-header">';
        ventana += '                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>';
        ventana += '                    <h3 class="modal-title" id="modal-title">' + settings.titulo + '</h3>';
        ventana += '                </div>';
        ventana += '                <div id="modal-body" class="modal-body">';
        ventana += '                    <div class="row">';
        ventana += '                        <div class="col-lg-2 col-md-2 col-xs-4 text-center">';
        ventana += '                            '+ imagen;
        ventana += '                        </div>';
        ventana += '                        <div class="col-lg-10 col-md-10 col-xs-8">' + settings.mensaje + '</div>';
        ventana += '                    </div>';
        ventana += '                </div>';
        ventana += '                <div class="modal-footer">';
        ventana += '                    <button id="btnMdlAceptar" type="button" class="btn btn-primary" ' + eventCerrar + '><i class="fa fa-check"></i> Aceptar</button>';

        if (mostrarCancelar) {
            ventana += '                <button id="btnMdlCancelar" type="button" class="btn btn-default" data-dismiss="modal"><i class="fa fa-times"></i> Cancelar</button>';
        }

        ventana += '                </div>';
        ventana += '            </div>';
        ventana += '        </div>';
        ventana += '    </div>';
        ventana += '</div>';


        $('body').append(ventana);
        $("#" + nombreModal).modal('show');

        $("#btnMdlAceptar").bind('click', settings.aceptar);

        $("#btnMdlAceptar").click(function () {
            $("#btnMdlCancelar").click();
        });
    }

    /*
    * Formatera Fecha con Hora Javascript
    * @param: fecha => Fecha a formatear
    * @param: formato => Formatos de la fecha "dd-mm-yyyy", "yyyy-mm-dd", "dd/mm/yyyy", "MM/dd/yyyy"  
    * @param: mostrarHora => Indicador si muestra o no la hora
    */
    $.formatearFecha = function (options) {

        var settings = {
            fecha: "",
            formato: "dd-mm-yyyy",
            mostrarHora: false
        };

        // integramos los valores pasados por parametros con los por defecto
        if (options) { $.extend(settings, options); }

        if (settings.fecha == "") {
            return "";
        }
        var nuevoformato;

        var dia = settings.fecha.getDate();
        var mes = settings.fecha.getMonth();
        mes = mes + 1;
        var anio = settings.fecha.getFullYear();
        var minuto = settings.fecha.getMinutes();
        var hora = settings.fecha.getHours();
        var segundo = settings.fecha.getSeconds();

        if (mes.toString().length === 1) { mes = "0" + mes; }
        if (dia.toString().length === 1) { dia = "0" + dia; }
        if (hora.toString().length === 1) { hora = "0" + hora; }
        if (minuto.toString().length === 1) { minuto = "0" + minuto; }
        if (segundo.toString().length === 1) { segundo = "0" + segundo; }

        switch (settings.formato) {
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

        // HH:mm:ss
        if (settings.mostrarHora) {
            nuevoformato = nuevoformato + " " + hora + ":" + minuto + ":" + segundo;
        }

        return nuevoformato;
    }

}(jQuery));

//===============================================================================================================================

$(document).ready(function () {

    $('[data-tipo-dato="texto"]').on("keyup blur", function () {
        this.value = (this.value + '').replace(/[^A-Z a-zÑñáéíóúÁÉÍÓÚ]/g, '');
    });

    $('[data-tipo-dato="alfanumerico"]').on("keyup blur", function () {
        this.value = (this.value + '').replace(/[^0-9A-Z a-zÑñáéíóúÁÉÍÓÚ]/g, '');
    });

    $('[data-tipo-dato="numerico"]').on("keyup blur", function () {
        this.value = (this.value + '').replace(/[^0-9]/g, '');
    });

    $('[data-tipo-dato="decimal"]').on("keyup blur", function () {
        this.value = (this.value + '').replace(/[^0-9,]/g, '');
    });

    $('[data-tipo-dato="numero-coma"]').on("keyup blur", function () {
        this.value = (this.value + '').replace(/[^0-9,]/g, '');
    });

    $('[data-tipo-dato="fecha"]').on("keyup blur", function () {
        this.value = (this.value + '').replace(/[^0-9\-/.]/g, '');
    });

    //$('.texto-numero-guion').on("keyup blur", function () {
    //    this.value = (this.value + '').replace(/[^0-9A-Z a-zÑñáéíóúÁÉÍÓÚ-]/g, '');
    //});

    //$('.texto-numero-punto').on("keyup blur", function () {
    //    this.value = (this.value + '').replace(/[^0-9A-Z a-zÑñáéíóúÁÉÍÓÚ\.]/g, '');
    //});

    //$('.texto-numero-sintildes').on("keyup blur", function () {
    //    this.value = (this.value + '').replace(/[^0-9A-Z a-z]/g, '');
    //});

});

//===============================================================================================================================


/*
* Mensaje de alerta
* @param: _mensaje => Mensaje que se va mostrar
*/
var Exitoso = function (_mensaje) {
    $.alerta({
        titulo: "¡ATENCIÓN!",
        mensaje: _mensaje,
        exitoso: true
    });
}
/*
* Mensaje de alerta
* @param: _mensaje => Mensaje que se va mostrar
*/
var Alerta = function (_mensaje) {
    $.alerta({
        titulo: "¡ATENCIÓN!",
        mensaje: _mensaje,
        alerta: true
    });
}

/*
* Mensaje de alerta
* @param: _mensaje => Mensaje que se va mostrar
* @param: _eventoAceptar => Funcion a ejecutar en el boton aceptar
*/
var AlertarEvento = function (_mensaje, _eventoAceptar) {
    $.alerta({
        titulo: "¡ATENCIÓN!",
        mensaje: _mensaje,
        alerta: true,
        aceptar: _eventoAceptar
    });
}

/*
* Mensaje de Informacion
* @param: _mensaje => Mensaje que se va mostrar
*/
var Informacion = function (_mensaje) {
    $.alerta({
        titulo: "¡INFORMACIÓN!",
        mensaje: _mensaje,
        informacion: true
    });
}

/*
* Mensaje de Confirmacion
* @param: _mensaje => Mensaje que se va mostrar
* @param: _eventoAceptar => Funcion a ejecutar en el boton aceptar
*/
var Confirmacion = function (_mensaje, _eventoAceptar) {
    $.alerta({
        titulo: "¡CONFIRMACIÓN!",
        mensaje: _mensaje,
        confirmacion: true,
        aceptar: _eventoAceptar
    });
}

/*
* Formatera Fecha Javascript
* @param: _fecha => Fecha a formatear
* @param: _formato => Formatos de la fecha "dd-mm-yyyy", "yyyy-mm-dd", "dd/mm/yyyy", "MM/dd/yyyy"  
*/
var FormatearFecha = function(_fecha, _formato){
    $.formatearFecha({
        fecha: _fecha,
        formato: _formato,
        mostrarHora: false
    });
}

/*
* Formatera Fecha con Hora Javascript
* @param: _fecha => Fecha a formatear
* @param: _formato => Formatos de la fecha "dd-mm-yyyy", "yyyy-mm-dd", "dd/mm/yyyy", "MM/dd/yyyy"  
*/
var FormatearFechaHora = function (_fecha, _formato) {
    $.formatearFecha({
        fecha: _fecha,
        formato: _formato,
        mostrarHora: true
    });
}

var EjecutarAjax = function (url, type, values, funcionSuccess, variable) {

    //iniciarProceso();
    var types = ["POST", "PUT", "DELETE"];


    $.ajax({
        cache: false,
        url: url,
        type: type,
        data: values,
        success: function (data) {
            if (funcionSuccess !== undefined)
                funcionSuccess(data, variable);
        },
        error: function (jqXHR, exception) {
            var errorAjax = "";
            if (jqXHR.status === 0) {
                errorAjax += "<i> No cuenta con conexion a internet, \xF3 su sesion ha caducado.</i>";
                showError("Error! ", errorAjax);
                return;
            } else if (jqXHR.status === 404) {
                showError("Error!" + jqXHR.status + ".");
            } else if (jqXHR.status === 500) {
                showError("Error!" + jqXHR.status + ".");
            } else if (exception === "parsererror") {
                errorAjax += "<i>  Error al convertir el objeto en JSON</i>";
            } else if (exception === "timeout") {
                errorAjax += "<i>  Tiempo de espera agotado. Por favor comuniquese con el administrador del sistema</i>";
            } else if (exception === "abort") {
                errorAjax += "<i>  Petici�n AJAX abortada. Por favor comuniquese con el administrador del sistema</i>";
            } else {
                errorAjax += "<i>  Error inesperado (" + jqXHR.responseText + "). Por favor comuniquese con el administrador del sistema</i>";
            }
            if (errorAjax !== "") {
                showError("Error!" + errorAjax);
            }
        },
        complete: function (data) {

        }

    });



};


var showError = function (mesage) {

    $("#error").show();
    $("#error").html(mesage);

}

var hideError = function () {

    $("#error").hide();
    $("#error").empty();

}

var showInfo = function (mesage) {

    $("#info").show();
    $("#info").html(mesage);

}

var hideInfo = function () {

    $("#info").hide();
    $("#info").empty();

}

var enableLoader = function () {
    $.blockUI.defaults.message = "<H2>Cargando ...</H2>";
    $.blockUI.defaults.css.border = 'none';
    $.blockUI.defaults.css.padding = '15px';
    $.blockUI.defaults.css.backgroundColor = '#000';
    $.blockUI.defaults.css.opacity = .5;
    $.blockUI.defaults.css.color = '#fff';

    // Start Ajax global
    $(document).ajaxStart($.blockUI);


    $(document).ajaxStop($.unblockUI);
}



