﻿$(function () {
    var ren_incidencia = document.getElementById("inRenglon");
    var concepto_incidencia = document.getElementById("inConcepto_incidencia");
    var cantidad_incidencia = document.getElementById("inCantidad");
    var plazos_incidencia = document.getElementById("inPlazos");
    var leyenda_incidencia = document.getElementById("inLeyenda");
    var referencia_incidencia = document.getElementById("inReferencia");
    var fecha_incidencia = document.getElementById("inFechaA");

    $("#modalLiveSearchEmpleado").modal("show");

    //Busqueda de empleado
    $("#inputSearchEmpleados").on("keyup", function () {
        $("#inputSearchEmpleados").empty();
        var txt = $("#inputSearchEmpleados").val();
        if ($("#inputSearchEmpleados").val() != "") {
            var txtSearch = { "txtSearch": txt };
            $.ajax({
                url: "../Empleados/SearchEmpleados",
                type: "POST",
                cache: false,
                data: JSON.stringify(txtSearch),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: (data) => {

                    console.log(data[0]["iFlag"]);
                    $("#resultSearchEmpleados").empty();
                    if (data[0]["iFlag"] == 0) {
                        for (var i = 0; i < data.length; i++) {
                            $("#resultSearchEmpleados").append("<div class='list-group-item list-group-item-action btnListEmpleados font-labels  font-weight-bold' onclick='MostrarDatosEmpleado(" + data[i]["IdEmpleado"] + ")'> <i class='far fa-user-circle text-primary'></i> " + data[i]["Nombre_Empleado"] + " " + data[i]["Apellido_Paterno_Empleado"] + ' ' + data[i]["Apellido_Materno_Empleado"] + "   -   <small class='text-muted'><i class='fas fa-briefcase text-warning'></i> " + data[i]["DescripcionDepartamento"] + "</small> - <small class='text-muted'>" + data[i]["DescripcionPuesto"] + "</small></div>");
                        }
                    }
                    else {
                        $("#resultSearchEmpleados").append("<button type='button' class='list-group-item list-group-item-action btnListEmpleados font-labels'  >" + data[0]["Nombre_Empleado"] + "<br><small class='text-muted'>" + data[0]["DescripcionPuesto"] + "</small> </button>");
                    }
                }
            });
        } else {
            $("#resultSearchEmpleados").empty();
        }
    });
    //VALIDACION DE CAMPOS NUMERICOS
    $('.input-number').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });
    //CARGA CONCEPTO 
    $.ajax({
        url: "../Incidencias/LoadTipoIncidencia",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: (data) => {
            document.getElementById("inConcepto_incidencia").innerHTML = "<option class='' value=''> Selecciona </option>"
            for (var i = 0; i < data.length; i++) {
                document.getElementById("inConcepto_incidencia").innerHTML += "<option class='' value='" + data[i]["Ren_incid_id"] + "'> " + data[i]["Descripcion"] + "</option>";
                console.log(data[i]["Descripcion"]);
            }
        }
    });
    //CAMBIOS EN EL SELECT Y EL RENGLON
    $("#inConcepto_incidencia").on("change", function() {
        ren_incidencia.value = concepto_incidencia.value;
    });
    //GUARDAR INCIDENCIA
    $("#btnSaveIncidencias").on("click", function () {
        var form = document.getElementById("frmIncidencias");
        if (form.checkValidity() == false) {
            setTimeout( () => {
                form.classList.add("was-validated");
                console.log("no valido");
            }, 5000);
        } else {
            
            console.log("Boton guardar");
            var Vform = $("#frmIncidencias").serialize();
            console.log(Vform);
            $.ajax({
                url: "../Incidencias/SaveRegistroIncidencia",
                type: "POST",
                data: JSON.stringify({
                    inRenglon: concepto_incidencia.value,
                    inCantidad: cantidad_incidencia.value,
                    inPlazos: plazos_incidencia.value,
                    inLeyenda: leyenda_incidencia.value,
                    inReferencia: referencia_incidencia.value,
                    inFechaA: fecha_incidencia.value
                    }),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: (data) => {
                    console.log(data);
                    if (data[0] == '0') {
                        Swal.fire({
                            icon: 'danger',
                            title: 'Error!',
                            text: data[1],
                            timer: 1000
                        });
                    } else if (data[0] == '1') {
                        concepto_incidencia.value = '';
                        cantidad_incidencia.value = '';
                        plazos_incidencia.value = '';
                        leyenda_incidencia.value = '';
                        referencia_incidencia.value = '';
                        fecha_incidencia.value = '';
                        Swal.fire({
                            icon: 'success',
                            title: 'Completado!',
                            text: data[1],
                            timer: 1000
                        });
                    }
                }
            });
        }
    });
});


    

 //Funciones
function MostrarDatosEmpleado(idE) {
    var txtIdEmpleado = { "IdEmpleado": idE };
    $.ajax({
        url: "../Empleados/SearchEmpleado",
        type: "POST",
        data: JSON.stringify(txtIdEmpleado),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: (data) => {
            document.getElementById("EmpDes").innerHTML = "<i class='far fa-user-circle text-primary'></i> " + data[0]["Nombre_Empleado"] + " " + data[0]["Apellido_Paterno_Empleado"] + ' ' + data[0]["Apellido_Materno_Empleado"] + "   -   <small class='text-muted'> " + data[0]["DescripcionDepartamento"] + "</small> - <small class='text-muted'>" + data[0]["DescripcionPuesto"] + "</small>";
            $("#modalLiveSearchEmpleado").modal("hide");   
        } 
    });
}
function createTab() {
    $.ajax({
        method: "POST",
        url: "../Incidencias/LoadIncidenciasEmpleado",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: (data) => {
            document.getElementById("tabIncidenciasBody").innerHTML = "";
            for (var i = 0; i < data.length; i++) {
                document.getElementById("tabIncidenciasBody").innerHTML += "<tr><td>" + data[i]["NoCredito"] + "</td><td>" + data[i]["TipoDescuento"] + "</td><td>" + data[i]["Descuento"] + "</td><td>" + data[i]["FechaBaja"] + "</td><td><div class='btn btn-danger btn-sm'><i class='far fa-check-square'></i></div></td></tr>";
            }
        }
    });

}


