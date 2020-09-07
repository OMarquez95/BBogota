function setEstado() {
    enableLoader();
    var dataform = new Object(); 
    dataform.estado = $("#checkEstado").is(":checked");
    EjecutarAjax(virtualDirectory + "TheDogChef/setEstado", "POST", dataform, resultadoAjax, null);
}

function addHora() {
    enableLoader();
    var dataform = new Object();
    var h = document.getElementById("addHora");
    var m = document.getElementById("addMinuto");
    dataform.hora = h.options[h.selectedIndex].innerHTML;
    dataform.minuto = m.options[m.selectedIndex].innerHTML;
    if (dataform.hora == "" || dataform.minuto == "") {
        showError("Seleccione una hora y minuto validos...");
        return;
    }
    EjecutarAjax(virtualDirectory + "TheDogChef/addHorario", "POST", dataform, resultadoAjaxAddHora, null);
}

function modHora(idConfiguracion) {
    enableLoader();
    var dataform = new Object();
    var h = document.getElementById("hora" + idConfiguracion);
    var m = document.getElementById("minuto" + idConfiguracion);
    dataform.hora = h.options[h.selectedIndex].innerHTML;
    dataform.minuto = m.options[m.selectedIndex].innerHTML;
    dataform.idConfiguracion = idConfiguracion;
    if (dataform.hora == "" || dataform.minuto == "") {
        showError("Seleccione una hora y minuto validos...");
        return;
    }
    EjecutarAjax(virtualDirectory + "TheDogChef/modHorario", "POST", dataform, resultadoAjaxModHora, null);
}

function delHora(idconfig) {
    enableLoader();
    var dataform = new Object();
    dataform.IdConfiguracion = idconfig;
    EjecutarAjax(virtualDirectory + "TheDogChef/delHorario", "POST", dataform, resultadoAjaxDelHora, null);
}


function resultadoAjaxAddHora(data) {
    hideError();
    hideInfo();
    if (data.Error) {
        showError(data.message);
    }
    else {
        //Actualizardiv con los resultados de la configuración, otro llamado ajax        
        var hora = data.hora;
        var minuto = data.minuto;
        var idConfiguracion = data.idConfiguracion;
       
        var html = '<div class="row" style="width:75%;margin:0 auto;background-color:whitesmoke" id="' + idConfiguracion + '"> ';
        $("#configuracionDiv").append(html + "<p>Hora" + hora + "  Minuto" + minuto + " id" + idConfiguracion +"</p > <div>");
        showInfo("Configuración adicionada exitosamente.");
    }
}

function resultadoAjaxModHora(data) {
    hideError();
    hideInfo();
    if (data.Error) {
        showError(data.message);
    }
    else {
        showInfo("Hora modificada exitosamente.");
    }
}

function resultadoAjaxDelHora(data) {
    hideError();
    hideInfo();
    if (data.Error) {
        showError(data.message);
    }
    else {        
        //Actualizardiv con los resultados de la configuración, otro llamado ajax quitar de la pagina
        $("#" + data.idConfiguracion).remove();
        showInfo("Se ha eliminado la configuración.");
    }
}

function resultadoAjax(data) {
    hideError();
    hideInfo();
    if (data.Error) {
        showError(data.message);
    }
    else {      
        showInfo(data.message);
    }
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


var hideInfo = function () {

    $("#success").hide();
    $("#success").empty();

}

var hideError = function () {

    $("#error").hide();
    $("#error").empty();

}

var showError = function (mesage) {

    $("#error").show();
    $("#error").html(mesage);

}

var showInfo = function (mesage) {

    $("#success").show();
    $("#success").html(mesage);

}