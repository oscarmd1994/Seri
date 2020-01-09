$(function () {

    /*
     * Declaracion de variables de los botones que cargan datos consecutivos
     */
    const btnSearchNumNomina        = document.getElementById('btn-search-num-nomina');
    const btnSearchNumPosicion = document.getElementById('btn-search-num-posicion');

    const btnModalSearchPuesto      = document.getElementById('btn-modal-search-puesto');
    const btnCloseRegisterPbtn = document.getElementById('btn-close-registerpuesto-btn');
    const icoCloseRegisterPbtn = document.getElementById('ico-close-registerpuesto-btn');

    localStorage.removeItem('modalbtnpuesto');
    btnModalSearchPuesto.addEventListener('click', () => { localStorage.setItem('modalbtnpuesto', 1); });
    btnCloseRegisterPbtn.addEventListener('click', () => { localStorage.removeItem('modalbtnpuesto'); });
    icoCloseRegisterPbtn.addEventListener('click', () => { localStorage.removeItem('modalbtnpuesto'); });

    const btnModalSearchDepartament = document.getElementById('btn-modal-search-departament');
    const btnCloseRegisterDbtn = document.getElementById('btn-close-registerdepart-btn');
    const icoCloseRegisterDbtn = document.getElementById('ico-close-registerdepart-btn');

    localStorage.removeItem('modalbtndepartament');
    btnModalSearchDepartament.addEventListener('click', () => { localStorage.setItem('modalbtndepartament', 1); });
    btnCloseRegisterDbtn.addEventListener('click', () => { localStorage.removeItem('modalbtndepartament'); });
    icoCloseRegisterDbtn.addEventListener('click', () => { localStorage.removeItem('modalbtndepartament'); });


    /*
     * Ejecución de función que carga el numero de nómina 
     */
    floadnumnomina = (idparam) => {
        try {
            $.ajax({
                url: "../CatalogsTables/LoadNumNomina",
                type: "POST",
                data: { keyemp: idparam },
                success: (data) => {
                    if (data.sMensaje == "success") {
                        document.getElementById('numnom').value = data.iNominaSiguiente;
                    } else {
                        document.getElementById('numnom').value = 0;
                    }
                }, error: (jqxHR, exception) => {
                    fcaptureaerrorsajax(jqxHR, exception);
                }
            });
        } catch (error) {
            if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }

    btnSearchNumNomina.addEventListener('click', () => {
        floadnumnomina(5);
    });

    /*
     * Ejecución de funcion que carga el numero de posicion
     */
    floadnumposicion = () => {
        try {
            $.ajax({
                url: "../CatalogsTables/LoadNumPosicion",
                type: "POST",
                data: {},
                success: (data) => {
                    if (data.sMensaje == "success") {
                        document.getElementById('numpla').value = data.iPosicionSiguiente;
                    } else {
                        document.getElementById('numpla').value = 0;
                    }
                }, error: (jqxHR, exception) => {
                    fcaptureaerrorsajax(jqxHR, exception);
                }
            });
        } catch (error) {
            if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }

    freloadnumpos = () => {
        if (document.getElementById('numpla').value != "") {
            floadnumposicion();
        }
    }

    //let timernumpos = setInterval(freloadnumpos, 10000);

    btnSearchNumPosicion.addEventListener('click', () => {
        floadnumposicion();
    });

    /*
     * Declaracion de variables de los botones que muestran las modales 
     */
    const btnRegisterPuesto    = document.getElementById('btnregisterpuesto');
    const btnRegisterPuestobtn = document.getElementById('btnregisterpuestobtn');
    const btnSavePuesto = document.getElementById('btnsavepuesto');
    const btnEdiPuesto  = document.getElementById('btnedipuesto');
    const btnSearchPuesto      = document.getElementById('btn-search-puesto');
    // Btns limpia formularios
    const btnClearFieldsJob = document.getElementById('btn-clear-fields-job');
    const icoClearFieldsJob = document.getElementById('ico-clear-fields-job');
    /*
     * Declaracion de variables de las tablas a mostrar
     */
    const dataBodyPuestos = document.getElementById('data-body-puestos');

    /*
     * Declaracion de variables de botones a registrar datos
     */
    

    /*
     * Ejecución de la carga de datos de las tablas
     */

    /*
     * Declaracion de variables de registro de nuevo puesto
    */

    const regpuesto      = document.getElementById('regpuesto');
    const regdescpuesto  = document.getElementById('regdescpuesto');
    const proffamily     = document.getElementById('proffamily');
    const etiqcont       = document.getElementById('etiqcont');
    const regcolect      = document.getElementById('regcolect');
    const graddom        = document.getElementById('graddom');
    const tarjpres       = document.getElementById('tarjpres');
    const clasifpuesto   = document.getElementById('clasifpuesto');
    const nivjerarpuesto = document.getElementById('nivjerarpuesto');
    const perfmanager    = document.getElementById('perfmanager');
    const tabpuesto      = document.getElementById('tabpuesto');
    const sindcat        = document.getElementById('sindcat');
    const clvsat         = document.getElementById('clvsat');

    btnRegisterPuesto.addEventListener('click', () => {
        $("#searchpuesto").modal('hide');
        setTimeout(() => {
            regpuesto.focus();
        }, 1200);
    });    

    btnRegisterPuestobtn.addEventListener('click', () => {
        $("#searchpuestobtn").modal('hide');
        setTimeout(() => {
            regpuesto.focus();
        }, 1200);
    });   

    $('[data-toggle="tooltip"]').tooltip();

    /*
     * Funcion que limpia los campos de registrar un nuevo puesto 
     */

    fclearfieldsnewjob = () => {
        regpuesto.value      = "";
        regdescpuesto.value  = "";
        proffamily.value     = "0";
        etiqcont.value       = "0";
        regcolect.value      = "0";
        graddom.value        = "";
        tarjpres.value       = "";
        clasifpuesto.value   = "0";
        nivjerarpuesto.vale  = "0";
        perfmanager.value    = "0";
        tabpuesto.value      = "0";
        sindcat.value        = "0";
        clvsat.value         = "0";
        nivjerarpuesto.value = "0";
    }

    /*
     * Funcion que carga los datos del select profesion familia 
     */

    floadproffamily = (state, type, keyprof, elementid) => {
        try {
            $.ajax({
                url: "../CatalogsTables/JobFamily",
                type: "POST",
                data: { state: state, type: type, keyprof: keyprof },
                success: (data) => {
                    const quantity = data.length;
                    if (quantity > 0) {
                        for (let i = 0; i < data.length; i++) {
                            elementid.innerHTML += `<option value="${data[i].iIdProfesionFamilia}">${data[i].sNombreProfesion}</option>`;
                        }
                    }
                }, error: (jqXHR, exception) => {
                    fcaptureaerrorsajax(jqXHR, exception);
                }
            });
        } catch (error) {
            if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }

    floadproffamily(1, 'Active/Desactive', 0, proffamily);

    /*
     * Funcion que carga los datos del select etiqetas contables 
     */

    floadtagscont = (state, type, keytag, elementid) => {
        try {
            $.ajax({
                url: "../CatalogsTables/TagsCont",
                type: "POST",
                data: { state: state, type: type, keytag: keytag },
                success: (data) => {
                    const quantity = data.length;
                    if (quantity > 0) {
                        for (let i = 0; i < data.length; i++) {
                            elementid.innerHTML += `<option value="${data[i].iIdEtiquetaContable}">${data[i].sNombreEtiquetaContable}</option>`;
                        }
                    }
                }, error: (jqXHR, exception) => {
                    fcaptureaerrorsajax(jqXHR, exception);
                }
            });
        } catch (error) {
            if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }

    floadtagscont(1, 'Active/Desactive', 0, etiqcont);

    /*
    * Funcion que carga los datos del select nivel jerarquico
    */

    floadnivjer = (state, type, keyniv, elementid) => {
        try {
            $.ajax({
                url: "../CatalogsTables/NivJerar",
                type: "POST",
                data: { state: state, type: type, keyniv: keyniv },
                success: (data) => {
                    const quantity = data.length;
                    if (quantity > 0) {
                        for (let i = 0; i < data.length; i++) {
                            elementid.innerHTML += `<option value="${data[i].iIdNivelJerarquico}">${data[i].sNombreNivelJerarquico}</option>`;
                        }
                    }
                }, error: (jqXHR, exception) => {
                    fcaptureaerrorsajax(jqXHR, exception);
                }
            });
        } catch (error) {
            if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }

    floadnivjer(1, 'Active/Desactive', 0, nivjerarpuesto);

    /*
     * Funcion que carga los datos del select perfomance manager 
     */

    floadperfman = (state, type, keyper, elementid) => {
        try {
            $.ajax({
                url: "../CatalogsTables/PerfManager",
                type: "POST",
                data: { state: state, type: type, keyper: keyper },
                success: (data) => {
                    const quantity = data.length;
                    if (quantity > 0) {
                        for (let i = 0; i < data.length; i++) {
                            elementid.innerHTML += `<option value="${data[i].iIdPerfomanceManager}">${data[i].sPerfomanceManager}</option>`;
                        }
                    }
                }, error: (jqXHR, exception) => {
                    fcaptureaerrorsajax(jqXHR, exception);
                }
            });
        } catch (error) {
            if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }

    floadperfman(1, 'Active/Desactive', 0, perfmanager);

    /*
     * Funcion que carga los datos del select nivel de tabulador 
     */


    floadniveltab = (elementid) => {
        try {
            $.ajax({
                url: "../Empleados/LoadTabs",
                type: "POST",
                data: { state: 1, type: 'Active/Desactive', keytab: 0 },
                success: (data) => {
                    const quantity = data.length;
                    if (quantity > 0) {
                        for (i = 0; i < data.length; i++) {
                            elementid.innerHTML += `<option value="${data[i].iIdTabulador}">${data[i].sTabulador}</option>`;
                        }
                    }
                }, error: (jqXHR, exception) => {
                    fcaptureaerrorsajax(jqXHR, exception);
                }
            });
        } catch (error) {
            if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }

    floadniveltab(tabpuesto);

    floadcataloggeneral = (element, state, type, keycol, catalog) => {
        try {
            $.ajax({
                url: "../CatalogsTables/ClasifPuest",
                type: "POST",
                data: { state: state, type: type, keycla: keycol, catalog: catalog },
                success: (data) => {
                    const quantity = data.length;
                    if (quantity > 0) {
                        for (let i = 0; i < data.length; i++) {
                            element.innerHTML += `<option value="${data[i].iId}">${data[i].sValor}</option>`;
                        }
                    }
                }, error: (jqXHR, exception) => {
                    fcaptureaerrorsajax(jqXHR, exception);
                }
            });
        } catch (error) {
            if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }
    /*
     * Funcion que carga los datos del select clasificacion del puesto 
     */
    floadcataloggeneral(clasifpuesto, 0, 'Active/Desactive', 0, 15);

    /*
     * Funcion que carga los datos del select colectivo
     */
    floadcataloggeneral(regcolect, 0, 'Active/Desactive', 0, 16);

    /*
     * Funcion que carga las claves del sat
    */
    floadcataloggeneral(clvsat, 0, 'Active/Desactive', 0, 17);

    /*
     * Eventos que limpian el formulario de registro de nuevo puesto 
     */
    btnClearFieldsJob.addEventListener('click', fclearfieldsnewjob);
    icoClearFieldsJob.addEventListener('click', fclearfieldsnewjob);

    const spanish = {
        "decimal": "",
        "emptyTable": "No hay información",
        "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
        "infoEmpty": "Mostrando 0 t 0 of 0 Entradas",
        "infoFiltered": "(Filtrado de _MAX_ total entradas)",
        "infoPostFix": "",
        "thousands": ",",
        "lengthMenu": "Mostrar _MENU_ Entradas",
        "loadingRecords": "Cargando...",
        "processing": "Procesando...",
        "search": "Buscar:",
        "zeroRecords": "Sin resultados encontrados",
        "paginate": {
            "first": "Primero",
            "last": "Ultimo",
            "next": "<button class='ml-2 btn btn-sm btn-primary'>Siguiente </button>",
            "previous": "<button class='mr-2 btn btn-sm btn-primary'>Anterior</button>"
        }
    };

    const tableJobs = $("#table-puestos").DataTable({
        responsive: true,
        destroy: true,
        ajax: {
            method: "POST",
            url: "../CatalogsTables/Job",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            dataSrc: "data"
        },
        columns: [
            { "data": "sNombrePuesto" },
            { "data": "sDescripcionPuesto" },
            { "defaultContent": "<button type='button' data-toggle='tooltip' data-placement='left' title='Seleccionar' class='btn text-center btn-outline-primary shadow rounded'> <i class='fas fa-check-circle'></i>" }
        ],
        language: spanish
    });

    $("#table-puestos tbody").on('click', 'button', function () {
        var data = tableJobs.row($(this).parents('tr')).data();
        document.getElementById('pueusu').value = data.sNombrePuesto;
        document.getElementById('puesid').value = data.iIdPuesto;
        $("#searchpuesto").modal('hide');
    });

    const tableJobsbtn = $("#table-puestosbtn").DataTable({
        responsive: true,
        destroy: true,
        ajax: {
            method: "POST",
            url: "../CatalogsTables/Job",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            dataSrc: "data"
        },
        columns: [
            { "data": "sNombrePuesto" },
            { "data": "sDescripcionPuesto" },
            { "defaultContent": "<button data-toggle='modal' data-target='#editpuesto' title='Editar' class='btn text-center btn-outline-warning shadow rounded ml-2'><i class='fas fa-edit'></i></button>" }
        ],
        language: spanish
    });

    const clvpuesto     = document.getElementById('clvpuesto');
    const edipuesto     = document.getElementById('edipuesto');
    const edidescpuesto = document.getElementById('edidescpuesto');
    const ediproffamily = document.getElementById('ediproffamily');
    const edietiqcont   = document.getElementById('edietiqcont');
    const edicolect     = document.getElementById('edicolect');
    const edigraddom    = document.getElementById('edigraddom');
    const editarjpres   = document.getElementById('editarjpres');
    const ediclasifpuesto   = document.getElementById('ediclasifpuesto');
    const edinivjerarpuesto = document.getElementById('edinivjerarpuesto');
    const ediperfmanager    = document.getElementById('ediperfmanager');
    const editabpuesto  = document.getElementById('editabpuesto');
    const edisindicat   = document.getElementById('edisindcat');
    const ediclvsat     = document.getElementById('ediclvsat');

    $("#table-puestosbtn").on('click', 'button', function () {
        var data = tableJobsbtn.row($(this).parents('tr')).data();
        console.log(data);
        $("#searchpuestobtn").modal('hide');
        setTimeout(() => { edipuesto.focus(); }, 1000);
        document.getElementById('namepuestoedi').textContent = data.sNombrePuesto;
        clvpuesto.value     = data.iIdPuesto;
        edipuesto.value     = data.sNombrePuesto;
        edidescpuesto.value = data.sDescripcionPuesto;
        ediproffamily.value = data.iIdProfesionFamilia;
        edietiqcont.value   = data.iIdEtiquetaContable;
        edicolect.value     = data.iIdColectivo;
        edigraddom.value    = data.sGradoDominio;
        editarjpres.value   = data.sTarjetaPres;
        ediclasifpuesto.value   = data.iIdClasificacionPuesto;
        edinivjerarpuesto.value = data.iIdNivelJerarquico;
        ediperfmanager.value    = data.iIdPerfomanceManager;
        editabpuesto.value      = data.iIdTabulador;
        edisindicat.value       = data.sSindicato;
        ediclvsat.value         = data.iIdClaveSat;
    });

    floadproffamily(1, 'Active/Desactive', 0, ediproffamily);
    floadtagscont(1, 'Active/Desactive', 0, edietiqcont);
    floadnivjer(1, 'Active/Desactive', 0, edinivjerarpuesto);
    floadperfman(1, 'Active/Desactive', 0, ediperfmanager);
    floadniveltab(editabpuesto);
    /*
     * Funcion que carga los datos del select clasificacion del puesto 
     */
    floadcataloggeneral(ediclasifpuesto, 0, 'Active/Desactive', 0, 15);

    /*
     * Funcion que carga los datos del select colectivo
     */
    floadcataloggeneral(edicolect, 0, 'Active/Desactive', 0, 16);

    /*
     * Funcion que carga las claves del sat
    */
    floadcataloggeneral(ediclvsat, 0, 'Active/Desactive', 0, 17);


    /*
     * Funcion que genera alertas dinamicas
     */
    fshowtypealert = (title, text, icon, element, clear) => {
        Swal.fire({
            title: title, text: text, icon: icon,
            showClass: { popup: 'animated fadeInDown faster' },
            hideClass: { popup: 'animated fadeOutUp faster' },
            confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
        }).then((acepta) => {
            $("html, body").animate({
                scrollTop: $(`#${element.id}`).offset().top - 50
            }, 1000);
            if (clear == 1) {
                setTimeout(() => {
                    element.focus();
                    setTimeout(() => { element.value = ""; }, 300);
                }, 1200);
            } else {
                setTimeout(() => {
                    element.focus();
                }, 1200);
            }
        });
    }

    String.prototype.capitalize = function () {
        return this.replace(/(^|\s)([a-z])/g, function (m, p1, p2) { return p1 + p2.toUpperCase(); });
    };

    fmayletter = (string) => {
        return string.chartArt(0).toUpperCase() + string.slice(1);
    }

    /*
     * Funcion que guarda los datos de un puesto 
     */

    btnSavePuesto.addEventListener('click', () => {
        const arrInputs = [regpuesto, regdescpuesto, proffamily, etiqcont, regcolect, clasifpuesto, nivjerarpuesto, perfmanager, tabpuesto, sindcat];
        let validate = 0;
        for (let i = 0; i < arrInputs.length; i++) {
            if (arrInputs[i].hasAttribute('tp-select')) {
                if (arrInputs[i].value == "0") {
                    const attrselect = arrInputs[i].getAttribute('tp-select');
                    fshowtypealert('Atención', 'Selecciona una opción para el campo ' + String(attrselect), 'warning', arrInputs[i], 0);
                    validate = 1;
                    break;
                }
            } else {
                if (arrInputs[i].value == "") {
                    fshowtypealert('Atención', 'Completa el campo ' + arrInputs[i].placeholder, 'warning', arrInputs[i], 0);
                    validate = 1;
                    break;
                }
            }
        }
        if (validate == 0) {
            const dataEnv = {
                puesto: regpuesto.value.capitalize(), descripcion: regdescpuesto.value,
                profesion: proffamily.value,          etiqueta: etiqcont.value,
                colectivo: regcolect.value,           grado: graddom.value,
                tarjeta: tarjpres.value,              clasificacion: clasifpuesto.value,
                nivel: nivjerarpuesto.value,          perfomance: perfmanager.value,
                tabulador: tabpuesto.value,           sindicato: sindcat.value, 
                clavesat: clvsat.value,
            };
            try {
                $.ajax({
                    url: "../SaveDataGeneral/SaveDataPuestos",
                    type: "POST",
                    data: dataEnv,
                    success: (data) => {
                        if (data.sMensaje === "success") {
                            Swal.fire({
                                title: 'Registro correcto', icon: 'success',
                                showClass: { popup: 'animated fadeInDown faster' },
                                hideClass: { popup: 'animated fadeOutUp faster' },
                                confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
                            }).then((acepta) => {
                                fclearfieldsnewjob();
                                $("#registerpuesto").modal('hide');
                                tableJobs.ajax.reload();
                                tableJobsbtn.ajax.reload();
                                setTimeout(() => {
                                    if (JSON.parse(localStorage.getItem('modalbtnpuesto')) != null) {
                                        $("#searchpuestobtn").modal('show');
                                    } else {
                                        $("#searchpuesto").modal('show');
                                    }
                                }, 1000);
                            });
                        } else {
                            Swal.fire({
                                title: 'Error', text: 'Contacte a sistemas', icon: 'error',
                                showClass: { popup: 'animated fadeInDown faster' },
                                hideClass: { popup: 'animated fadeOutUp faster' },
                                confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
                            }).then((acepta) => {
                                fclearfieldsnewjob();
                                $("#registerpuesto").modal('hide');
                                setTimeout(() => {
                                    if (JSON.parse(localStorage.getItem('modalbtnpuesto')) != null) {
                                        $("#searchpuestobtn").modal('show');
                                    } else {
                                        $("#searchpuesto").modal('show');
                                    }
                                }, 1000);
                            });
                        }
                    }, error: (jqXHR, exception) => {
                        fcaptureaerrorsajax(jqXHR, exception);
                    }
                });
            } catch (error) {
                if (error instanceof TypeError) {
                    console.log('TypeError ', error);
                } else if (error instanceof RangeError) {
                    console.log('RangeError ', error);
                } else if (error instanceof EvalError) {
                    console.log('EvalError ', error);
                } else {
                    console.log('Error ', error);
                }
            }
        }
    });

    btnEdiPuesto.addEventListener('click', () => {
        const arrInputs = [edipuesto, edidescpuesto, ediproffamily, edietiqcont, edicolect, ediclasifpuesto, edinivjerarpuesto, ediperfmanager, editabpuesto, edisindicat];
        let validate = 0;
        for (let i = 0; i < arrInputs.length; i++) {
            if (arrInputs[i].hasAttribute('tp-select')) {
                if (arrInputs[i].value == "0") {
                    const attrselect = arrInputs[i].getAttribute('tp-select');
                    fshowtypealert('Atención', 'Selecciona una opción para el campo ' + String(attrselect), 'warning', arrInputs[i], 0);
                    validate = 1;
                    break;
                }
            } else {
                if (arrInputs[i].value == "") {
                    fshowtypealert('Atención', 'Completa el campo ' + arrInputs[i].placeholder, 'warning', arrInputs[i], 0);
                    validate = 1;
                    break;
                }
            }
        }
        if (validate == 0) {
            const dataSend = {
                edipuesto: edipuesto.value, edidescpuesto: edidescpuesto.value, ediproffamily: ediproffamily.value, edietiqcont: edietiqcont.value,
                edicolect: edicolect.value, edigraddom: edigraddom.value, editarjpres: editarjpres.value, ediclasifpuesto: ediclasifpuesto.value,
                edinivjerarpuesto: edinivjerarpuesto.value, ediperfmanager: ediperfmanager.value, editabpuesto: editabpuesto.value,
                edisindcat: edisindicat.value, ediclvsat: ediclvsat.value, clvpuesto: clvpuesto.value
            };
            try {
                $.ajax({
                    url: "../EditDataGeneral/EditPuesto",
                    type: "POST",
                    data: dataSend,
                    success: (data) => {
                        if (data.result === "success") {
                            Swal.fire({
                                title: 'Puesto actualizado', icon: 'success',
                                showClass: { popup: 'animated fadeInDown faster' }, hideClass: { popup: 'animated fadeOutUp faster' },
                                confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
                            }).then((acepta) => {
                                $("#editpuesto").modal('hide');
                                tableJobs.ajax.reload();
                                tableJobsbtn.ajax.reload();
                                setTimeout(() => {
                                    if (JSON.parse(localStorage.getItem('modalbtnpuesto')) != null) {
                                        $("#searchpuestobtn").modal('show');
                                    } else {
                                        $("#searchpuesto").modal('show');
                                    }
                                }, 1000);
                            });
                        } else {
                            Swal.fire({
                                title: 'Error', text: 'Contacte a sistemas', icon: 'error',
                                showClass: { popup: 'animated fadeInDown faster' }, hideClass: { popup: 'animated fadeOutUp faster' },
                                confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
                            }).then((acepta) => {
                                fclearfieldsnewjob();
                                $("#editpuesto").modal('hide');
                                setTimeout(() => {
                                    if (JSON.parse(localStorage.getItem('modalbtnpuesto')) != null) {
                                        $("#searchpuestobtn").modal('show');
                                    } else {
                                        $("#searchpuesto").modal('show');
                                    }
                                }, 1000);
                            });
                        }
                    }, error: (jqXHR, exception) => {
                        fcaptureaerrorsajax(jqXHR, exception);
                    }
                });
            } catch (error) {
                if (error instanceof RangeError) {
                    console.log('RangeError ', error);
                } else if (error instanceof EvalError) {
                    console.log('EvalError ', error);
                } else if (error instanceof TypeError) {
                    console.log('TypeError ', error);
                } else {
                    console.log('Error ', error);
                }
            }
        }
    });

    /*
     * Funciones departamentos
     */

    /*
     * Variables departamentos 
     */

    const btnregisterdepartament    = document.getElementById('btnregisterdepartament');
    const btnregisterdepartamentbtn = document.getElementById('btnregisterdepartamentbtn');
    const btnsavedepartament        = document.getElementById('btnsavedepartament');
    const btnedidepartament         = document.getElementById('btnedidepartament');
    const icoClearFieldsDepart      = document.getElementById('ico-clear-fields-departament');
    const btnClearFieldsDepart      = document.getElementById('btn-clear-fields-departament');
    const regdepart  = document.getElementById('regdepart');
    const descdepart = document.getElementById('descdepart');
    const reportaa   = document.getElementById('reportaa');
    const centrcost  = document.getElementById('centrcost');
    const edific     = document.getElementById('edific');
    const nivestuc   = document.getElementById('nivestuc');
    const ubicac     = document.getElementById('ubicac');
    const plaza      = document.getElementById('plaza');
    const titul      = document.getElementById('titul');
    const sucurbanc  = document.getElementById('sucurbanc');
    const categ = document.getElementById('categ');

    fclearfieldsnewdepart = () => {
        regdepart.value  = "";
        descdepart.value = "";
        reportaa.value   = "0";
        centrcost.value  = "0";
        edific.value     = "0";
        nivestuc.value   = "0";
        ubicac.value     = "";
        plaza.value      = "";
        titul.value      = "";
        sucurbanc.value  = "";
        categ.value      = "";
    }

    icoClearFieldsDepart.addEventListener('click', () => { fclearfieldsnewdepart(); });
    btnClearFieldsDepart.addEventListener('click', () => { fclearfieldsnewdepart(); });

    // Funcion que carga las empresas del sistema \\
    floadbusiness = (state, type, keyemp, elementid) => {
        try {
            $.ajax({
                url: "../CatalogsTables/Business",
                type: "POST",
                data: {state: false, type: type, keyemp: keyemp},
                success: (data) => {
                    const quantity = data.length;
                    if (quantity > 0) {
                        for (let i = 0; i < data.length; i++) {
                            elementid.innerHTML += `<option value="${data[i].iIdEmpresa}">${data[i].sNombreEmpresa}</option>`;
                        }
                    }
                }, error: (jqXHR, exception) => {
                    fcaptureaerrorsajax(jqXHR, exception);
                }
            });
        } catch (error) {
            if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }

    floadbusiness(1, 'Active/Desactive', 0, reportaa);

    // Funcion que carga los centros de costo \\
    floadcentrcost = (state, type, keycos, elementid) => {
        try {
            $.ajax({
                url: "../CatalogsTables/CentrCost",
                type: "POST",
                data: { state: state, type: type, keycos: keycos },
                success: (data) => {
                    const quantity = data.length;
                    if (quantity > 0) {
                        for (let i = 0; i < data.length; i++) {
                            elementid.innerHTML += `<option value="${data[i].iIdCentroCosto}">${data[i].sCentroCosto}</option>`;
                        }
                    }
                }, error: (jqXHR, exception) => {
                    fcaptureaerrorsajax(jqXHR, exception);
                }
            });
        } catch (error) {
            if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }

    floadcentrcost(1, 'Active/Desactive', 0, centrcost);

    // Funcion que carga los datos de edificio \\
     
    floadbuilding = (state, type, keyedi, elementid) => {
        try {
            $.ajax({
                url: "../CatalogsTables/Buildings",
                type: "POST",
                data: { state: state, type: type, keyedi: keyedi },
                success: (data) => {
                    const quantity = data.length;
                    if (quantity) {
                        for (let i = 0; i < data.length; i++) {
                            elementid.innerHTML += `<option value="${data[i].iIdEdificio}">${data[i].sNombreEdificio}</option>`;
                        }
                    }
                }, error: (jqXHR, exception) => {
                    fcaptureaerrorsajax(jqXHR, exception);
                }
            });
        } catch (error) {
            if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }

    floadbuilding(1, 'Active/Desactive', 0, edific);

    // Funcion que carga los niveles de estructura \\
    floadnivestuc = (state, type, keyniv, elementid) => {
        try {
            $.ajax({
                url: "../CatalogsTables/NivEstruct",
                type: "POST",
                data: { state: state, type: type, keyniv: keyniv },
                success: (data) => {
                    const quantity = data.length;
                    if (quantity > 0) {
                        for (let i = 0; i < data.length; i++) {
                            elementid.innerHTML += `<option value="${data[i].iIdNivelEstructura}">${data[i].sNivelEstructura}</option>`;
                        }
                    }
                }, error: (jqxHR, exception) => {
                    fcaptureaerrorsajax(jqXHR, exception);
                }
            });
        } catch (error) {
            if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }

    floadnivestuc(1, 'Active/Desactive', 0, nivestuc);

    btnregisterdepartament.addEventListener('click', () => {
        $("#searchdepartament").modal('hide');
        setTimeout(() => { regdepart.focus(); }, 1200);
    });

    btnregisterdepartamentbtn.addEventListener('click', () => {
        $("#searchdepartamentbtn").modal('hide');
        setTimeout(() => { regdepart.focus(); }, 1200);
    });

    /*
     * Inicializacion datatable departamentos 
     */

    const tableDeparts = $("#table-departaments").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "../CatalogsTables/Departaments",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            dataSrc: "data",
        },
        columns: [
            { "data": "sDepartamento" },
            { "data": "sEmpresa" },
            { "defaultContent": "<button type='button' data-toggle='tooltip' data-placement='left' title='Seleccionar' class='btn text-center btn-outline-primary shadow rounded'> <i class='fas fa-check-circle'></i> </button>"}
        ],
        language: spanish
    });

    $("#table-departaments tbody").on('click', 'button', function () {
        var data = tableDeparts.row($(this).parents('tr')).data();
        document.getElementById('depart').value = data.sDepartamento;
        document.getElementById('depaid').value = data.iIdDepartamento;
        $("#searchdepartament").modal('hide');
    });

    const tableDepartsBtn = $("#table-departamentsbtn").DataTable({
        destroy: true,
        responsive: true,
        ajax: {
            method: "POST",
            url: "../CatalogsTables/Departaments",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            dataSrc: "data",
        },
        columns: [
            { "data": "sDepartamento" },
            { "data": "sEmpresa" },
            { "defaultContent": "<button title='Editar departamento' data-toggle='modal' data-target='#editdepartament' class='btn text-center btn-outline-warning shadow rounded ml-2'><i class='fas fa-edit'></i></button>" }
        ],
        language: spanish
    });

    const clvdepart     = document.getElementById('clvdepart');
    const edidepart     = document.getElementById('edidepart');
    const edidescdepart = document.getElementById('edidescdepart');
    const edireportaa   = document.getElementById('edireportaa');
    const edicentrcost  = document.getElementById('edicentrcost');
    const ediedific     = document.getElementById('ediedific');
    const edinivestuc   = document.getElementById('edinivestuc');
    const ediubicac     = document.getElementById('ediubicac');
    const ediplaza      = document.getElementById('ediplaza');
    const edititul      = document.getElementById('edititul');
    const edisucurbanc  = document.getElementById('edisucurbanc');
    const edicateg      = document.getElementById('edicateg');

    floadcentrcost(1, 'Active/Desactive', 0, edicentrcost);
    floadbusiness(1, 'Active/Desactive', 0, edireportaa);
    floadbuilding(1, 'Active/Desactive', 0, ediedific);
    floadnivestuc(1, 'Active/Desactive', 0, edinivestuc);


    $("#table-departamentsbtn tbody").on('click', 'button', function () {
        $("#searchdepartamentbtn").modal('hide');
        var data = tableDepartsBtn.row($(this).parents('tr')).data();
        setTimeout(() => { edidepart.focus(); }, 1000);
        document.getElementById('namedepartamentedi').textContent = data.sDepartamento;
        clvdepart.value     = data.iIdDepartamento;
        edidepart.value     = data.sDepartamento;
        edidescdepart.value = data.sDescripcionDepartamento;
        edireportaa.value   = data.iEmpresaReporta_id;
        edicentrcost.value  = data.iCentroCosto_id;
        ediedific.value     = data.iEdificio_id;
        edinivestuc.value   = data.iNivelEstructura_id;
        ediubicac.value     = data.sUbicacion;
        ediplaza.value      = data.sPlaza;
        edititul.value      = data.sTitular;
        edisucurbanc.value  = data.sSucursalBancaria;
        edicateg.value      = data.sCategoria;
    });

    /*
     * Guarda datos de nuevo departamento
     */


    btnsavedepartament.addEventListener('click', () => {
        const arrInputs = [regdepart, descdepart, reportaa, centrcost, edific, nivestuc];
        let validate = 0;
        for (let i = 0; i < arrInputs.length; i++) {
            if (arrInputs[i].hasAttribute('tp-select')) {
                if (arrInputs[i].value == "0") {
                    const attrselect = arrInputs[i].getAttribute('tp-select');
                    fshowtypealert('Atención', 'Selecciona una opción para el campo ' + String(attrselect), 'warning', arrInputs[i], 0);
                    validate = 1;
                    break;
                }
            } else {
                if (arrInputs[i].value == "") {
                    fshowtypealert('Atención', 'Completa el campo ' + arrInputs[i].placeholder, 'warning', arrInputs[i], 0);
                    validate = 1;
                    break;
                }
            }
        }
        if (validate == 0) {
            const dataEnv = {
                regdepart: regdepart.value, descdepart: descdepart.value,
                reportaa: reportaa.value,   centrcost: centrcost.value,
                edific: edific.value,       nivestuc: nivestuc.value,
                ubicac: ubicac.value,       plaza: plaza.value,
                titul: titul.value,         sucurbanc: sucurbanc.value,
                categ: categ.value
            };
            try {
                $.ajax({
                    url: "../SaveDataGeneral/SaveDepartament",
                    type: "POST",
                    data: dataEnv,
                    success: (data) => {
                        if (data.result === "success") {
                            Swal.fire({
                                title: 'Registro correcto', icon: 'success',
                                showClass: { popup: 'animated fadeInDown faster' },
                                hideClass: { popup: 'animated fadeOutUp faster' },
                                confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
                            }).then((acepta) => {
                                fclearfieldsnewdepart();
                                $("#registerdepartament").modal('hide');
                                tableDeparts.ajax.reload();
                                tableDepartsBtn.ajax.reload();
                                setTimeout(() => {
                                    if (JSON.parse(localStorage.getItem('modalbtndepartament')) != null) {
                                        $("#searchdepartamentbtn").modal('show');
                                    } else {
                                        $("#searchdepartament").modal('show');
                                    }
                                }, 1000);
                            });
                        } else {
                            Swal.fire({
                                title: 'Error', text: 'Contacte a sistemas', icon: 'error',
                                showClass: { popup: 'animated fadeInDown faster' },
                                hideClass: { popup: 'animated fadeOutUp faster' },
                                confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
                            }).then((acepta) => {
                                fclearfieldsnewdepart();
                                $("#registerdepartament").modal('hide');
                                setTimeout(() => {
                                    if (JSON.parse(localStorage.getItem('modalbtndepartament')) != null) {
                                        $("#searchdepartamentbtn").modal('show');
                                    } else {
                                        $("#searchdepartament").modal('show');
                                    }
                                }, 1000);
                            });
                        }
                    }, error: (jqXHR, exception) => {
                        fcaptureaerrorsajax(jqXHR, exception);
                    }
                });
            } catch (error) {
                if (error instanceof RangeError) {
                    console.log('RangeError ', error);
                } else if (error instanceof EvalError) {
                    console.log('EvalError ', error);
                } else if (error instanceof TypeError) {
                    console.log('TypeError ', error);
                } else {
                    console.log('Error ', error);
                }
            }
        }
    });

    btnedidepartament.addEventListener('click', () => {
        const arrInputs = [edidepart, edidescdepart, edireportaa, edicentrcost, ediedific, edinivestuc];
        let validate = 0;
        for (let i = 0; i < arrInputs.length; i++) {
            if (arrInputs[i].hasAttribute('tp-select')) {
                if (arrInputs[i].value == "0") {
                    const attrselect = arrInputs[i].getAttribute('tp-select');
                    fshowtypealert('Atención', 'Selecciona una opción para el campo ' + String(attrselect), 'warning', arrInputs[i], 0);
                    validate = 1;
                    break;
                }
            } else {
                if (arrInputs[i].value == "") {
                    fshowtypealert('Atención', 'Completa el campo ' + arrInputs[i].placeholder, 'warning', arrInputs[i], 0);
                    validate = 1;
                    break;
                }
            }
        }
        if (validate == 0) {
            const dataSend = {
                edidepart: edidepart.value, edidescdepart: edidescdepart.value, edireportaa: edireportaa.value, edicentrcost: edicentrcost.value,
                ediedific: ediedific.value, edinivestuc: edinivestuc.value, ediubicac: ediubicac.value, ediplaza: ediplaza.value, edititul: edititul.value,
                edisucurbanc: edisucurbanc.value, edicateg: edicateg.value, clvdepart: clvdepart.value
            };
            try {
                $.ajax({
                    url: "../EditDataGeneral/EditDepartament",
                    type: "POST",
                    data: dataSend,
                    success: (data) => {
                        if (data.result === "success") {
                            Swal.fire({
                                title: 'Departamento actualizado', icon: 'success',
                                showClass: { popup: 'animated fadeInDown faster' }, hideClass: { popup: 'animated fadeOutUp faster' },
                                confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
                            }).then((acepta) => {
                                $("#editdepartament").modal('hide');
                                tableDeparts.ajax.reload();
                                tableDepartsBtn.ajax.reload();
                                setTimeout(() => {
                                    if (JSON.parse(localStorage.getItem('modalbtndepartament')) != null) {
                                        $("#searchdepartamentbtn").modal('show');
                                    } else {
                                        $("#searchdepartament").modal('show');
                                    }
                                }, 1000);
                            });
                        } else {
                            Swal.fire({
                                title: 'Error', text: 'Contacte a sistemas', icon: 'error',
                                showClass: { popup: 'animated fadeInDown faster' }, hideClass: { popup: 'animated fadeOutUp faster' },
                                confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
                            }).then((acepta) => {
                                $("#editdepartament").modal('hide');
                                setTimeout(() => {
                                    if (JSON.parse(localStorage.getItem('modalbtndepartament')) != null) {
                                        $("#searchdepartamentbtn").modal('show');
                                    } else {
                                        $("#searchdepartament").modal('show');
                                    }
                                }, 1000);
                            });
                        }
                    }, error: (jqXHR, exception) => {
                        fcaptureaerrorsajax(jqXHR, exception);
                    }
                });
            } catch (error) {
                if (error instanceof RangeError) {
                    console.log('RangeError ', error);
                } else if (error instanceof TypeError) {
                    console.log('TypeError ', error);
                } else if (error instanceof EvalError) {
                    console.log('EvalError ', error);
                } else {
                    console.log('Error ', error);
                }
            }
        }
    });

});