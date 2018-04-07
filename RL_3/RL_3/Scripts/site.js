$(document).ready(function () {
    //DEFINE TOOLTIP A ELEMENTOS
    $('body').tooltip({
        selector: '[data-toggle="tooltip"]'
    });
    //OCULTA AVISO
    $("#aviso").hide();
    $(".dispDatos").hide();
    //MOMENT EN ESPAÑOL
    moment.locale('es');    
});


//ACCIONES AL DAR CLIC EN BUSCAR
$(document).on("click", "#btnConsulta", function () {
    $("#aviso").html("");
    $("#aviso").hide("slow");
    $(".dispDatos").hide();
    var noEempl = $("#noEmp").val();
    if (validaEntrada(noEempl)){
        //LLAMA AJAX
        getEmpleado(noEempl);       
    }    
});

//OCULTA AVISO AL CAMBIAR NUMERO DE EMPLEADO
$(document).on("change", "#noEmp", function () {
    $("#aviso").html("");
    $("#aviso").hide("slow");
});

//VALIDA QUE LOS DATOS INGRESADOS CUMPLAS LOS CRITERIOS
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
//OBTIENE LOS DATOS DEL EMPLEADO
function getEmpleado(numero) {
    $.ajax({
        url: rootUrl + 'RL_EMPLEADO/getDatosEmpleado',
        dataType:'json',
        type:'POST',
        data:{NO_EMP: numero},
        success: function (response) {
            $(".dispDatos").show();
            if (response.length != 0) {
                $.each(response, function (index, emp) {
                    $("#idEmp").val(this.ID_EMPLEADO);
                    $("#nombreE").html(this.NOMBRE_EMPLEADO);
                    $("#puestoE").html(this.DESC_PUESTO);
                    $("#corporativoE").html(this.DESC_CORPORATIVO);
                });                
                //CARGA HORARIOS
                getChecadaEmpleado($("#idEmp").val());
            }
            else {
                $("#aviso").html("<i class='glyphicon glyphicon-info-sign'></i> El número de empleado ingresado no existe.");
                $("#aviso").show("slow");
                return;
            }           
        }
    });
}

//OBTIENE LOS DATOS DE INGRESO Y SALIDA DEL EMPLEADO Y LLENA TABLAS
function getChecadaEmpleado(idEmp) {
    $("#datosE").html("");
    $("#datosS").html("");
    $.ajax({
        url: rootUrl + 'RL_EMPLEADO/getChecadaEmpleado',
        dataType:'json',
        type:'POST',
        data: { ID_EMP: idEmp },
        success: function (response) {         
            if (response.length != 0) {
                $.each(response, function (index, chec) {
                    if (index <= 4) {
                        //SE AGREGAN ATRIBUTOS DINAMICOS ID Y CLASE AL SPAN DE HORA DE ENTRADA
                        $("#datosE").append("<tr> <td> " + moment(this.CHECADA).format('L') + "</td><td> <span class='hE' id='r_" + index + "'>" + moment(this.CHECADA).format('h:mm:ss a') + "</td><td>" + this.DESC_ACCESO + "</td> </tr>");
                    }

                    if (index > 4) {
                        //SE AGREGAN ATRIBUTOS DINAMICOS ID Y CLASE AL SPAN DE HORA DE SALIDA
                        $("#datosS").append("<tr> <td> " + moment(this.CHECADA).format('L') + "</td><td> <span class='hS' id='r_" + index + "'>" + moment(this.CHECADA).format('h:mm:ss a') + "</td><td>" + this.DESC_ACCESO + "</td> </tr>");
                    }
                });
                //INCOVCA FUNCION PARA OBTENER TOTAL DE HORAS TRABAJADAS
                setTotal();
            }
            else {
                $("#aviso").html("<i class='glyphicon glyphicon-info-sign'></i> Hubo un problema al cargar el historial de checadas.");
                $("#aviso").show("slow");
                return;
            }
        }
    });
}

//OBTIENE LAS HORAS TRABAJADAS 
function setTotal() {
    $("#datosT").html("");
    var entrada;
    var salida;
    var total;
    var horas;
    var minutos;
    //SO OBTIENE ARREGLO DE IDS DE SPANS ENTRADA
    var idE = $('.hE').map(function (index) {        
        return this.id;
    });
    //SO OBTIENE ARREGLO DE IDS DE SPANS SALIDA
    var idS = $('.hS').map(function (index) {
        return this.id;
    });
    // SE OBTIENEN HORAS DE LOS ELEMENTOS DE LOS ARREGLOS
    for (var lg = 0; lg < idE.length; lg++)
    {
        entrada = moment($("#" + idE[lg]).text(), "HH:mm:ss a");
        salida = moment($("#" + idS[lg]).text(), "HH:mm:ss a");
        total = moment.duration(salida.diff(entrada));
        horas = parseInt(total.asHours());
        minutos = parseInt(total.asMinutes()) - horas * 60;       

        $("#datosT").append("<tr> <td> "+ horas + " hrs. " + minutos + " min." + " </td></tr>");
    }
}