$(function () {
   
    //////////////////////////////////// Recibos Nomina ///////////////////////////////

    /// declaracion de variables globales

    const EmpresaNom = document.getElementById('EmpresaNom');
    const anoNom = document.getElementById('anoNom');
    const EmpleadosNom = document.getElementById('EmpleadosNom');
    const btnFloBuscar = document.getElementById('btnFloBuscar');
    const BtbGeneraPDF = document.getElementById('BtbGeneraPDF');
    const PeridoNom = document.getElementById('PeridoNom');
    const Emisor = document.getElementById('Emisor');
    const FechaPeridod = document.getElementById('FechaPeridod');
    var EmpresNom;
    var IdEmpresa;
    var NombreEmpleado;
    var NoEmpleado;
    var anio;
    var Tipodeperiodo;
    var datosPeriodo;

    ///Listbox de Empresas 

    FListadoEmpresa = () => {
        $.ajax({
            url: "../Nomina/LisEmpresas",
            type: "POST",
            data: JSON.stringify(),
            contentType: "application/json; charset=utf-8",
                success: (data) => {
                    for (i = 0; i < data.length; i++) {
                        document.getElementById("EmpresaNom").innerHTML += `<option value='${data[i].iIdEmpresa}'>${data[i].sNombreEmpresa}</option>`;
                    }
                }
        });
    };
    FListadoEmpresa();

    ////  ListBox Empleado

    $('#EmpresaNom').change(function () {

        IdEmpresa = EmpresaNom.value;
        const dataSend = { iIdEmpresa: IdEmpresa };
        $("#EmpleadosNom").empty();
        $('#EmpleadosNom').append('<option value="0" selected="selected">Selecciona</option>');
        $.ajax({
            url: "../Empleados/DataListEmpleado",
            type: "POST",
            data: dataSend,
            success: (data) => {
                for (i = 0; i < data.length; i++) {
                    document.getElementById("EmpleadosNom").innerHTML += `<option value='${data[i].iIdEmpleado}'>${data[i].sNombreEmpleado}</option>`;
                }
            }
        });
        //FlistEmpleados();      
    });

    ///// ListBox Perido//////

    $('#EmpleadosNom').change(function () {

        IdEmpresa = EmpresaNom.value;
        anio = anoNom.value;
        Tipodeperiodo = 0;
        const dataSend = { iIdEmpresesas: IdEmpresa, ianio: anio, iTipoPeriodo: Tipodeperiodo };
        $("#PeridoNom").empty();
        $('#PeridoNom').append('<option value="0" selected="selected">Selecciona</option>');
        console.log(dataSend);
        $.ajax({
            url: "../Nomina/ListPeriodo",
            type: "POST",
            data: dataSend,
            success: (data) => {
                console.log(data);

                for (i = 0; i < data.length; i++) {
                    document.getElementById("PeridoNom").innerHTML += `<option value='${data[i].iId}'>${data[i].sFechaFinal}</option>`;
                }
            },
        });

    });

   //// Muestra fecha de inicio y fin de peridodos

    $('#PeridoNom').change(function () {

      
        IdEmpresa = EmpresaNom.value;
        anio = anoNom.value;
        Tipodeperiodo = PeridoNom.options[PeridoNom.selectedIndex].text;
        separador = " ",
        limite = 2,
        arreglosubcadena = Tipodeperiodo.split(separador, limite);
        const dataSend = { iIdEmpresesas: IdEmpresa, ianio: anio, iTipoPeriodo: arreglosubcadena[0], iPeriodo: arreglosubcadena[1] };
        console.log(dataSend);
        $.ajax({
            url: "../Empleados/ListDatPeriodo",
            type: "POST",
            data: dataSend,
            success: (data) => {
                console.log(data);
                datosPeriodo = data[0].sFechaInicio + '-'+ data[0].sFechaFinal;
                $('#FechaPeridod').html(datosPeriodo);
               
            }
        });

    });

    /// validacion de año

    $("#iAnoDe").keyup(function () {
        this.value = (this.value + '').replace(/[^0-9]/g, '');
    });

    //// FLlena del Grid con los datos de La nomina
    FBuscar = () => {

        IdEmpresa = EmpresaNom.value;
        NombreEmpleado = EmpleadosNom.options[EmpleadosNom.selectedIndex].text;
      
        const dataSend = { IdEmpresa: IdEmpresa, sNombreComple: NombreEmpleado };
       

        $.ajax({
            url: "../Empleados/EmisorEmpresa",
            type: "POST",
            data: dataSend,
            success: (data) => {
                console.log(data);
                EmpresNom = data[0].sNombreComp + ' ' + 'RFC: ' + data[0].sRFCEmpleado;
                $('#Emisor').html(EmpresNom);                             
            }
        });

        NoEmpleado = EmpleadosNom.value;
        const dataSend2 = { iIdEmpresa: IdEmpresa, iIdEmpleado: NoEmpleado, iPeriodo: 3 };
        console.log(dataSend2);

        $.ajax({
            url: "../Empleados/ReciboNomina",
            type: "POST",
            data: dataSend2,
            success: (data) => {
                console.log(data);
                var source =
                {
                    localdata: data,
                    datatype: "array",
                    datafields:
                        [
                            { name: 'sConcepto', type: 'string' },
                            { name: 'dPercepciones', type: 'string' },
                            { name: 'dDeducciones', type: 'decimal' },
                            { name: 'dSaldos', type: 'decimal' },
                            { name: 'dInformativos', type: 'decimal' }
                        ]
                };

                var dataAdapter = new $.jqx.dataAdapter(source);
                $("#TbRecibosNomina").jqxGrid(
                    {
                        width: 718,

                        source: dataAdapter,
                        columnsresize: true,
                        columns: [
                            { text: 'Concepto', datafield: 'sConcepto', width: 300 },
                            { text: 'Percepciones', datafield: 'dPercepciones', width: 100 },
                            { text: 'Deducciones ', datafield: 'dDeducciones', width: 100 },
                            { text: 'Saldos', datafield: 'dSaldos', width: 100 },
                            { text: 'Informativos', datafield: 'dInformativos', width: 100 }
                        ]
                    });

            }
        });



      

    };

    btnFloBuscar.addEventListener('click', FBuscar);


});