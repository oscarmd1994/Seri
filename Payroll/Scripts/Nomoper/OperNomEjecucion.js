$(function () {

    /// Tab Ejecucion 

    // Declaracion de variables 

    //const EjeNombreDef = document.getElementById('EjeNombreDef');
    const EjeCerrada = document.getElementById('EjeCerrada');
    const TxtBInicioClculo = document.getElementById('TxtBInicioClculo');
    const TxtBFinClculo = document.getElementById('TxtBFinClculo');
    const btnlimpDat = document.getElementById('btnlimpDat');
    const btnFloGuardar = document.getElementById('btnFloGuardar');
    const navEjecuciontab = document.getElementById('nav-Ejecucion-tab');
    const navVisCalculotab = document.getElementById('nav-VisCalculo-tab');
    const btnFloEjecutar = document.getElementById('btnFloEjecutar');
    var DatoEjeCerrada;
    var IdDropList;
    var RowsGrid;
    var exitRow;
    var opTab = 1;


    // funcion llena lisbox de Ejecucin Nombre de Definicion

    FlistNombreDef = () => {

        $.ajax({
            url: "../Nomina/ListadoNomDefinicion",
            type: "POST",
            data: JSON.stringify(),
            contentType: "application/json; charset=utf-8",
            success: (data) => {
                var num = 0;

                for (i = 0; i < data.length; i++) {
                    num = num + 1;
                    document.getElementById("EjeNombreDef").innerHTML += `<option value='${num}'>${data[i].sNombreDefinicion}</option>`;
                }
            }
        });

    }

    FlistNombreDef();

    // Funcion muestra Grid Con los datos de TPDefinicion en del droplist definicion 

    FLlenaGrid = () => {

        for (var i = 0; i <= RowsGrid; i++) {

            $("#TpDefinicion").jqxGrid('deleterow', i);
        }

        var opDeNombre = "Selecciona"; /*EjeNombreDef.options[EjeNombreDef.selectedIndex].text*/;
        var opDeCancelados = 2;

        const dataSend = { sNombreDefinicion: opDeNombre, iCancelado: opDeCancelados };

        $.ajax({
            url: "../Nomina/TpDefinicionNominaQry",
            type: "POST",
            data: dataSend,
            success: (data) => {
                if (data.length > 0) {
                    RowsGrid = data.length;
                }
                var source =
                {
                    localdata: data,
                    datatype: "array",
                    datafields:
                        [
                            { name: 'iIdDefinicionhd', type: 'int' },
                            { name: 'sNombreDefinicion', type: 'string' },
                            { name: 'sDescripcion', type: 'string' },
                            { name: 'iAno', type: 'int' },
                            { name: 'iCancelado', type: 'string' },
                        ],
                    datatype: "array",
                    updaterow: function (rowid, rowdata) {
                        // synchronize with the server - send update command   
                    }
                };

                var dataAdapter = new $.jqx.dataAdapter(source);

                $("#TpDefinicion").jqxGrid({
                    width: 550,
                    source: dataAdapter,
                    columnsresize: true,

                    columns: [
                        { text: 'No. Registro', datafield: 'iIdDefinicionhd', width: 50 },
                        { text: 'Nombre de Definición', datafield: 'sNombreDefinicion', width: 100 },
                        { text: 'Descripción ', datafield: 'sDescripcion', whidth: 300 },
                        { text: 'Año', datafield: 'iAno', whidt: 50 },
                        { text: 'Cancelado', datafield: 'iCancelado', whidt: 50 },
                    ]
                });
            },
        });
    }
    FLlenaGrid();

    $('#EjeNombreDef').change(function () {
        FLlenaGrid();
    });

    // Funcion Limpia Campos
    FLimpiaCampos = () => {

        if (opTab == 1) {

            EjeCerrada.value = "0";
            TxtBInicioClculo.value = '';
            TxtBFinClculo.value = '';
            //FLlenaGrid();
            IdDropList = 0;
            $("#2").empty();
        }
        

    };

    btnlimpDat.addEventListener('click', FLimpiaCampos);

    // define tamaño del droplist

    $("#jqxdropdownbutton").jqxDropDownButton({
        width: 600, height: 30
    });

    // seleccion de linea de grip y la guarda en el droplist
    $("#TpDefinicion").on('rowselect', function (event) {
        var args = event.args;
        var row = $("#TpDefinicion").jqxGrid('getrowdata', args.rowindex);
        IdDropList = row.iIdDefinicionhd;
        var dropDownContent = '<div id="2" style="position: relative; margin-left: 3px; margin-top: 6px;">' + row['iIdDefinicionhd'] + ' ' + row['sNombreDefinicion'] + '</div>';
        $("#jqxdropdownbutton").jqxDropDownButton('setContent', dropDownContent);
    });
    $("#TpDefinicion").jqxGrid('selectrow', 0);

    // Funcion de guardar 
    Fguardar = () => {

        if (opTab == 1) { 

        DatoEjeCerrada = EjeCerrada.value;
        console.log(IdDropList);
        console.log(DatoEjeCerrada);
        if (IdDropList > 0) {
            const dataSend = { iIdDefinicionHd: IdDropList };
            $.ajax({
                url: "../Nomina/CompruRegistroExit",
                type: "POST",
                data: dataSend,
                success: (data) => {
                    console.log('imprime');
                    console.log(data);
                    console.log('imprime variable')
                    console.log(data[0].iIdCalculosHd)
                    if (data[0].iIdCalculosHd == 1) {
                        exitRow = "1";
                    }

                    if (data[0].iIdCalculosHd == 0) {
                        exitRow = "0";

                    }

                    console.log('imprime resutado')
                    console.log(exitRow);
                    if (exitRow == "1") {

                        console.log('update')


                        //mensaje


                        Swal.fire({
                            title: 'Seguro que deseas actualizar la ejecución?',
                            text: "Si es asi da clic en aceptar!",
                            icon: 'warning',
                            showCancelButton: true,
                            confirmButtonColor: '#3085d6',
                            cancelButtonColor: '#d33',
                            confirmButtonText: 'Aceptar!'
                        }).then((result) => {
                            if (result.value) {
                                Swal.fire(
                                    'Ejecución!',
                                    'actualizada.',
                                    'success'
                                )

                                const dataSend3 = { iIdDefinicionHd: IdDropList, iNominaCerrada: DatoEjeCerrada };
                                console.log(dataSend3);

                                $.ajax({
                                    url: "../Nomina/UpdateCalculoshd",
                                    type: "POST",
                                    data: dataSend3,

                                    success: (data) => {
                                        console.log('termino');
                                        if (data.sMensaje == "success") {
                                            console.log(data);
                                
                                        }
                                        else {
                                            fshowtypealert('Error', 'Contacte a sistemas', 'error');

                                        }
                                    },

                                    error: function (jqXHR, exception) {
                                        fcaptureaerrorsajax(jqXHR, exception);
                                    }
                                });

                            }
                        })


                    }

                    if (exitRow == "0") {



                        const dataSend2 = { iIdDefinicionHd: IdDropList, iNominaCerrada: DatoEjeCerrada };
                        console.log(dataSend2);

                        $.ajax({
                            url: "../Nomina/InsertDatTpCalculos",
                            type: "POST",
                            data: dataSend2,

                            success: (data) => {
                                console.log('termino');
                                if (data.sMensaje == "success") {
                                    console.log(data);
                                    fshowtypealert('Registro correcto!', 'Calculo guardado', 'success');

                                }
                                else {
                                    fshowtypealert('Error', 'Contacte a sistemas', 'error');

                                }
                            },

                            error: function (jqXHR, exception) {
                                fcaptureaerrorsajax(jqXHR, exception);
                            }
                        });




                    }

                },


            });

        }
        else {
            fshowtypealert('Selecciona un nombre definición !', '', 'warning');

            }

        }

    }

    btnFloGuardar.addEventListener('click', Fguardar)


    
    /// tab Calculo


    //var exampleTheme = theme;
    //var exampleTheme = theme;
 
    FllenagripTpDefinicionLN = () => {

        IdDropList
      
        const dataSend = {iIdEmpresa:IdDropList};
        console.log(dataSend);

        $.ajax({
            url: "../Nomina/ListTpCalculoln",
            type: "POST",
            data: dataSend,
            success: (data) => {
               
                var source =
                {
                    localdata: data,
                    datatype: "array",
                    datafields:
                        [
                            { name: 'iIdCalculosLn', type: 'int' },
                            { name: 'iIdCalculosHd', type: 'int' },
                            { name: 'iIdEmpresa', type: 'int' },
                            { name: 'iIdEmpleado', type: 'int' },
                            { name: 'iAnio', type: 'int' },
                            { name: 'iIdTipoPeriodo', type: 'int' },
                            { name: 'iPeriodo', type: 'int' },
                            { name: 'iConsecutivo', type: 'int' },
                            { name: 'iIdRenglon', type: 'int' },
                            { name: 'iImporte', type: 'int' },
                            { name: 'iSaldo', type: 'int' },
                            { name: 'iGravado', type: 'int' },
                            { name: 'iExcento', type: 'int' },
                            { name: 'sFecha', type: 'string' },
                           

                        ],
                    datatype: "array",
                    updaterow: function (rowid, rowdata) {
                        // synchronize with the server - send update command   
                    }
                };

                var dataAdapter = new $.jqx.dataAdapter(source);
                var buildFilterPanel = function (filterPanel, datafield) {
                    var textInput = $("<input style='margin:5px;'/>");
                    var applyinput = $("<div class='filter' style='height: 25px; margin-left: 20px; margin-top: 7px;'></div>");
                    var filterbutton = $('<span tabindex="0" style="padding: 4px 12px; margin-left: 2px;">Filtrar</span>');
                    applyinput.append(filterbutton);
                    var filterclearbutton = $('<span tabindex="0" style="padding: 4px 12px; margin-left: 5px;">Limpiar</span>');
                    applyinput.append(filterclearbutton);
                    filterPanel.append(textInput);
                    filterPanel.append(applyinput);
                    filterbutton.jqxButton({ theme: exampleTheme, height: 20 });
                    filterclearbutton.jqxButton({ theme: exampleTheme, height: 20 });
                    var dataSource =
                    {
                        localdata: adapter.records,
                        datatype: "array",
                        async: false
                    }
                    var dataadapter = new $.jqx.dataAdapter(dataSource,
                        {
                            autoBind: false,
                            autoSort: true,
                            autoSortField: datafield,
                            async: false,
                            uniqueDataFields: [datafield]
                        });
                    var column = $("#TbCalculos").jqxGrid('getcolumn', datafield);
                    textInput.jqxInput({ theme: exampleTheme, placeHolder: "Enter " + column.text, popupZIndex: 9999999, displayMember: datafield, source: dataadapter, height: 23, width: 175 });
                    textInput.keyup(function (event) {
                        if (event.keyCode === 13) {
                            filterbutton.trigger('click');
                        }
                    });
                    filterbutton.click(function () {
                        var filtergroup = new $.jqx.filter();
                        var filter_or_operator = 1;
                        var filtervalue = textInput.val();
                        var filtercondition = 'contains';
                        var filter1 = filtergroup.createfilter('stringfilter', filtervalue, filtercondition);
                        filtergroup.addfilter(filter_or_operator, filter1);
                        // add the filters.
                        $("#TbCalculos").jqxGrid('addfilter', datafield, filtergroup);
                        // apply the filters.
                        $("#TbCalculos").jqxGrid('applyfilters');
                        $("#TbCalculos").jqxGrid('closemenu');
                    });
                    filterbutton.keydown(function (event) {
                        if (event.keyCode === 13) {
                            filterbutton.trigger('click');
                        }
                    });
                    filterclearbutton.click(function () {
                        $("#TbCalculos").jqxGrid('removefilter', datafield);
                        // apply the filters.
                        $("#TbCalculos").jqxGrid('applyfilters');
                        $("#TbCalculos").jqxGrid('closemenu');
                    });
                    filterclearbutton.keydown(function (event) {
                        if (event.keyCode === 13) {
                            filterclearbutton.trigger('click');
                        }
                        textInput.val("");
                    });
                }

                $("#TbCalculos").jqxGrid({
                    width: 1050,
                    source: dataAdapter,
                    columnsresize: true,
                    source: dataAdapter,
                        columnsresize: true,
                        filterable: true,
                        sortable: true,
                        //autoheight: true,
                        //autowidth:true,
                        //columns: columns,
                        sortable: true,
                        filterable: true,
                        altrows: true,
                        sortable: true,
                        ready: function () {
                        },

                    columns: [
                        { text: 'IdCalculoLn', datafield: 'iIdCalculosLn', width: 100 },
                        { text: 'IdCalculo', datafield: 'iIdCalculosHd', width: 100 },
                        { text: 'IdEmpresa ', datafield: 'iIdEmpresa', whidth: 100 },
                        { text: 'IdEmpleado', datafield: 'iIdEmpleado', whidt: 100 },
                        { text: 'Año', datafield: 'iAnio', width: 80 },
                        { text: 'Id Periodo', datafield: 'iIdTipoPeriodo', width: 100 },
                        { text: 'Periodo', datafield: 'iPeriodo', width:80 },
                        { text: 'Consecutivo', datafield: 'iConsecutivo', width: 100 },
                        { text: 'Id Renglon', datafield: 'iIdRenglon', width: 100 },
                        { text: 'Importe', datafield: 'iImporte', width: 100 },
                        { text: 'Saldo', datafield: 'iSaldo', width: 100 },
                        { text: 'Gravado', datafield: 'iGravado', width: 100 },
                        { text: 'Excento', datafield: 'iExcento', width: 100 },
                        { text: 'Fecha', datafield: 'sFecha', width: 100 },
                    ]
                });
            },
        });



        //$.ajax({
        //    url: "../Nomina/ListTpCalculoln",
        //    type: "POST",
        //    data: dataSend,
        //    contentType: "application/json; charset=utf-8",
        //    success: (data) => {
        //        console.log(data);

        //        var source =
        //        {

        //            localdata: data,
        //            datatype: "array",
        //            datafields:
        //                [
        //                    { name: 'iIdDefinicionln', type: 'string' },
        //                    { name: 'IdEmpresa', type: 'string' },
        //                    { name: 'iRenglon', type: 'string' },
        //                    { name: 'iElementonomina', type: 'string' },
        //                    { name: 'iTipodeperiodo', type: 'string' },
        //                    { name: 'iIdperiodo', type: 'string' },
        //                    { name: 'iIdAcumulado', type: 'string' },
        //                    { name: 'iEsespejo', type: 'string' }
        //                ]
        //        };
        //        var dataAdapter = new $.jqx.dataAdapter(source);

        //        var buildFilterPanel = function (filterPanel, datafield) {
        //            var textInput = $("<input style='margin:5px;'/>");
        //            var applyinput = $("<div class='filter' style='height: 25px; margin-left: 20px; margin-top: 7px;'></div>");
        //            var filterbutton = $('<span tabindex="0" style="padding: 4px 12px; margin-left: 2px;">Filtrar</span>');
        //            applyinput.append(filterbutton);
        //            var filterclearbutton = $('<span tabindex="0" style="padding: 4px 12px; margin-left: 5px;">Limpiar</span>');
        //            applyinput.append(filterclearbutton);
        //            filterPanel.append(textInput);
        //            filterPanel.append(applyinput);
        //            filterbutton.jqxButton({ theme: exampleTheme, height: 20 });
        //            filterclearbutton.jqxButton({ theme: exampleTheme, height: 20 });
        //            var dataSource =
        //            {
        //                localdata: adapter.records,
        //                datatype: "array",
        //                async: false
        //            }
        //            var dataadapter = new $.jqx.dataAdapter(dataSource,
        //                {
        //                    autoBind: false,
        //                    autoSort: true,
        //                    autoSortField: datafield,
        //                    async: false,
        //                    uniqueDataFields: [datafield]
        //                });
        //            var column = $("#TbCalculos").jqxGrid('getcolumn', datafield);
        //            textInput.jqxInput({ theme: exampleTheme, placeHolder: "Enter " + column.text, popupZIndex: 9999999, displayMember: datafield, source: dataadapter, height: 23, width: 175 });
        //            textInput.keyup(function (event) {
        //                if (event.keyCode === 13) {
        //                    filterbutton.trigger('click');
        //                }
        //            });
        //            filterbutton.click(function () {
        //                var filtergroup = new $.jqx.filter();
        //                var filter_or_operator = 1;
        //                var filtervalue = textInput.val();
        //                var filtercondition = 'contains';
        //                var filter1 = filtergroup.createfilter('stringfilter', filtervalue, filtercondition);
        //                filtergroup.addfilter(filter_or_operator, filter1);
        //                // add the filters.
        //                $("#TbCalculos").jqxGrid('addfilter', datafield, filtergroup);
        //                // apply the filters.
        //                $("#TbCalculos").jqxGrid('applyfilters');
        //                $("#TbCalculos").jqxGrid('closemenu');
        //            });
        //            filterbutton.keydown(function (event) {
        //                if (event.keyCode === 13) {
        //                    filterbutton.trigger('click');
        //                }
        //            });
        //            filterclearbutton.click(function () {
        //                $("#TbCalculos").jqxGrid('removefilter', datafield);
        //                // apply the filters.
        //                $("#TbCalculos").jqxGrid('applyfilters');
        //                $("#TbCalculos").jqxGrid('closemenu');
        //            });
        //            filterclearbutton.keydown(function (event) {
        //                if (event.keyCode === 13) {
        //                    filterclearbutton.trigger('click');
        //                }
        //                textInput.val("");
        //            });
        //        }

        //        $("#TbCalculos").jqxGrid(
        //            {
        //                width: 1050,
                       
        //                source: dataAdapter,
        //                columnsresize: true,
        //                filterable: true,
        //                sortable: true,
        //                //autoheight: true,
        //                //autowidth:true,
        //                //columns: columns,
        //                sortable: true,
        //                filterable: true,
        //                altrows: true,
        //                sortable: true,
        //                ready: function () {
        //                },

        //                columns: [
        //                    { text: 'No.Linea', datafield: 'iIdDefinicionln', width: 70 },
        //                    { text: 'Empresa', datafield: 'IdEmpresa', width: 120 },
        //                    { text: 'Renglon ', datafield: 'iRenglon', width: 350 },
        //                    { text: 'Elemento de Nomina', datafield: 'iElementonomina', width: 150 },
        //                    { text: 'Tipo de periodo', datafield: 'iTipodeperiodo', width: 120 },
        //                    { text: 'Periodo', datafield: 'iIdperiodo', width: 60 },
        //                    { text: 'Acumulado', datafield: 'iIdAcumulado', width: 250 },
        //                    { text: 'Esespejo', datafield: 'iEsespejo', width: 80 }
        //                ]
        //            });
        //    }
        //});
    }
  

    Ftabopcion1 = () => {

        opTab = 1;
       

    }
    Ftabopcion2 = () => {

        opTab = 2;
        
    }
 
    navEjecuciontab.addEventListener('click', Ftabopcion1);
    navVisCalculotab.addEventListener('click', Ftabopcion2);

    // Procesos de Ejecucion 

    Fejecucion = () => {

        if (opTab == 1) {
            $("#nav-Ejecucion-tab").removeClass("active");
            $("#nav-VisCalculo-tab").removeClass("active");
            FllenagripTpDefinicionLN();

            $.ajax({
                url: "../Nomina/ProcesosPots",
                type: "POST",
                data: JSON.stringify(),
                contentType: "application/json; charset=utf-8",
                success: (data) => {
                }
            });

         
        }

    }

    btnFloEjecutar.addEventListener('click', Fejecucion);

    /// VALIDACIONES 
    //$("#TxtBInicioClculo").keyup(function () {
    //    this.value = (this.value + '').replace(/[^0-9]/g, '');
    //});
    //$("#TxtBFinClculo").keyup(function () {
    //    this.value = (this.value + '').replace(/[^0-9]/g, '');
    //});
    /* FUNCION QUE MUESTRA ALERTAS */
    fshowtypealert = (title, text, icon) => {
        Swal.fire({
            title: title, text: text, icon: icon,
            showClass: { popup: 'animated fadeInDown faster' },
            hideClass: { popup: 'animated fadeOutUp faster' },
            confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
        }).then((acepta) => {
            //  Nombrede.value       = '';
            // Descripcionde.value  = '';
            //iAnode.value         = '';
            //cande.value          = '';
            //$("html, body").animate({
            //    scrollTop: $(`#${element.id}`).offset().top - 50
            //}, 1000);
            //if (clear == 1) {
            //    setTimeout(() => {
            //        element.focus();
            //        setTimeout(() => { element.value = ""; }, 300);
            //    }, 1200);
            //} else {
            //    setTimeout(() => {
            //        element.focus();
            //    }, 1200);
            //}
        });
    }





   

});