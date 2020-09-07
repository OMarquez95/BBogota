$(document).ready(function () {

    

    $("#consult").click(function () {

        enableLoader();

        if ($("#fatherMin").val().length === 10) {

            $("#divContenedorGrilla").empty();

            hideError();
            hideInfo();

            var data = new Object();
            data.min = $("#fatherMin").val();
            EjecutarAjax(virtualDirectory + "ValidacionReferido/Validate", "POST", data, validate, null);

        }
        else {
            showError("El numero debe contener 10 digitos.");
        }

    });


    function validate(data) {
        enableLoader();

        if (data.Error) {
            showError(data.message);
        }
        else {
            EjecutarAjax(virtualDirectory + "ValidacionReferido/getReferidos", "GET", null, paintGrid, null);
        }
    }

    function paintGrid(data) {

        $("#divContenedorGrilla").html(data);

    }

    $("#fatherMin").bind('keypress', function (e) {
        if (e.keyCode == '9' || e.keyCode == '16') {
            return;
        }
        var code;
        if (e.keyCode) code = e.keyCode;
        else if (e.which) code = e.which;
        if (e.which == 46)
            return false;
        if (code == 8 || code == 46)
            return true;
        if (code < 48 || code > 57)
            return false;
    });

    //Disable paste
    $("#fatherMin").bind("paste", function (e) {
        e.preventDefault();
    });

    $("#fatherMin").bind('mouseenter', function (e) {
        var val = $(this).val();
        if (val != '0') {
            val = val.replace(/[^0-9]+/g, "")
            $(this).val(val);
        }
    });

});



function guardar() {

    enableLoader();


    var error = false;

    var form = document.forms[0].getElementsByTagName('input');

    for (var i = 0; i < form.length; i++) {

        $('#div_' + i).removeClass('has-error');
        $('#span_' + i).text("");
    }


    for (var i = 0; i < form.length; i++) {
        if ($('input[name="[' + i + '].Min"]').val().length !== 10) {
            if ($('input[name="[' + i + '].Min"]').val().length !== 0) {
                error = true;
                $('#div_' + i).addClass('has-error');
                $('#span_' + i).text('Numero no valido.');
            }
        }
    }

    if (!error) {

        var minList2 = new Array();

        for (var i = 0; i < form.length; i++) {

            var abc = new Object();
            abc.Min = form[i].value;
            if (form[i].getAttribute("disabled") === "disabled") {
                abc.Es_Modificable = false;
            }
            else {
                abc.Es_Modificable = true;
            }
            minList2.push(abc);
        }


        var dataform = new Object();
        dataform.lista = minList2;

        EjecutarAjax(virtualDirectory + "ValidacionReferido/SaveReferidos", "POST", dataform, finalAnswer, null);

    }

    
}

function finalAnswer(data) {

    hideError();
    hideInfo();

    if (data.Error) {
        showError(data.message);
    }
    else {
        $("#divContenedorGrilla").empty();
        $("#fatherMin").val("");
        showInfo(data.message);
    }
}

function validarNum(event, element, _float) {

    event = event || window.event;
    var charCode = event.which || event.keyCode;
    if (charCode == 8 || charCode == 13 || (_float ? (element.value.indexOf('.') == -1 ? charCode == 46 : false) : false))
        return true;
    else if ((charCode < 48) || (charCode > 57))
        return false;
    return true;
}

