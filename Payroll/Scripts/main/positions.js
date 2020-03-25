﻿$(function () {

    /* FUNCION QUE CARGA LOS DATOS DE LA POSICION SELECCIONADA POR EL USUARIO */
    fselectposition = (param) => {
        console.log(param);
        try {
            searchpositionkey.value = '';
            resultpositions.innerHTML = '';
            $.ajax({
                url: "../SearchDataCat/DataSelectPosition",
                type: "POST",
                data: { clvposition: param },
                success: (data) => {
                    if (data.iIdPosicion != 0) {
                        document.getElementById('depart').value = data.sNombreDepartamento;
                        document.getElementById('pueusu').value = data.sNombrePuesto;
                        document.getElementById('numpla').value = data.sPosicionCodigo;
                        document.getElementById('clvstr').value = data.iIdPosicion;
                        document.getElementById('emprep').value = data.sRegistroPat;
                        document.getElementById('localty').value = data.sLocalidad;
                        document.getElementById('report').value = data.iIdReportaAPosicion;
                        document.getElementById('msjfech').classList.remove('d-none');
                        $("#searchpositionstab").modal('hide');
                        console.log(data);
                    } else {
                        Swal.fire({
                            title: "Atencion", text: "No se encontro resultado con tu busqueda", icon: "warning",
                            allowEnterKey: false, allowEscapeKey: false, allowOutsideClick: false
                        }).then((acepta) => {
                            setTimeout(() => { searchpositionkey.focus(); }, 1000);
                        });
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
    /* CONSTANTES REGISTRO DE POSICIONES */
    const codposic = document.getElementById('codposic');
    const regpatcla = document.getElementById('regpatcla');
    const departreg = document.getElementById('departreg');
    const pueusureg = document.getElementById('pueusureg');
    const depaid = document.getElementById('depaid');
    const puesid = document.getElementById('puesid');
    const fechefectpos = document.getElementById('fechefectpos');
    const localityr = document.getElementById('localityr');
    const localityrtxt = document.getElementById('localityrtxt');
    const emprepreg = document.getElementById('emprepreg');
    const emprepregtxt = document.getElementById('emprepregtxt');
    const report = document.getElementById('report');
    const reportempr = document.getElementById('reportempr');
    /* CONSTANTES EDICION DE POSICIONES */
    const codtxtinf = document.getElementById('codtxtinf');
    const clvposition = document.getElementById('clvposition');
    const edicodposic = document.getElementById('edicodposic');
    const depaidedit = document.getElementById('depaidedit');
    const departedit = document.getElementById('departedit');
    const puesidedit = document.getElementById('puesidedit');
    const pueusuedit = document.getElementById('pueusuedit');
    const editatcla = document.getElementById('editatcla');
    const editlocalityr = document.getElementById('editlocalityr');
    const edilocalityrtxt = document.getElementById('edilocalityrtxt');
    const emprepedit = document.getElementById('emprepedit');
    const emprepregtxtedit = document.getElementById('emprepregtxtedit');
    const edireportempr = document.getElementById('edireportempr');
    const btnsearchdepartamentoedit = document.getElementById('btn-search-departamento-edit');
    const btnsearchpuestoedit = document.getElementById('btn-search-puesto-edit');
    const btnsearchlocalityedit = document.getElementById('btn-search-localidad-edit');
    const btnsearchpositionedit = document.getElementById('btn-search-positionadd-edit');
    const btnclearpositionsedit = document.getElementById('btn-clear-positions-edit');
    const icoclearpositionsedit = document.getElementById('ico-clear-positions-edit');
    const btnsavepositionedit = document.getElementById('btnsavepositionedit');
    /* FUNCION QUE ELIMINA EL LOCALSTORAGE MODALBTNPOSITIONS */
    fremovelocalstclear = () => {
        searchpositionkeybtn.value = '';
        resultpositionsbtn.innerHTML = '';
        $("#searchpositions").modal('show');
        setTimeout(() => { searchpositionkeybtn.focus(); }, 1000);
    }
    /* EJECUCION DE EVENTO QUE REMUEVE EL LOCALSTORAGE MODALBTNPOSITIONS */
    btnclearpositionsedit.addEventListener('click', fremovelocalstclear);
    icoclearpositionsedit.addEventListener('click', fremovelocalstclear);
    /* EJECUCION DE EVENTO QUE OCULTA LA VENTANA MODAL DE EDICION */
    //btnsearchdepartamentoedit.addEventListener('click', () => {
    //    $("#editposition").modal('hide');
    //    setTimeout(() => { searchdepartmentkeyadd.focus(); }, 1000);
    //});
    //btnsearchpuestoedit.addEventListener('click', () => {
    //    $("#editposition").modal('hide');
    //    setTimeout(() => { searchpuestokeyadd.focus(); }, 1000);
    //});
    //btnsearchlocalityedit.addEventListener('click', () => {
    //    $("#editposition").modal('hide');
    //    setTimeout(() => { searchlocalityadd.focus(); }, 1000);
    //});
    //btnsearchpositionedit.addEventListener('click', () => {
    //    $("#editposition").modal('hide');
    //    setTimeout(() => { searchpositionkeyadd.focus(); }, 1000);
    //});
    /* CONSTANTES BOTONES REGISTRO DE POSICIONES */
    const btnclearfieldspositions = document.getElementById('btn-clear-fields-positions');
    const icoclearfieldspositions = document.getElementById('ico-clear-fields-positions');
    const btnsaveposition = document.getElementById('btnsaveposition');
    /* FUNCION QUE LIMPIA LOS CAMPOS DE REGISTRO DE UNA NUEVA POSICION */
    fclearfieldsregpositions = () => {
        codposic.value = '';
        depaid.value = '';
        departreg.value = '';
        puesid.value = '';
        pueusureg.value = '';
        regpatcla.value = '0';
        localityr.value = '';
        localityrtxt.value = '';
        emprepreg.value = '';
        emprepregtxt.value = '';
        reportempr.value = '0';
    }
    /* EJECUCION DE FUNCION QUE LIMPIA LOS CAMPOS DE REGISTRO DE UNA NUEVA POSICION */
    btnclearfieldspositions.addEventListener('click', fclearfieldsregpositions);
    icoclearfieldspositions.addEventListener('click', fclearfieldsregpositions);
    /* CONSTANTES BUSQUEDA DE POSICIONES */
    const searchpositions = document.getElementById('searchpositionkey');
    const resultpositions = document.getElementById('resultpositions');
    /* CONSTANTES BOTONES DE BUSQUEDA DE POSICIONES */
    const btnregisterpositions = document.getElementById('btnregisterpositions');
    /* CONSTANTES BOTONES DE CIERRE DE MODAL */
    const btnCloseSearchPositions = document.getElementById('btn-close-search-positions');
    const icoCloseSearchPositions = document.getElementById('ico-close-search-positions');
    /* CONSTANTES BUSQUEDA DE POSICION */
    const btnsearchtableposition = document.getElementById('btn-search-table-num-posicion');
    /* CONSTANTES BUSQUEDA DE POSICION AL AÑADIR UNA NUEVA */
    const searchpositionkeyadd = document.getElementById('searchpositionkeyadd');
    const resultpositionsadd = document.getElementById('resultpositionsadd');
    const btnsearchpositionadd = document.getElementById('btn-search-positionadd');
    const icoclosesearchpositionsadd = document.getElementById('ico-close-search-positionsadd');
    const btnclosesearchpositionsadd = document.getElementById('btn-close-search-positionsadd');
    /* FUNCION QUE LIMPIA EL CAMPO DE BUSQUEDA Y LA LISTA DE RESULTADOS */
    fclearsearchresults = () => {
        searchpositionkeyadd.value = '';
        resultpositionsadd.innerHTML = '';
        $("#searchpositionsadd").modal('hide');
        $("#registerposition").modal('show');
        setTimeout(() => { emprepreg.focus(); }, 1000);
    }
    /* EJECUCION DE EVENTO QUE ACTIVA LA CAJA DE BUSQUEDA DE POSICION AL AÑADIR UNA NUEVA */
    btnsearchpositionadd.addEventListener('click', () => {
        $("#registerposition").modal('hide');
        setTimeout(() => { searchpositionkeyadd.focus(); }, 1000);
    });
    /* CONSTANTES DE BUSQUEDA DE POSICIONES POR MEDIO DE BOTON */
    const btnmodalsearchpositions = document.getElementById('btn-modal-search-positions');
    const searchpositionkeybtn = document.getElementById('searchpositionkeybtn');
    const resultpositionsbtn = document.getElementById('resultpositionsbtn');
    const icoclosesearchpositionsbtn = document.getElementById('ico-close-searchpositions-btn');
    const btnclosesearchpositionsbtn = document.getElementById('btn-close-searchpositions-btn');
    const btnregisterpositionbtnadd = document.getElementById('btnregisterpositionbtnadd');
    /* EJECUCION DE EVENTO QUE ACTIVA EL CAMPO DE BUSQUEDA AL HACER CLICK EN EL BOTON DE POSICIONES */
    btnmodalsearchpositions.addEventListener('click', () => {
        localStorage.setItem('modalbtnpositions', 1);
        setTimeout(() => { searchpositionkeybtn.focus(); }, 1000);
    });
    /* FUNCION QUE LIMPIA EL CAMPO DE BUSQUEDA Y LA LISTA DE RESULTADOS DE LAS POSICIONES BTN */
    fclearsearchresultsbtn = () => {
        searchpositionkeybtn.value = '';
        resultpositionsbtn.innerHTML = '';
    }
    localStorage.removeItem('modalbtnpositions');
    /* EJECUCION DE FUNCION */
    icoclosesearchpositionsbtn.addEventListener('click', () => {
        fclearsearchresultsbtn();
        localStorage.removeItem('modalbtnpositions');
    });
    btnclosesearchpositionsbtn.addEventListener('click', () => {
        fclearsearchresultsbtn();
        localStorage.removeItem('modalbtnpositions');
    });
    btnregisterpositionbtnadd.addEventListener('click', () => {
        fclearsearchresultsbtn();
        $("#searchpositions").modal('hide');
        setTimeout(() => { codposic.focus(); }, 1000);
    });
    /* CONSTANTES BOTONES DE REGISTRO POSICION */
    const btnsearchnumposition = document.getElementById('btn-search-num-position');
    const btnSearchDepartament = document.getElementById('btn-search-departamento');
    /* LIMPIA LA BUSQUEDA AL CERRAR LA MDOAL */
    btnCloseSearchPositions.addEventListener('click', () => { searchpositions.value = ''; resultpositions.innerHTML = ''; });
    icoCloseSearchPositions.addEventListener('click', () => { searchpositions.value = ''; resultpositions.innerHTML = ''; });
    /* EJECUCION DE FUNCION QUE OCULTA LA BUSUQUEDA DE POSICIONES */
    btnregisterpositions.addEventListener('click', () => {
        searchpositions.value = '';
        resultpositions.innerHTML = '';
        $("#searchpositionstab").modal('hide');
        setTimeout(() => { codposic.focus(); }, 1000);
    });
    /* EJECUCION DE EVENTO QUE OCULTA EL REGISTRO DE POSICIONES Y MUESTRA LOS DEPARTAMENTOS DISPONIBLES PARA ASIGNARLOS A UNA POSICION */
    btnSearchDepartament.addEventListener('click', () => { $("#registerposition").modal('hide'); });
    /* EJECUCION DE EVENTO QUE ACTIVA EL INPUT DE LA BUSQUEDA DE POSICIONES */
    btnsearchtableposition.addEventListener('click', () => { setTimeout(() => { searchpositionkey.focus(); }, 1000); });
    /* FUNCION QUE BUSCA EL NUMERO DE POSICION EN TIEMPO REAL */
    fsearchpositionsig = () => {
        try {
            $.ajax({
                url: "../SearchDataCat/SearchNumPosition",
                type: "POST",
                data: {},
                success: (data) => {
                    if (data.mesage == "success") {
                        codposic.value = data.result;
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
    /* EJECUCION DE FUNCION QUE BUSCA LA POSICION SIGUIENTE */
    btnsearchnumposition.addEventListener('click', fsearchpositionsig);
    /* FUNCION QUE HACE LA BUSQUEDA EN TIEMPO REAL */
    fsearchkeyuppositions = () => {
        resultpositions.innerHTML = '';
        try {
            if (searchpositions.value != "") {
                $.ajax({
                    url: "../SearchDataCat/SearchPositions",
                    type: "POST",
                    data: { wordsearch: searchpositions.value, type: 'EMPR' },
                    success: (data) => {
                        if (data.length > 0) {
                            let number = 0;
                            for (let i = 0; i < data.length; i++) {
                                number += 1;
                                resultpositions.innerHTML += `<button class="list-group-item d-flex justify-content-between mb-1 align-items-center shadow rounded cg-back">${number}. ${data[i].sPosicionCodigo} - ${data[i].sNombrePuesto} <i class="fas fa-check-circle ml-2 col-ico fa-lg" onclick="fselectposition(${data[i].iIdPosicion})"></i> </button>`;
                            }
                        }
                        console.log(data);
                    }, error: (jqXHR, exception) => {
                        fcaptureaerrorsajax(jqXHR, exception);
                    }
                });
            }
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
    /* EJECUCION DE LA BUSQUEDA EN TIEMPO REAL */
    searchpositions.addEventListener('keyup', fsearchkeyuppositions);
    /* FUNCION QUE CARGA LOS REGISTROS PATRONALES DE LAS EMPRESAS */
    floadregpatclases = (element) => {
        try {
            $.ajax({
                url: "../Empleados/LoadRegPatCla",
                type: "POST",
                data: {},
                success: (data) => {
                    const quantity = data.length;
                    if (quantity > 0) {
                        for (let i = 0; i < data.length; i++) {
                            element.innerHTML += `<option value="${data[i].iIdRegPat}">${data[i].sAfiliacionIMSS}</option>`;
                        }
                    } else {
                        console.log('No hay registros');
                    }
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
    /* EJECUCION DE FUNCION QUE CARGA LOS REGISTROS PATRONALES */
    //floadregpatclases(regpatcla);
    /* FUNCION QUE CARGA LOS DATOS DE LA POSICION SELECCIONADA AL AÑADIR UNA NUEVA */
    fselectpositionadd = (paramid, paramstr) => {
        try {
            searchpositionkeyadd.value = '';
            resultpositionsadd.innerHTML = '';
            $("#searchpositionsadd").modal('hide');
            $("#registerposition").modal('show');
            emprepreg.value = paramid;
            emprepregtxt.value = paramstr;
            //if (localStorage.getItem('modalbtnpositions') != null) {
            //    $("#editposition").modal('show');
            //    emprepedit.value       = paramid;
            //    emprepregtxtedit.value = paramstr;
            //} else {
            //    $("#registerposition").modal('show');
            //    emprepreg.value    = paramid;
            //    emprepregtxt.value = paramstr;
            //}
            setTimeout(() => { emprepregtxt.focus(); }, 1000);
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
    /* FUNCION QUE REALIZA LA BUSQUEDA DE POSICIONES EN TIEMPO REAL AL MOMENTO DE AGREGAR UNA NUEVA POSICION */
    fsearchkeyuppositionsadd = () => {
        try {
            resultpositionsadd.innerHTML = '';
            if (searchpositionkeyadd.value != "") {
                $.ajax({
                    url: "../SearchDataCat/SearchPositions",
                    type: "POST",
                    data: { wordsearch: searchpositionkeyadd.value, type: 'ALL' },
                    success: (data) => {
                        if (data.length > 0) {
                            let number = 0;
                            for (let i = 0; i < data.length; i++) {
                                number += 1;
                                resultpositionsadd.innerHTML += `<button class="list-group-item d-flex justify-content-between mb-1 align-items-center shadow rounded cg-back">${number}. ${data[i].sPosicionCodigo} - ${data[i].sNombrePuesto} <i class="fas fa-check-circle ml-2 col-ico fa-lg" onclick="fselectpositionadd(${data[i].iIdPosicion}, '${data[i].sPosicionCodigo}')"></i> </button>`;
                            }
                        }
                    }, error: (jqXHR, exception) => {
                        fcaptureaerrorsajax(jqXHR, exception);
                    }
                });
            } else {
                resultpositionsadd.innerHTML = '';
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
    /* EJECUCION DE FUNCION QUE REALIZA LA BUSQUEDA DE POSICIONES */
    searchpositionkeyadd.addEventListener('keyup', fsearchkeyuppositionsadd);
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
    floadbusiness(0, 'Active/Desactive', 0, reportempr);
    /* EJECUCION DE EVENTO QUE REGISTRA UNA NUEVA POSICION */
    btnsaveposition.addEventListener('click', () => {
        try {
            const arrInput = [codposic, depaid, puesid, regpatcla, localityr, emprepreg, reportempr];
            let validate = 0;
            for (let i = 0; i < arrInput.length; i++) {
                if (arrInput[i].hasAttribute('tp-select')) {
                    if (arrInput[i].value == "0") {
                        const attrselect = arrInput[i].getAttribute('tp-select');
                        fshowtypealert('Atención', 'Selecciona una opción para el campo ' + String(attrselect), 'warning', arrInput[i], 0);
                        validate = 1;
                        break;
                    }
                } else {
                    if (arrInput[i].value == "") {
                        fshowtypealert('Atención', 'Completa el campo ' + arrInput[i].placeholder, 'warning', arrInput[i], 0);
                        validate = 1;
                        break;
                    }
                }
            }
            if (validate == 0) {
                const dataSend = {
                    codposic: codposic.value, depaid: depaid.value, puesid: puesid.value, regpatcla: regpatcla.value,
                    localityr: localityr.value, emprepreg: emprepreg.value, reportempr: reportempr.value
                };
                console.log(dataSend);
                $.ajax({
                    url: "../SaveDataGeneral/SavePositions",
                    type: "POST",
                    data: dataSend,
                    success: (data) => {
                        if (data.result === "success") {
                            Swal.fire({
                                title: 'Posicion registrada', icon: 'success',
                                showClass: { popup: 'animated fadeInDown faster' }, hideClass: { popup: 'animated fadeOutUp faster' },
                                confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
                            }).then((acepta) => {
                                $("#registerposition").modal('hide');
                                fclearfieldsregpositions();
                                setTimeout(() => {
                                    if (JSON.parse(localStorage.getItem('modalbtnpositions')) != null) {
                                        $("#searchpositions").modal('show');
                                        setTimeout(() => { searchpositionkeybtn.focus(); }, 1000);
                                    } else {
                                        $("#searchpositionstab").modal('show');
                                        setTimeout(() => { searchpositionkey.focus(); }, 1000);
                                    }
                                }, 1000);
                            });
                        } else {
                            Swal.fire({
                                title: 'Error', text: 'Contacte a sistemas', icon: 'error',
                                showClass: { popup: 'animated fadeInDown faster' }, hideClass: { popup: 'animated fadeOutUp faster' },
                                confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
                            }).then((acepta) => {
                                $("#registerposition").modal('hide');
                                fclearfieldsregpositions();
                                setTimeout(() => {
                                    if (JSON.parse(localStorage.getItem('modalbtnpositions')) != null) {
                                        $("#searchpositions").modal('show');
                                        setTimeout(() => { searchpositionkeybtn.focus(); }, 1000);
                                    } else {
                                        $("#searchpositionstab").modal('show');
                                        setTimeout(() => { searchpositionkey.focus(); }, 1000);
                                    }
                                }, 1000);
                            });
                        }
                    }, error: (jqxHR, exception) => {
                        fcaptureaerrorsajax(jqxHR, exception);
                    }
                });
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
    });
    /* FUNCION QUE CARGA LOS DATOS DE LA POSICION SELECCIONADA PARA SER EDITADA */
    fviewdatailspos = (paramid) => {
        //floadregpatclases(editatcla);
        floadbusiness(0, 'Active/Desactive', 0, edireportempr);
        $("#searchpositions").modal('hide');
        try {
            if (paramid != 0) {
                $.ajax({
                    url: "../SearchDataCat/DataSelectPosition",
                    type: "POST",
                    data: { clvposition: paramid },
                    success: (data) => {
                        $("#editposition").modal('show');
                        clvposition.value = data.iIdPosicion;
                        codtxtinf.textContent = data.sPosicionCodigo;
                        edicodposic.value = data.sPosicionCodigo;
                        //depaidedit.value  = data.iDepartamento_id;
                        departedit.value = data.sNombreDepartamento;
                        //puesidedit.value  = data.iPuesto_id;
                        pueusuedit.value = data.sNombrePuesto;
                        editatcla.innerHTML = `<option value="${data.iIdRegistroPat}">${data.sRegistroPat}</option>`;
                        //editlocalityr.value = data.iIdLocalidad;
                        edilocalityrtxt.value = data.sLocalidad;
                        //emprepedit.value = data.iIdReportaAPosicion;
                        emprepregtxtedit.value = data.sCodRepPosicion;
                        edireportempr.value = data.iIdReportaAEmpresa;
                        //setTimeout(() => { edicodposic.focus(); }, 1000);
                    }, error: (jqXHR, exception) => {
                        fcaptureaerrorsajax(jqXHR, exception);
                    }
                });
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
    /* FUNCION QUE REALIZA LA BUSQUEDA EN TIEMPO REAL DE POSICIONES AL DAR CLICK EN EL BOTON DE POSICIONES */
    fsearchkeyuppositionsbtn = () => {
        try {
            resultpositionsbtn.innerHTML = '';
            if (searchpositionkeybtn.value != "") {
                $.ajax({
                    url: "../SearchDataCat/SearchPositionsList",
                    type: "POST",
                    data: { wordsearch: searchpositionkeybtn.value },
                    success: (data) => {
                        if (data.length > 0) {
                            let number = 0;
                            for (let i = 0; i < data.length; i++) {
                                number += 1;
                                resultpositionsbtn.innerHTML += `<button class="list-group-item d-flex justify-content-between mb-1 align-items-center shadow rounded cg-back" title="Editar">${number}. ${data[i].sPosicionCodigo} - ${data[i].sNombrePuesto} <i class="fas fa-eye ml-2 col-ico fa-lg" onclick="fviewdatailspos(${data[i].iIdPosicion})"></i> </button>`;
                            }
                        }
                    }, error: (jqXHR, exception) => {
                        fcaptureaerrorsajax(jqXHR, exception);
                    }
                });
            } else {
                resultpositionsbtn.innerHTML = '';
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
    searchpositionkeybtn.addEventListener('keyup', fsearchkeyuppositionsbtn);
    /* EJECUCION DEL EVENTO QUE GUARDA LA EDICION DE LA POSICION */
    //btnsavepositionedit.addEventListener('click', () => {
    //    try {
    //        const arrInput = [edicodposic, depaidedit, puesidedit, editatcla, editlocalityr, emprepedit, edireportempr];
    //        let validate = 0;
    //        for (let i = 0; i < arrInput.length; i++) {
    //            if (arrInput[i].hasAttribute('tp-select')) {
    //                if (arrInput[i].value == "0") {
    //                    const attrselect = arrInput[i].getAttribute('tp-select');
    //                    fshowtypealert('Atención', 'Selecciona una opción para el campo ' + String(attrselect), 'warning', arrInput[i], 0);
    //                    validate = 1;
    //                    break;
    //                }
    //            } else {
    //                if (arrInput[i].value == "") {
    //                    fshowtypealert('Atención', 'Completa el campo ' + arrInput[i].placeholder, 'warning', arrInput[i], 0);
    //                    validate = 1;
    //                    break;
    //                }
    //            }
    //        }
    //        if (validate == 0) {
    //            const dataSend = {
    //                edicodposic: edicodposic.value, depaidedit: depaidedit.value, puesidedit: puesidedit.value, editatcla: editatcla.value,
    //                editlocalityr: editlocalityr.value, emprepedit: emprepedit.value, edireportempr: edireportempr.value,
    //                clvposition: clvposition.value
    //            };
    //            console.log(dataSend);
    //            //$.ajax({
    //            //    url: "../SaveDataGeneral/SavePositions",
    //            //    type: "POST",
    //            //    data: dataSend,
    //            //    success: (data) => {
    //            //        if (data.result === "success") {
    //            //            Swal.fire({
    //            //                title: 'Posicion registrada', icon: 'success',
    //            //                showClass: { popup: 'animated fadeInDown faster' }, hideClass: { popup: 'animated fadeOutUp faster' },
    //            //                confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
    //            //            }).then((acepta) => {
    //            //                $("#registerposition").modal('hide');
    //            //                setTimeout(() => {
    //            //                    if (JSON.parse(localStorage.getItem('modalbtnpositions')) != null) {
    //            //                        $("#searchpositions").modal('show');
    //            //                    } else {
    //            //                        $("#searchpositionstab").modal('show');
    //            //                    }
    //            //                }, 1000);
    //            //            });
    //            //        } else {
    //            //            Swal.fire({
    //            //                title: 'Error', text: 'Contacte a sistemas', icon: 'error',
    //            //                showClass: { popup: 'animated fadeInDown faster' }, hideClass: { popup: 'animated fadeOutUp faster' },
    //            //                confirmButtonText: "Aceptar", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false,
    //            //            }).then((acepta) => {
    //            //                $("#registerposition").modal('hide');
    //            //                setTimeout(() => {
    //            //                    if (JSON.parse(localStorage.getItem('modalbtnpositions')) != null) {
    //            //                        $("#searchpositions").modal('show');
    //            //                    } else {
    //            //                        $("#searchpositionstab").modal('show');
    //            //                    }
    //            //                }, 1000);
    //            //            });
    //            //        }
    //            //    }, error: (jqxHR, exception) => {
    //            //        fcaptureaerrorsajax(jqxHR, exception);
    //            //    }
    //            //});
    //        }
    //    } catch (error) {
    //        if (error instanceof TypeError) {
    //            console.log('TypeError ', error);
    //        } else if (error instanceof EvalError) {
    //            console.log('EvalError ', error);
    //        } else if (error instanceof RangeError) {
    //            console.log('RangeError ', error);
    //        } else {
    //            console.log('Error ', error);
    //        }
    //    }
    //});
});