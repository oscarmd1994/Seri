﻿$(function () {

    /* CONSTANTES DE LA BUSQUEDA DE UN DEPARTAMENTO AL REGISTRAR UNO NUEVO */
    const searchdepartmentkeynew = document.getElementById('searchdepartmentkeynew');
    const resultdepartmentsnew   = document.getElementById('resultdepartmentsnew');
    /* CONSTANTES DEL FORMULARIO QUE HACE LA BUSQUEDA EN TIEMPO REAL */
    const searchdepartmentkey = document.getElementById('searchdepartmentkey');
    const resultdepartments   = document.getElementById('resultdepartments');
    /* CONSTANTES DEL FORMULARIO QUE HACE LA BUSQUEDA EN TIEMPO REAL 2 */
    const searchdepartmentkeyadd = document.getElementById('searchdepartmentkeyadd');
    const resultdepartmentsadd = document.getElementById('resultdepartmentsadd');
    const btnclosesearchdepartamentsadd = document.getElementById('btn-close-search-departamentsadd');
    const icoclosesearchdepartamentsadd = document.getElementById('ico-close-search-departamentsadd');
    /* FUNCION QUE LIMPIA EL CAMPO DE BUSQUEDA Y LA LISTA DE RESULTADOS */
    fclearsearchresults = () => {
        searchdepartmentkeyadd.value = '';
        resultdepartmentsadd.innerHTML = '';
        $("#searchdepartament").modal('hide');
        $("#registerposition").modal('show');
        setTimeout(() => { departreg.focus(); }, 1000);
    }
    /* EJECUCION DE EVENTO QUE HACE QUE SE LIMPIE EL CAMPO DE BUSQUEDA Y LA LISTA DE RESULTADOS */
    btnclosesearchdepartamentsadd.addEventListener('click', fclearsearchresults);
    icoclosesearchdepartamentsadd.addEventListener('click', fclearsearchresults);
    /* CONSTANTES DEL FORMULARIO DE POSICIONES A REGISTRAR CAMPOS DE DEPARTAMENTO */
    const depaid     = document.getElementById('depaid');
    const departreg  = document.getElementById('departreg');
    const depaidedit = document.getElementById('depaidedit');
    const departedit = document.getElementById('departedit');
    const btnsearchdepartamento = document.getElementById('btn-search-departamento');
    /* EJECUCION DE EVENTO QUE HACE QUE SE ACTIVE EL CAMPO DE BUSQUEDA DEL DEPARTAMENTO */
    btnsearchdepartamento.addEventListener('click', () => { setTimeout(() => { searchdepartmentkeyadd.focus(); }, 1000); });
    /* CONSTANTES DEL FORMULARIO QUE HACE QUE SE LIMPIE EL CAMPO DE BUSQUEDA */
    const btnModalSearchDepartament = document.getElementById('btn-modal-search-departament');
    const btnclosesearchdepbtn = document.getElementById('btn-close-search-departament-btn')
    const icoclosesearchdepbtn = document.getElementById('ico-close-search-departament-btn');
    /* EJECUCION DE LA LIMPIEZA DEL CAMPO DE BUSQUEDA */
    btnclosesearchdepbtn.addEventListener('click', () => { searchdepartmentkey.value = ''; resultdepartments.innerHTML = ''; });
    icoclosesearchdepbtn.addEventListener('click', () => { searchdepartmentkey.value = ''; resultdepartments.innerHTML = ''; });
    /* CREACION DE LOCALSTORAGE */
    localStorage.removeItem('modalbtndepartament');
    btnModalSearchDepartament.addEventListener('click', () => {
        localStorage.setItem('modalbtndepartament', 1);
        setTimeout(() => { searchdepartmentkey.focus(); }, 1000);
    });
    btnclosesearchdepbtn.addEventListener('click', () => { localStorage.removeItem('modalbtndepartament'); });
    icoclosesearchdepbtn.addEventListener('click', () => { localStorage.removeItem('modalbtndepartament'); });
    /* CONSTANTES DE BOTONES QUE HACEN LA BUSQUEDA DE DEPARTAMENTOS */
    const btnSearchTableDepartament0 = document.getElementById('btn-search-table-departaments0');
    const btnSearchTableDepartament1 = document.getElementById('btn-search-table-departaments1');
    const btnSearchTableDepartament2 = document.getElementById('btn-search-table-departaments2');
    const btnSearchTableDepartament3 = document.getElementById('btn-search-table-departaments3');
    const btnSearchTableDepartament4 = document.getElementById('btn-search-table-departaments4');
    /* ELIMINA EL LOCAL STORAGE AL CARGAR LA PAGINA */
    localStorage.removeItem('departsearch0');
    localStorage.removeItem('departsearch1');
    localStorage.removeItem('departsearch2');
    localStorage.removeItem('departsearch3');
    localStorage.removeItem('departsearch4');
    /* FUNCION QUE GENERA LOCALSTORAGE */
    fgeneratelocalstobtns = (param) => {
        localStorage.setItem(String(param), 1);
        $("#registerdepartament").modal('hide');
        setTimeout(() => { searchdepartmentkeynew.focus(); }, 1000);
    }
    /* EJECUCION DE FUNCIONES PARA IDENTIFICAR EN QUE BOTON SE DIO CLICK */
    btnSearchTableDepartament0.addEventListener('click', () => { fgeneratelocalstobtns('departsearch0'); });
    btnSearchTableDepartament1.addEventListener('click', () => { fgeneratelocalstobtns('departsearch1'); });
    btnSearchTableDepartament2.addEventListener('click', () => { fgeneratelocalstobtns('departsearch2'); });
    btnSearchTableDepartament3.addEventListener('click', () => { fgeneratelocalstobtns('departsearch3'); });
    btnSearchTableDepartament4.addEventListener('click', () => { fgeneratelocalstobtns('departsearch4'); });
    /* CONSTANTES DEPARTAMENTOS */
    const btnregisterdepartament = document.getElementById('btnregisterdepartament');
    const btnregisterdepartamentbtn = document.getElementById('btnregisterdepartamentbtn');
    const btnsavedepartament = document.getElementById('btnsavedepartament');
    const btnedidepartament = document.getElementById('btnedidepartament');
    const icoClearFieldsDepart = document.getElementById('ico-clear-fields-departament');
    const btnClearFieldsDepart = document.getElementById('btn-clear-fields-departament');
    const regdepart = document.getElementById('regdepart');
    const descdepart = document.getElementById('descdepart');
    const reportaa = document.getElementById('reportaa');
    const centrcost = document.getElementById('centrcost');
    const centrcosttxtr = document.getElementById('centrcosttxtr');
    const edific = document.getElementById('edific');
    const edifictxt = document.getElementById('edifictxt');
    const piso = document.getElementById('piso');
    const nivestuc = document.getElementById('nivestuc');
    const ubicac = document.getElementById('ubicac');
    const dgatxt = document.getElementById('dgatxt');
    const nivsuptxt = document.getElementById('nivsuptxt');
    const dirgentxt = document.getElementById('dirgentxt');
    const direjetxt = document.getElementById('direjetxt');
    const diraretxt = document.getElementById('diraretxt');
    const dirgen = document.getElementById('dirgen');
    const direje = document.getElementById('direje');
    const dirare = document.getElementById('dirare');
    // Variables edita departamento
    const clvdepart = document.getElementById('clvdepart');
    const edidepart = document.getElementById('edidepart');
    const edidescdepart = document.getElementById('edidescdepart');
    const nivsuptxtedit = document.getElementById('nivsuptxtedit');
    const edireportaa = document.getElementById('edireportaa');
    const edicentrcost = document.getElementById('edicentrcost');
    const ediedific = document.getElementById('ediedific');
    const edinivestuc = document.getElementById('edinivestuc');
    const edipiso = document.getElementById('edipiso');
    const ediubicac = document.getElementById('ediubicac');
    const edidgatxt = document.getElementById('edidgatxt');
    const edidirgentxt = document.getElementById('edidirgentxt');
    const edidirejetxt = document.getElementById('edidirejetxt');
    const edidiraretxt = document.getElementById('edidiraretxt');
    const edidirgen = document.getElementById('edidirgen');
    const edidireje = document.getElementById('edidireje');
    const edidirare = document.getElementById('edidirare');
    const btnSearchTableDepartament0Edit = document.getElementById('btn-search-table-departaments0edit');
    const btnSearchTableDepartament1Edit = document.getElementById('btn-search-table-departaments1edit');
    const btnSearchTableDepartament2Edit = document.getElementById('btn-search-table-departaments2edit');
    const btnSearchTableDepartament3Edit = document.getElementById('btn-search-table-departaments3edit');
    const btnSearchTableDepartament4Edit = document.getElementById('btn-search-table-departaments4edit');
    /* CONSTANTES DEL CENTRO DE COSTOS */
    const btnsearchcentrcost      = document.getElementById('btn-search-centrcosts');
    const btnclosesearchcentrcost = document.getElementById('btn-close-search-centrcost');
    const icoclosesearchcentrcost = document.getElementById('ico-close-search-centrcost');
    /* EJECUCION DE DE FUNCION QUE OCULTA LA VENTANA DE REGISTRO DE DEPARTAMENTO AL BUSCAR UN CENTRO DE COSTOS */
    btnsearchcentrcost.addEventListener('click', () => { $("#registerdepartament").modal('hide'); setTimeout(() => { searchcentrcosts.focus(); }, 1000); });
    btnclosesearchcentrcost.addEventListener('click', () => { $("#registerdepartament").modal('show'); });
    icoclosesearchcentrcost.addEventListener('click', () => { $("#registerdepartament").modal('show'); });
    /* EJECUCION DE FUNCIONQUE OCULTA LA VENTANA MODAL DE BUSQUEDA DE DEPARTAMENTOS */
    btnregisterdepartamentbtn.addEventListener('click', () => {
        $("#searchdepartamentbtn").modal('hide');
        searchdepartmentkey.value = '';
        resultdepartments.innerHTML = '';
        floadnivestuc(0, 'Active/Desactive', 0, nivestuc, 0);
        //floadbuilding('Active/Desactive', 0, edific, 0);
        //floadcentrcost(0, 'Active/Desactive', 0, centrcost);
        floadbusiness(0, 'Active/Desactive', 0, reportaa);
        floadbusiness(0, 'Active/Desactive', 0, dirgen);
        floadbusiness(0, 'Active/Desactive', 0, direje);
        floadbusiness(0, 'Active/Desactive', 0, dirare);
        setTimeout(() => { regdepart.focus(); }, 1000);
    });
    /* FUNCION QUE LIMPIA LOS CAMPOS DE REGISTRAR EL DEPARTAMENTO */
    fclearfieldsnewdepart = () => {
        localStorage.removeItem('modalbtndepartament');
        regdepart.value = ""; descdepart.value = "";
        nivestuc.value = "0"; nivsuptxt.value = "";
        edific.value = "0";   piso.value = "";
        ubicac.value = "";    centrcost.value = "0";
        reportaa.value = "0"; dgatxt.value = "";
        dirgentxt.value = ""; direjetxt.value = "";
        diraretxt.value = ""; dirgen.value = "0";
        direje.value = "0";   dirare.value = "0";
    }
    /* EJECUCIÓN DE FUNCIONES QUE LIMPIAN LOS CAMPOS DEL REGISTRAR UN DEPARTAMENTO */
    btnClearFieldsDepart.addEventListener('click', fclearfieldsnewdepart);
    icoClearFieldsDepart.addEventListener('click', fclearfieldsnewdepart);
    // Funcion que carga los niveles de estructura \\
    floadnivestuc = (state, type, keyniv, elementid, val) => {
        try {
            $.ajax({
                url: "../CatalogsTables/NivEstruct",
                type: "POST",
                data: { state: state, type: type, keyniv: keyniv },
                success: (data) => {
                    const quantity = data.length;
                    if (quantity > 0) {
                        for (let i = 0; i < data.length; i++) {
                            console.log(data[i]);
                            if (val == data[i].sNivelEstructura) {
                                elementid.innerHTML += `<option selected value="${data[i].sNivelEstructura}">${data[i].sNivelEstructura} - ${data[i].sDescripcion}</option>`;
                            } else {
                                elementid.innerHTML += `<option value="${data[i].sNivelEstructura}">${data[i].sNivelEstructura} - ${data[i].sDescripcion}</option>`;
                            }
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
    // Funcion que carga los datos de edificio \\
    floadbuilding = (type, keyedi, elementid, val) => {
        try {
            $.ajax({
                url: "../CatalogsTables/Buildings",
                type: "POST",
                data: { type: type, keyedi: keyedi },
                success: (data) => {
                    const quantity = data.length;
                    if (quantity) {
                        for (let i = 0; i < data.length; i++) {
                            if (val == data[i].iIdEdificio) {
                                elementid.innerHTML += `<option selected value="${data[i].iIdEdificio}">${data[i].sNombreEdificio}</option>`;
                            } else {
                                elementid.innerHTML += `<option value="${data[i].iIdEdificio}">${data[i].sNombreEdificio}</option>`;
                            }
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
    // Funcion que carga las empresas del sistema \\
    floadbusiness = (state, type, keyemp, elementid) => {
        try {
            $.ajax({
                url: "../CatalogsTables/Business",
                type: "POST",
                data: { state: state, type: type, keyemp: keyemp },
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
    /* FUNCION QUE CARGA LOS DATOS DEL DEPARTAMENTO SELECCIONADO AL MOMENTO DE EDITARLOS */
    fselectdepartment = (param) => {
        try {
            $.ajax({
                url: "../SearchDataCat/SelectDepartment",
                type: "POST",
                data: { clvdep: param },
                success: (data) => {
                    /* EJECUCIÓN DE FUNCION QUE CARGA EL SELECT DE NIVEL ESTRUCTURA */
                    floadnivestuc(0, 'Active/Desactive', 0, edinivestuc, 0);
                    /* EJECUCIÓN DE FUNCION QUE CARGA EL SELECT EDIFICIOS */
                    floadbuilding('Active/Desactive', 0, ediedific, 0);
                    /* EJECUCIÓN DE FUNCION QUE CARGA EL SELECT CENTRO DE COSTOS */
                    floadcentrcost(0, 'Active/Desactive', 0, edicentrcost);
                    /* EJECUCIÓN DE FUNCION QUE CARGA EL SELECT REPORTA A */
                    floadbusiness(0, 'Active/Desactive', 0, edireportaa);
                    /* EJECUCIÓN DE FUNCION QUE CARGA EL SELECT DIRECCION GENERAL */
                    floadbusiness(0, 'Active/Desactive', 0, edidirgen);
                    /* EJECUCIÓN DE FUNCION QUE CARGA EL SELECT DIRECCION EJECUTIVA */
                    floadbusiness(0, 'Active/Desactive', 0, edidireje);
                    /* EJECUCIÓN DE FUNCION QUE CARGA EL SELECT DIRECCION DE AREA */
                    floadbusiness(0, 'Active/Desactive', 0, edidirare);
                    $("#editdepartament").modal('show');
                    $("#searchdepartamentbtn").modal('hide');
                    searchdepartmentkey.value = ''; resultdepartments.innerHTML = '';
                    document.getElementById('namedepartamentedi').textContent = data.sDescripcionDepartamento;
                    clvdepart.value = data.iIdDepartamento;
                    edidepart.value = data.sDeptoCodigo;
                    edidescdepart.value = data.sDescripcionDepartamento;
                    nivsuptxtedit.value = data.sNivelSuperior;
                    edinivestuc.value = data.sNivelEstructura;
                    ediedific.value = data.iEdificioId;
                    edipiso.value = data.sPiso;
                    ediubicac.value = data.sUbicacion;
                    edicentrcost.value = data.iCentroCostoId;
                    edireportaa.value = data.iEmpresaReportaId;
                    edidgatxt.value = data.sDGA;
                    edidirgentxt.value = data.sDirecGen;
                    edidirejetxt.value = data.sDirecEje;
                    edidiraretxt.value = data.sDirecAre;
                    edidirgen.value = data.iEmpreDirGen;
                    edidireje.value = data.iEmpreDirEje;
                    edidirare.value = data.iEmpreDirAre;
                    console.log(data);
                }, error: (jqXHR, exception) => {
                    fcaptureaerrorsajax(jqXHR, exception);
                }
            });
        } catch (error) {
            if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }
    /* FUNCION QUE EJECUTA LA BUSQUEDA EN TIEMPO REAL */
    fsearchdepartments = () => {
        resultdepartments.innerHTML = '';
        try {
            if (searchdepartmentkey.value != "") {
                $.ajax({
                    url: "../SearchDataCat/SearchDepartaments",
                    type: "POST",
                    data: { wordsearch: searchdepartmentkey.value, type: 'EMPR' },
                    success: (data) => {
                        if (data.length > 0) {
                            let number = 0;
                            for (let i = 0; i < data.length; i++) {
                                number += 1;
                                resultdepartments.innerHTML += `<button class="list-group-item d-flex justify-content-between mb-1 align-items-center shadow rounded cg-back">${number}. - ${data[i].sDeptoCodigo} <i class="fas fa-edit ml-2 text-warning fa-lg" onclick="fselectdepartment(${data[i].iIdDepartamento})"></i> </button>`;
                            }
                        }
                    }, error: (jqXHR, exception) => {
                        fcaptureaerrorsajax(jqXHR, exception);
                    }
                });
            } else {
                resultdepartments.innerHTML = '';
            }
        } catch (error) {
            if (error instanceof TypeError) {
                console.log('TypeError ', error);
            } else if (error instanceof EvalError) {
                console.log('EvalError ', error);
            } else if (error instanceof RangeError) {
                console.log('RangeError ', error);
            } else {
                console.log('Error ', error);
            }
        }
    }
    /* EJECUCION DE LA BUSQUEDA EN TIEMPO REAL */
    searchdepartmentkey.addEventListener('keyup', fsearchdepartments);
    /* GUARDADO DE LA EDICION DE LOS DEPARTAMENTOS */
    btnedidepartament.addEventListener('click', () => {
        const arrInputs = [edidepart, edidescdepart, edinivestuc, ediedific, edipiso, edicentrcost, edireportaa, edidirgen, edidireje, edidirare];
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
                edidepart: edidepart.value, edidescdepart: edidescdepart.value, edinivestuc: edinivestuc.value, nivsuptxtedit: nivsuptxtedit.value,
                ediedific: ediedific.value, edipiso: edipiso.value, ediubicac: ediubicac.value, edicentrcost: edicentrcost.value,
                edireportaa: edireportaa.value, edidgatxt: edidgatxt.value, edidirgentxt: edidirgentxt.value, edidirejetxt: edidirejetxt.value,
                edidiraretxt: edidiraretxt.value, edidirgen: edidirgen.value, edidireje: edidireje.value, edidirare: edidirare.value,
                clvdepart: clvdepart.value
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
                                setTimeout(() => {
                                    if (JSON.parse(localStorage.getItem('modalbtndepartament')) != null) {
                                        $("#searchdepartamentbtn").modal('show');
                                        setTimeout(() => { searchdepartmentkey.focus(); }, 1000);
                                    } else {
                                        $("#searchdepartament").modal('show');
                                        setTimeout(() => { searchdepartmentkey.focus(); }, 1000);
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
    /* FUNCION QUE GUARDA LOS DATOS DE UN NUEVO DEPARTAMENTO */
    btnsavedepartament.addEventListener('click', () => {
        const arrInputs = [regdepart, descdepart, nivestuc, edific, piso, centrcost, reportaa, dirgen, direje, dirare];
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
                nivestuc: nivestuc.value, nivsuptxt: nivsuptxt.value,
                edific: edific.value, piso: piso.value,
                ubicac: ubicac.value, centrcost: centrcost.value,
                reportaa: reportaa.value, dgatxt: dgatxt.value,
                dirgentxt: dirgentxt.value, direjetxt: direjetxt.value,
                diraretxt: diraretxt.value, dirgen: dirgen.value,
                direje: direje.value, dirare: dirare.value,
            };
            console.log(dataEnv)
            try {
                $.ajax({
                    url: "../SaveDataGeneral/SaveDepartament",
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
                                fclearfieldsnewdepart();
                                $("#registerdepartament").modal('hide');
                                setTimeout(() => {
                                    if (JSON.parse(localStorage.getItem('modalbtndepartament')) != null) {
                                        $("#searchdepartamentbtn").modal('show');
                                        setTimeout(() => { searchdepartmentkey.focus(); }, 1000);
                                    } else {
                                        $("#searchdepartament").modal('show');
                                    }
                                }, 1000);
                            });
                        } else if (data.sMensaje === "depexists") {
                            Swal.fire({
                                title: 'Atencion', text: 'El departamento con codigo ' + String(regdepart.value) + ' ya se encuentra registrado.', icon: 'warning',
                                showClass: { popup: 'animated fadeInDown faster' },
                                hideClass: { popup: 'animated fadeOutUp faster' },
                                confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
                            }).then((acepta) => {
                                setTimeout(() => { regdepart.focus(); }, 1000);
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
    /* CONSTANTES BOTONES BUSQUEDA DE DEPARTAMENTOS AL MOMENTO DE REGISTRAR UNO NUEVO */
    const btnclosesearchclosedepbtn = document.getElementById('btn-close-searchclosedep-btn');
    const icoclosesearchclosedepbtn = document.getElementById('ico-close-searchdepartament-btn');
    const btnclosesearchedifics = document.getElementById('btn-close-search-edifics');
    const icoclosesearchedifics = document.getElementById('ico-close-search-edifics');
    /* EJECUCION QUE MUESTRA LA VENTANA DE NUEVO DEPARTAMENTO AL MOMENTO DE CERRAR LA BUSQUEDA DE LOS DEPARTAMENTOS */
    btnclosesearchclosedepbtn.addEventListener('click', () => { $("#registerdepartament").modal('show'); });
    icoclosesearchclosedepbtn.addEventListener('click', () => { $("#registerdepartament").modal('show'); });
    btnclosesearchedifics.addEventListener('click', () => { $("#registerdepartament").modal('show'); });
    icoclosesearchedifics.addEventListener('click', () => { $("#registerdepartament").modal('show'); });
    /* FUNCION QUE CARGA EN LOS INPUTS EL DEPARTAMENTO SELECCIONADO */
    fselectoption = (paramid, paramstr) => {
        $("#searchdepartamentsdirec").modal('hide');
        searchdepartmentkeynew.value = '';
        resultdepartmentsnew.innerHTML = '';
        try {
            if (localStorage.getItem('departsearch0') != null) {
                nivsuptxt.value = paramstr;
                localStorage.removeItem('departsearch0');
                $("#registerdepartament").modal('show');
            }
            if (localStorage.getItem('departsearch1') != null) {
                dgatxt.value = paramstr;
                localStorage.removeItem('departsearch1');
                $("#registerdepartament").modal('show');
            }
            if (localStorage.getItem('departsearch2') != null) {
                dirgentxt.value = paramstr;
                localStorage.removeItem('departsearch2');
                $("#registerdepartament").modal('show');
            }
            if (localStorage.getItem('departsearch3') != null) {
                direjetxt.value = paramstr;
                localStorage.removeItem('departsearch3');
                $("#registerdepartament").modal('show');
            }
            if (localStorage.getItem('departsearch4') != null) {
                diraretxt.value = paramstr;
                localStorage.removeItem('departsearch4');
                $("#registerdepartament").modal('show');
            }
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
    /* FUNCION QUE EJECUTA LA BUSQUEDA EN TIEMPO REAL AL MOMENTO DE REGISTRAR UN NUEVO DEPARTAMENTO */
    fsearchdepartamentsnew = () => {
        try {
            resultdepartmentsnew.innerHTML = '';
            if (searchdepartmentkeynew.value != "") {
                $.ajax({
                    url: "../SearchDataCat/SearchDepartaments",
                    type: "POST",
                    data: { wordsearch: searchdepartmentkeynew.value, type: 'ALL' },
                    success: (data) => {
                        if (data.length > 0) {
                            let number = 0;
                            for (let i = 0; i < data.length; i++) {
                                number += 1;
                                resultdepartmentsnew.innerHTML += `<button class="list-group-item d-flex justify-content-between mb-1 align-items-center shadow rounded cg-back">${number}. - ${data[i].sDeptoCodigo} <i class="fas fa-check-circle ml-2 col-ico fa-lg" onclick="fselectoption(${data[i].iIdDepartamento},'${data[i].sDeptoCodigo}')"></i> </button>`;
                            }
                        }
                    }, error: (jqXHR, exception) => {
                        fcaptureaerrorsajax(jqXHR, exception);
                    }
                });
            } else {
                resultdepartmentsnew.innerHTML = '';
            }
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
    /* EJECUCION DE LA BUSQUEDA EN TIEMPO REAL AL MOMENTO DE REGISTRAR UNO NUEVO */
    searchdepartmentkeynew.addEventListener('keyup', fsearchdepartamentsnew);
    /* CONSTANTES DE LA BUSQUEDA DE CENTROS DE COSTOS */
    const searchcentrcosts = document.getElementById('searchcentrcosts');
    const resultcentrcosts = document.getElementById('resultcentrcosts');
    /* FUNCION QUE EJECUTA LA CARGA DE DATOS DEL CENTRO DE COSTO SELECCIONADO */
    fselectcentrcost = (paramid, paramstr) => {
        try {
            $("#searchcentrscost").modal('hide');
            $("#registerdepartament").modal('show');
            centrcost.value     = paramid;
            centrcosttxtr.value = paramstr;
            setTimeout(() => { reportaa.focus(); }, 1000);
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
    /* FUNCION QUE EJECUTA LA BUSQUEDA DE CENTROS DE COSTOS EN TIEMPO REAL AL MOMENTO DE REGISTRAR UN NUEVO DEPARTAMENTO */
    fsearchcentrcostos = () => {
        resultcentrcosts.innerHTML = '';
        try {
            if (searchcentrcosts.value != "") {
                $.ajax({
                    url: "../SearchDataCat/SearchCentrCost",
                    type: "POST",
                    data: { wordsearch: searchcentrcosts.value },
                    success: (data) => {
                        if (data.length > 0) {
                            let number = 0;
                            for (let i = 0; i < data.length; i++) {
                                number += 1;
                                resultcentrcosts.innerHTML += `<button class="list-group-item d-flex justify-content-between mb-1 align-items-center shadow rounded cg-back">${number}. - ${data[i].sCentroCosto} <i class="fas fa-check-circle ml-2 col-ico fa-lg" onclick="fselectcentrcost(${data[i].iIdCentroCosto},'${data[i].sCentroCosto}')"></i> </button>`;
                            }
                        }
                    }, error: (jqXHR, exception) => {
                        fcaptureaerrorsajax(jqXHR, exception);
                    }
                });
            } else {
                resultcentrcosts.innerHTML = '';
            }
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
    /* EJECUCION DE LA FUNCION DE BUSQUEDA EN TIEMPO REAL DE LOS CENTROS DE COSTO */
    searchcentrcosts.addEventListener('keyup', fsearchcentrcostos);
    /* CONSTANTES DE LA BUSQUEDA DE EDIFICIOS */
    const searchedifickey = document.getElementById('searchedifickey');
    const resultedifics   = document.getElementById('resultedifics');
    const btnsearchedific = document.getElementById('btn-search-edific');
    /* EJECUCION DE LA FUNCION QUE CIERRA LA VENTANA DE MODAL DE REGISTRO DE DEPARTAMENTO */
    btnsearchedific.addEventListener('click', () => { $("#registerdepartament").modal('hide'); setTimeout(() => { searchedifickey.focus(); }, 1000); });
    /* FUNCION QUE CARGA LOS DATOS EN LOS INPUTS DEL EDIFICIO SELECCIONADO */
    fselectedific = (paramid, paramstr) => {
        try {
            $("#searchedific").modal('hide');
            $("#registerdepartament").modal('show');
            edific.value = paramid;
            edifictxt.value = paramstr;
            setTimeout(() => { piso.focus() }, 1000);
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
    /* FUNCION QUE EJECUTA LA BUSQUEDA DE EDIFICIOS EN TIEMPO REAL AL MOMENTO DE REGISTRAR UN NUEVO DEPARTAMENTO */
    fsearchedific = () => {
        resultedifics.innerHTML = '';
        try {
            if (searchedifickey.value != "") {
                $.ajax({
                    url: "../SearchDataCat/SearchEdifics",
                    type: "POST",
                    data: { wordsearch: searchedifickey.value },
                    success: (data) => {
                        if (data.length > 0) {
                            let number = 0;
                            for (let i = 0; i < data.length; i++) {
                                number += 1;
                                resultedifics.innerHTML += `<button class="list-group-item d-flex justify-content-between mb-1 align-items-center shadow rounded cg-back">${number}. - ${data[i].sNombreEdificio} <i class="fas fa-check-circle ml-2 col-ico fa-lg" onclick="fselectedific(${data[i].iIdEdificio},'${data[i].sNombreEdificio}')"></i> </button>`;
                            }
                        }
                    }, error: (jqXHR, exception) => {
                        fcaptureaerrorsajax(jqXHR, exception);
                    }
                });
            } else {
                resultedifics.innerHTML = '';
            }
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
    /* EJECUCION DE LA FUNCION DE BUSQUEDA EN TIEMPO REAL DE LOS EDIFICIOS */
    searchedifickey.addEventListener('keyup', fsearchedific);
    /* FUNCION QUE CARGA LOS DATOS DE SELECCIONAR UN DEPARTAMENTO AL CREAR UNA NUEVA POSICION */
    fselectoptionnewposition = (paramid, paramstr) => {
        try {
            searchdepartmentkeyadd.value   = '';
            resultdepartmentsadd.innerHTML = '';
            $("#searchdepartament").modal('hide');
            $("#registerposition").modal('show');
            depaid.value    = paramid;
            departreg.value = paramstr;
            //if (localStorage.getItem('modalbtnpositions') != null) {
            //    $("#editposition").modal('show');
            //    depaidedit.value = paramid;
            //    departedit.value = paramstr;
            //} else {
            //    $("#registerposition").modal('show');
            //    depaid.value    = paramid;
            //    departreg.value = paramstr;
            //}
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
    /* FUNCION QUE CARGA LOS DEPARTAMENTOS AL MOMENTO DE CREAR UNA NUEVA POSICION */
    fsearchdepartamentsadd = () => {
        try {
            resultdepartmentsadd.innerHTML = '';
            if (searchdepartmentkeyadd.value != "") {
                $.ajax({
                    url: "../SearchDataCat/SearchDepartaments",
                    type: "POST",
                    data: { wordsearch: searchdepartmentkeyadd.value, type: 'ALL' },
                    success: (data) => {
                        if (data.length > 0) {
                            let number = 0;
                            for (let i = 0; i < data.length; i++) {
                                number += 1;
                                resultdepartmentsadd.innerHTML += `<button class="list-group-item d-flex justify-content-between mb-1 align-items-center shadow rounded cg-back">${number}. - ${data[i].sDeptoCodigo} <i class="fas fa-check-circle ml-2 col-ico fa-lg" onclick="fselectoptionnewposition(${data[i].iIdDepartamento},'${data[i].sDeptoCodigo}')"></i> </button>`;
                            }
                        }
                    }, error: (jqXHR, exception) => {
                        fcaptureaerrorsajax(jqXHR, exception);
                    }
                });
            } else {
                resultdepartmentsadd.innerHTML = '';
            }
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
    /* EJECUCION DE LA FUNCION QUE CARGA LOS DEPARTAMENTOS AL MOMENTO DE REGISTRAR UNA NUEVA POSICION */
    searchdepartmentkeyadd.addEventListener('keyup', fsearchdepartamentsadd);
});