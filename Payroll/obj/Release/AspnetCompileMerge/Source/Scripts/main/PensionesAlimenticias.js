﻿$(function () {

    var CFija = document.getElementById("inCFija");
    var Porcentaje = document.getElementById("inPorcentaje");
    var AplicaEn = document.getElementById("inAplicaEn");
    var DescFiniquito = document.getElementById("inDescFiniquito");
    var Beneficiaria = document.getElementById("inBeneficiaria");
    var Banco = document.getElementById("inBanco");
    var Sucursal = document.getElementById("inSucursal");
    var TVales = document.getElementById("inTVales");
    var NOficio = document.getElementById("inNOficio");
    var FOficio = document.getElementById("inFOficio");
    var TCalculo = document.getElementById("inTCalculo");
    var AumentoSSMG = document.getElementById("inAumentoSegunSMG");
    var AumentaSAS = document.getElementById("inAumentarSegunAs");
    var CCheques = document.getElementById("inCCheques");
    var FBaja = document.getElementById("inFBaja");

    
    //$("#inBanco").on("change", function () {
    //    switch ($("#inBanco").val) {
    //        case: '1' 
    //        default:
    //    }
    //});
    $("#modalLiveSearchEmpleado").modal("show");
    
    $("#btn-save-pension").on("click", function (evt) {
        var ch1, ch2, ch3;
        if ($("#inDescFiniquito").is(":checked")) { ch1 = 1; } else { ch1 = 0; }
        if ($("#inAumentoSegunSMG").is(":checked")) { ch2 = 1; } else { ch2 = 0; }
        if ($("#inAumentarSegunAs").is(":checked")) { ch3 = 1; } else { ch3 = 0; }
        if (Porcentaje.value == "") { Porcentaje.value = 0 }
        if (CFija.value == "") { CFija.value = "0" }
        var data = $("#frmPensionesAlimenticias").serialize();
        
        var form = document.getElementById("frmPensionesAlimenticias");
        if (form.checkValidity() === false) {
            evt.preventDefault();
            form.classList.add("was-validated");
            console.log("there are fields without data ");
            console.log(data);
        } else {
            
            console.log("all ok with the fields ");
            console.log(data);

            $.ajax({
                url: "../Incidencias/SavePension",
                type: "POST",
                data: JSON.stringify({
                    Cuota_fija: CFija.value,
                    Porcentaje: Porcentaje.value,
                    AplicaEn: AplicaEn.value,
                    Descontar_en_Finiquito: ch1,
                    No_Oficio: NOficio.value,
                    Fecha_Oficio: FOficio.value,
                    Tipo_Calculo: TCalculo.value,
                    Aumentar_segun_salario_minimo_general: ch2,
                    Aumentar_segun_aumento_de_sueldo: ch3,
                    Beneficiaria: Beneficiaria.value,
                    Banco: Banco.value,
                    Sucursal: Sucursal.value,
                    Tarjeta_vales: TVales.value,
                    Cuenta_cheques: CCheques.value,
                    Fecha_baja: FBaja.value
                }),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: () => {
                    
                    //Refresca la tabla 
                    $.ajax({
                        method: "POST",
                        url: "../Incidencias/LoadPensiones",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: (data) => {
                            console.log(data);
                            document.getElementById("tabody").innerHTML = "";
                            for (var i = 0; i < data.length; i++) {
                                
                                document.getElementById("tabody").innerHTML += "<tr><td>" + data[i]["Beneficiaria"] + "</td><td>" + data[i]["No_Oficio"] + "</td><td>" + data[i]["Fecha_Oficio"] + "</td><td>$ " + data[i]["Cuota_Fija"] + " - % " + data[i]["Porcentaje"] + "</td><td><div class='btn btn-secondary btn-sm btn-editar-pensiones' onclick='eliminarPension( " + data[i]["IdIdPension"] + " );'><i class='far fa-edit'></i></div></td></tr>";
                                console.log(data[i]["Tipo_Ausentismo_id"]);
                            }
                        }
                    });
                    //

                    Swal.fire({
                        icon: 'success',
                        title: 'Completado!',
                        text: 'Credito agregado con éxito'
                    });


                    
                }
            });

        }
    });
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

    //$("#modalLiveSearchEmpleado").on("hide", function () {
    //    $("#resultSearchEmpleados").empty();
    //    document.getElementById("#inputSearchEmpleados").innerHTML = "";
    //    console.log("yes");
    //});

});

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
            document.getElementById("resultSearchEmpleados").innerHTML = "";
            document.getElementById("inputSearchEmpleados").value = "";
            tabPensiones();
        }
    });
    //Funcion para validar solo numeros 
    $('.input-number').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });
}
function tabPensiones() {
    $.ajax({
        method: "POST",
        url: "../Incidencias/LoadPensiones",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: (data) => {
            console.log(data);
            $("#tabody").empty();
            for (var i = 0; i < data.length; i++) {
                document.getElementById("tabody").innerHTML += "<tr><td>" + data[i]["Beneficiaria"] + "</td><td>" + data[i]["No_Oficio"] + "</td><td>" + data[i]["Fecha_Oficio"] + "</td><td>$ " + data[i]["Cuota_Fija"] + " - % " + data[i]["Porcentaje"] +"</td><td><div class='btn btn-secondary btn-sm btn-editar-pensiones' onclick='eliminarPension( " + data[i]["IdIdPension"] + " );'><i class='far fa-edit'></i></div></td></tr>";
                console.log(data[i]["Tipo_Ausentismo_id"]);
            }
            

        }
    });
}