﻿$(document).ready(function () {
    //DEFINE TOOLTIP A ELEMENTOS
    $('body').tooltip({
        selector: '[data-toggle="tooltip"]'
    });
    //OCULTA AVISO
    $("#aviso").hide();
});

$(document).on("click", "#btnConsulta", function () {
    var noEempl = $("#noEmp").val();
    if (validaEntrada(noEempl)){
        //LLAMA AJAX
        getEmpleado(noEempl);
    }
    
});


$(document).on("change", "#noEmp", function () {
    $("#aviso").html("");
    $("#aviso").hide("slow");
});


function validaEntrada(numero) {
    if (numero.length > 8 || numero.length < 8) {
        $("#aviso").html("<i class='glyphicon glyphicon-info-sign'></i> El número de empleado debe contener ocho digitos.");
        $("#aviso").show("slow");
        return;
    }
    if (numero.length == 0) {
        $("#aviso").html("<i class='glyphicon glyphicon-info-sign'></i> Ingrese un numero de empleado.");
        $("#aviso").show("slow");
        return;
    }

    else {
        //APRUEBA VALIDACION
        return true;
    }
}

function getEmpleado(numero) {
    $.ajax({
        url: rootUrl + 'RL_EMPLEADO/getDatosEmpleado',
        dataType:'json',
        type:'POST',
        data:{NO_EMP: numero},
        success: function (response) {
            if (response.length != 0) {
                $.each(response, function (index, emp) {
                    $("#idEmp").val(this.ID_EMPLEADO);
                    $("#nombreE").html(this.NOMBRE_EMPLEADO);
                    $("#puestoE").html(this.DESC_PUESTO);
                    $("#corporativoE").html(this.DESC_CORPORATIVO);
                });
            }
            else {
                $("#aviso").html("<i class='glyphicon glyphicon-info-sign'></i> El número de empleado ingresado no existe.");
                $("#aviso").show("slow");
                return;
            }
            
        }
    });
}