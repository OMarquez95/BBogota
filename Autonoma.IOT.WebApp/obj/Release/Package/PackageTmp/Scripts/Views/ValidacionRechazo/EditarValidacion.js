$(document).ready(function () {

    $("#btnGuardar").click(function () {
        $("#frmEditarRechazo").submit();
    });

    $("#btnCancelar").click(function () {
        $(location).attr("href", urlValidacionRechazo);
    });

});