/**
* Autor Juan Manuel Gómez
* Plugin de utilidades para carga de controles, mensajes, ayuda, modales
* Requiere jQuery, bootstrap
* 2016-06-07
**/


(function ($) {



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