$(document).ready(function () { 
    


    //Muestra en principio el modal de busqueda
    $("#modalLiveSearchEmpleado").modal("show");
    //Funcion que hace la busqueda de empleado por nombre o numero de nomina
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
                            $("#resultSearchEmpleados").append("<div class='list-group-item list-group-item-action btnListEmpleados font-labels  font-weight-bold' onclick='MostrarDatosEmpleado(" + data[i]["IdEmpleado"] + ")' > <i class='far fa-user-circle text-primary'></i> " + data[i]["Nombre_Empleado"] + " " + data[i]["Apellido_Paterno_Empleado"] + ' ' + data[i]["Apellido_Materno_Empleado"] + "   -   <small class='text-muted'><i class='fas fa-briefcase text-warning'></i> " + data[i]["DescripcionDepartamento"] + "</small> - <small class='text-muted'>" + data[i]["DescripcionPuesto"] + "</small></div>");
                        }
                    }
                    else {
                        $("#resultSearchEmpleados").append("<button type='button' class='list-group-item list-group-item-action btnListEmpleados font-labels'  >" + data[0]["Nombre_Empleado"] + "<br><small class='text-muted'>" + data[0]["DescripcionPuesto"] + "</small> </button>");
                    }                }
            });
        } else {
            $("#resultSearchEmpleados").empty();
        }
    });
    $("#inTiposBaja").on("change", function () {

        var tipob = document.getElementById("inTiposBaja");
        var motivob = document.getElementById("inMotivosBaja");
        var t = tipob.value;
        $.ajax({
            url: "../Nomina/LoadMotivoBajaxTe",
            type: "POST",
            data: JSON.stringify(),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: (tipo) => {
                
                document.getElementById("inMotivosBaja").innerHTML = "";
                for (var i = 0; i < tipo.length; i++) {
                    console.log(t + " y " + tipo[i]["TipoEmpleado_id"]);
                    if (t == tipo[i]["TipoEmpleado_id"]) {
                        console.log(tipob + " y " + tipo[i]["TipoEmpleado_id"]);
                        document.getElementById("inMotivosBaja").innerHTML += "<option value='" + tipo[i]["IdMotivo_Baja"] + "'>" + tipo[i]["Descripcion"] + "</option>";
                    }
                    
                }
            }
        });
    });

    

    MostrarDatosEmpleado = (idE) => {
        
        var txtIdEmpleado = { "IdEmpleado": idE };
        $.ajax({
            url: "../Empleados/SearchEmpleado",
            type: "POST",
            data: JSON.stringify(txtIdEmpleado),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: (emp) => {
                //console.log(data);
                document.getElementById("nameuser").innerHTML = emp[0].Nombre_Empleado + " " + emp[0].Apellido_Paterno_Empleado + " " + emp[0].Apellido_Materno_Empleado;

                //$.ajax({
                //    url: "../Nomina/LoadMotivoBaja",
                //    type: "POST",
                //    data: JSON.stringify(),
                //    dataType: "json",
                //    contentType: "application/json; charset=utf-8",
                //    success: (motiv) => {
                //        console.log(motiv);
                //        document.getElementById("inMotivosBaja").innerHTML = "";
                //        for (var i = 0; i < motiv.length; i++) {
                //            document.getElementById("inMotivosBaja").innerHTML += "<option value='" + motiv[i]["IdMotivo_Baja"] + "'>" + motiv[i]["Descripcion"] + "</option>";
                //        }
                //    }
                //});
                $.ajax({
                    url: "../Nomina/LoadTipoBaja",
                    type: "POST",
                    data: JSON.stringify(),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: (tipo) => {
                        console.log(tipo);
                        document.getElementById("inTiposBaja").innerHTML = "";
                        for (var i = 0; i < tipo.length; i++) {
                            document.getElementById("inTiposBaja").innerHTML += "<option value='" + tipo[i]["IdTipo_Empleado"] + "'>" + tipo[i]["Descripcion"] + "</option>";
                        }
                    }
                });
                $("#modalLiveSearchEmpleado").modal("hide");
            }
        });
    }
    
});