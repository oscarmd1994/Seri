$(function () {
    console.log("EL BENI xxx");
    const dateact = document.getElementById('dateact');
    let d = new Date();
    let monthact = d.getMonth() + 1, dayact = d.getDay(), montlet = "", daylet = "";
    const months = ['', 'Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'];

    for (let i = 0; i < months.length; i++) {
        if (monthact == i) {
            montlet = months[i];
        }
    }

    const days = ['', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado', 'Domingo'];

    for (let d = 0; d < days.length; d++) {
        if (dayact == d) {
            daylet = days[d];
        }
    }

    dateact.textContent = daylet + " " + d.getDate() + " de " + montlet + " del " + d.getFullYear() + ".";

    const navDataGenTab = document.getElementById('nav-datagen-tab'),
        navImssTab = document.getElementById('nav-imss-tab'),
        navDataNomTab = document.getElementById('nav-datanom-tab'),
        navEstructureTab = document.getElementById('nav-estructure-tab');

    const
        btnsaveedit = document.getElementById('btn-save-edit'),
        btnClearLocSto = document.getElementById('btn-clear-localstorage'),
        btnSaveDataGen = document.getElementById('btn-save-data-gen'),
        btnSaveDataImss = document.getElementById('btn-save-data-imss'),
        btnSaveDataNomina = document.getElementById('btn-save-data-nomina'),
        btnSaveDataEstructure = document.getElementById('btn-save-data-estructure');

    let objectDataTabDataGen = {},
        objectDataTabImss = {},
        objectDataTabNom = {},
        objectDataTabEstructure = {};

    // Variables formulario Datos Generales \\ 
    const clvemp = document.getElementById('clvemp'),
        name = document.getElementById('name'), apep = document.getElementById('apepat'),
        apem = document.getElementById('apemat'), fnaci = document.getElementById('fnaci'),
        lnaci = document.getElementById('lnaci'),
        title = document.getElementById('title'),
        sex = document.getElementById('sex'), nacion = document.getElementById('nacion'),
        estciv = document.getElementById('estciv'), codpost = document.getElementById('codpost'),
        state = document.getElementById('state'), city = document.getElementById('city'),
        colony = document.getElementById('colony'),
        street = document.getElementById('street'), numberst = document.getElementById('numberst'),
        telfij = document.getElementById('telfij'),
        telmov = document.getElementById('telmov'),
        mailus = document.getElementById('mailus');


    const vardatagen = [name, apep, apem, fnaci, lnaci, title, sex, nacion, estciv, codpost, state, city, colony, street, numberst,
        telfij, telmov, mailus];

    fclearfieldsvar1 = () => {
        for (let i = 0; i < vardatagen.length; i++) {
            if (vardatagen[i].getAttribute('tp-select') != null) {
                vardatagen[i].value = "0";
            } else {
                vardatagen[i].value = "";
            }
        }
    }

    // Variables formulario IMSS \\
    const imss = document.getElementById('regimss'), clvimss = document.getElementById('clvimss'),
        rfc = document.getElementById('rfc'), curp = document.getElementById('curp'),
        nivest = document.getElementById('nivest'), nivsoc = document.getElementById('nivsoc');

    const vardataimss = [imss, rfc, curp, nivest, nivsoc];
    fclearfieldsvar2 = () => {
        for (let i = 0; i < vardataimss.length; i++) {
            if (vardataimss[i].getAttribute('tp-select') != null) {
                vardataimss[i].value = "0";
            } else {
                vardataimss[i].value = "";
            }
        }
    }

    // Variables formulario datos nomina \\
    const clvnom = document.getElementById('clvnom'),
        numnom = document.getElementById('numnom'), salmen = document.getElementById('salmen'),
        pagret = document.getElementById('pagret'), tipemp = document.getElementById('tipemp'),
        tipmon = document.getElementById('tipmon'), nivemp = document.getElementById('nivemp'),
        tipjor = document.getElementById('tipjor'), tipcon = document.getElementById('tipcon'),
        fecing = document.getElementById('fecing'), fecant = document.getElementById('fecant'),
        vencon = document.getElementById('vencon'), estats = document.getElementById('estats');

    const vardatanomina = [numnom, salmen, pagret, tipemp, nivemp, tipjor, tipcon, fecing, fecant, vencon, estats];
    fclearfieldsvar3 = () => {
        for (let i = 0; i < vardatanomina.length; i++) {
            if (vardatanomina[i].getAttribute('tp-select') != null) {
                vardatanomina[i].value = "0";
            } else {
                vardatanomina[i].value = "";
            }
        }
    }

    //Variables formulario estructura \\
    const numpla = document.getElementById('numpla'), clvstr = document.getElementById('clvstr'),
        depaid = document.getElementById('depaid'), puesid = document.getElementById('puesid'),
        emprep = document.getElementById('emprep'), report = document.getElementById('report'),
        depart = document.getElementById('depart'), pueusu = document.getElementById('pueusu'),
        tippag = document.getElementById('tippag'), banuse = document.getElementById('banuse'),
        cunuse = document.getElementById('cunuse'), clvbank = document.getElementById('clvbank');

    const vardataestructure = [numpla, depaid, puesid, emprep, report, depart, pueusu, tippag, banuse, cunuse, clvbank];
    fclearfieldsvar4 = () => {
        for (let i = 0; i < vardataestructure.length; i++) {
            if (vardataestructure[i].getAttribute('tp-select') != null) {
                vardataestructure[i].value = "0";
            } else {
                vardataestructure[i].value = "";
            }
        }
    }

    fchecklocalstotab = () => {
        if (localStorage.getItem('tabSelected') === null) {
            localStorage.setItem('tabSelected', 'none');
        }
        if (localStorage.getItem('modedit') != null) {
            btnsaveedit.classList.remove('d-none');
        } else {
            btnsaveedit.classList.add('d-none')
        }
    }

    fchecklocalstotab();

    fviewlaerttabcontinue = (paramid) => {
        const divAlert = `
            <div class="alert alert-info text-center" role="alert">
                <b> <i class="fas fa-edit mr-2"></i> Continua en el apartado en donde te quedaste!</b>
            </div>
        `;
        document.getElementById('div-most-alert-' + String(paramid)).classList.add('mb-4');
        document.getElementById('div-most-alert-' + String(paramid)).innerHTML = divAlert;
    }

    // Funciones para cadenas \\

    fuppercase = (string) => {
        return string.charAt(0).toUpperCase() + string.slice(1);
    }

    String.prototype.capitalize = function () {
        return this.replace(/(^|\s)([a-z])/g, function (m, p1, p2) { return p1 + p2.toUpperCase(); });
    };

    // Funcion que valida que un correo este bien
    mailus.addEventListener('keyup', () => {
        const emailvalidate = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;
        if (mailus.value.length > 0) {
            if (!emailvalidate.test(mailus.value)) {
                mailus.classList.add('is-invalid');
                btnSaveDataGen.disabled = true;
            } else {
                mailus.classList.remove('is-invalid');
                btnSaveDataGen.disabled = false;
            }
        }
    });

    // Selecciona la tab en donde el ususario se quedo editando \\

    fselectlocalstotab = () => {
        setTimeout(() => {
            const localStoTab = localStorage.getItem('tabSelected');
            if (localStoTab === "none") {
                navImssTab.classList.add('disabled');
                navDataNomTab.classList.add('disabled');
                navEstructureTab.classList.add('disabled');
                $("#nav-datagen-tab").click();
                console.log("tab-datagen");
            } else if (localStoTab === "imss") {
                navDataNomTab.classList.add('disabled');
                navEstructureTab.classList.add('disabled');
                fviewlaerttabcontinue('data-imss');
                $("#nav-imss-tab").click();
            } else if (localStoTab === "datanom") {
                navEstructureTab.classList.add('disabled'); +
                    fviewlaerttabcontinue('data-nomina');
                $("#nav-datanom-tab").click();
            } else if (localStoTab === "dataestructure") {
                fviewlaerttabcontinue('data-estructure');
                $("#nav-estructure-tab").click();
            }
        }, 100);
    }

    fselectlocalstotab();

    floaddatatabs = () => {
        if (JSON.parse(localStorage.getItem('objectTabDataGen')) != null) {
            const getDataTabDataGen = JSON.parse(localStorage.getItem('objectTabDataGen'));
            for (i in getDataTabDataGen) {
                if (getDataTabDataGen[i].key === "general") {
                    clvemp.value = getDataTabDataGen[i].data.clvemp;
                    name.value = getDataTabDataGen[i].data.name; apep.value = getDataTabDataGen[i].data.apep;
                    apem.value = getDataTabDataGen[i].data.apem; fnaci.value = getDataTabDataGen[i].data.fnaci;
                    lnaci.value = getDataTabDataGen[i].data.lnaci;
                    title.value = getDataTabDataGen[i].data.title;
                    sex.value = getDataTabDataGen[i].data.sex; nacion.value = getDataTabDataGen[i].data.nacion;
                    estciv.value = getDataTabDataGen[i].data.estciv; codpost.value = getDataTabDataGen[i].data.codpost;
                    state.value = getDataTabDataGen[i].data.state; city.value = getDataTabDataGen[i].data.city;
                    street.value = getDataTabDataGen[i].data.street;
                    numberst.value = getDataTabDataGen[i].data.numberst;
                    telfij.value = getDataTabDataGen[i].data.telfij; telmov.value = getDataTabDataGen[i].data.telmov;
                    mailus.value = getDataTabDataGen[i].data.mailus;
                }
            }
            document.getElementById('icouser').classList.remove('d-none');
            if (localStorage.getItem('modedit') != null) {
                document.getElementById('nameuser').textContent = "Editando al Empleado: " + name.value + " " + apep.value + " " + apem.value + ".";
            } else {
                document.getElementById('nameuser').textContent = "Empleado: " + name.value + " " + apep.value + " " + apem.value + ".";
            }
        }
        if (JSON.parse(localStorage.getItem('objectDataTabImss')) != null) {
            const getDataTabImss = JSON.parse(localStorage.getItem('objectDataTabImss'));
            for (i in getDataTabImss) {
                if (getDataTabImss[i].key === "imss") {
                    clvimss.value = getDataTabImss[i].data.clvimss;
                    imss.value = getDataTabImss[i].data.imss;
                    rfc.value = getDataTabImss[i].data.rfc;
                    curp.value = getDataTabImss[i].data.curp; nivest.value = getDataTabImss[i].data.nivest;
                    nivsoc.value = getDataTabImss[i].data.nivsoc;
                }
            }
        }
        if (JSON.parse(localStorage.getItem('objectDataTabNom')) != null) {
            const getDataTabNom = JSON.parse(localStorage.getItem('objectDataTabNom'));
            for (i in getDataTabNom) {
                if (getDataTabNom[i].key === "nom") {
                    clvnom.value = getDataTabNom[i].data.clvnom;
                    numnom.value = getDataTabNom[i].data.numnom; salmen.value = getDataTabNom[i].data.salmen;
                    pagret.value = getDataTabNom[i].data.pagret;
                    tipemp.value = getDataTabNom[i].data.tipemp; tipmon.value = getDataTabNom[i].data.tipmon;
                    nivemp.value = getDataTabNom[i].data.nivemp; tipjor.value = getDataTabNom[i].data.tipjor;
                    tipcon.value = getDataTabNom[i].data.tipcon; fecing.value = getDataTabNom[i].data.fecing;
                    fecant.value = getDataTabNom[i].data.fecant; vencon.value = getDataTabNom[i].data.vencon;
                    estats.value = getDataTabNom[i].data.estats;
                }
            }
        }
        if (JSON.parse(localStorage.getItem('objectDataTabEstructure')) != null) {
            const getDataEstructure = JSON.parse(localStorage.getItem('objectDataTabEstructure'));
            for (i in getDataEstructure) {
                if (getDataEstructure[i].key === "estructure") {
                    clvstr.value = getDataEstructure[i].data.clvstr;
                    numpla.value = getDataEstructure[i].data.numpla;
                    emprep.value = getDataEstructure[i].data.emprep; report.value = getDataEstructure[i].data.report;
                    depaid.value = getDataEstructure[i].data.depaid; depart.value = getDataEstructure[i].data.depart;
                    puesid.value = getDataEstructure[i].data.puesid; pueusu.value = getDataEstructure[i].data.pueusu;
                    tippag.value = getDataEstructure[i].data.tippag; banuse.value = getDataEstructure[i].data.banuse;
                    cunuse.value = getDataEstructure[i].data.cunuse;
                    clvbank.textContent = getDataEstructure[i].data.clvbank;
                }
            }
        }
    }

    floaddatatabs();

    fclearlocsto = () => {
        localStorage.removeItem('tabSelected');
        localStorage.removeItem('objectTabDataGen');
        localStorage.removeItem('objectDataTabImss');
        localStorage.removeItem('objectDataTabNom');
        localStorage.removeItem('objectDataTabEstructure');
        localStorage.removeItem('modedit');
        fchecklocalstotab();
        fselectlocalstotab();
        floaddatatabs();
        fclearfieldsvar1();
        fclearfieldsvar2();
        fclearfieldsvar3();
        fclearfieldsvar4();
        document.getElementById('icouser').classList.add('d-none');
        document.getElementById('nameuser').textContent = '';
    }

    btnClearLocSto.addEventListener('click', fclearlocsto);

    let validate = 0;

    toastr.options = {
        "closeButton": false, "debug": false,
        "newestOnTop": false, "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "1000", "hideDuration": "1000",
        "timeOut": "5000", "extendedTimeOut": "1000",
        "showEasing": "swing", "hideEasing": "linear",
        "showMethod": "fadeIn", "hideMethod": "fadeOut"
    }


    gotoppage = (element, idtab, texttoastr) => {
        element.classList.remove('disabled');
        $('body, html').animate({ scrollTop: '0px' }, 1000);
        setTimeout(() => { $(" " + idtab + " ").click(); }, 2000);
        Command: toastr["info"](String(texttoastr));
    }

    String.prototype.reverse = function () {
        var x = this.length;
        var cadena = "";
        while (x >= 0) {
            cadena = cadena + this.charAt(x);
            x--;
        }
        return cadena;
    };

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

    btnSaveDataGen.addEventListener('click', () => {
        const arrInput = [name, apep, sex, estciv, fnaci, lnaci, title, nacion, state];
        let validate = 0;
        for (let a = 0; a < arrInput.length; a++) {
            if (arrInput[a].hasAttribute('tp-select')) {
                if (arrInput[a].value == '0') {
                    const attrselect = arrInput[a].getAttribute('tp-select');
                    fshowtypealert('Atencion', 'Selecciona una opción de ' + String(attrselect), 'warning', arrInput[a], 0);
                    validate = 1;
                    break;
                }
                if (arrInput[a].id == 'state' && arrInput[a].value != '0') {
                    arrInput.push(codpost);
                }
            } else {
                if (arrInput[a].hasAttribute('tp-date')) {
                    const attrdate = arrInput[a].getAttribute('tp-date');
                    if (arrInput[a].value != "" && attrdate == 'less') {
                        const ds = new Date();
                        const fechAct = ds.getFullYear() + "-" + (ds.getMonth() + 1) + "-" + ds.getDate();
                        if (arrInput[a].value > fechAct) {
                            fshowtypealert('Atencion', 'La fecha de nacimiento ' + arrInput[a].value + ' es incorrecta, no debe de ser mayor a la fecha actual', 'warning', arrInput[a], 1);
                            validate = 1;
                            break;
                        }
                    }
                    else {
                        fshowtypealert('Atencion', 'Completa el campo ' + String(arrInput[a].placeholder), 'warning', arrInput[a], 0);
                        validate = 1;
                        break;
                    }
                } else {
                    if (arrInput[a].value == '') {
                        fshowtypealert('Atencion', 'Completa el campo ' + String(arrInput[a].placeholder), 'warning', arrInput[a], 0);
                        validate = 1;
                        break;
                    }
                }
                if (arrInput[a].id == 'codpost' && arrInput[a].value.length < 5 || arrInput[a].id == 'codpost' && arrInput[a].value.length > 5) {
                    fshowtypealert('Atencion', 'La longitud del codigo postal debe de ser de 5 digitos', 'warning', arrInput[a], 1);
                    validate = 1;
                    break;
                }
                if (arrInput[a].id == 'codpost' && arrInput[a].value.length == 5) {
                    arrInput.push(colony, street, telmov, mailus);
                }
                if (arrInput[a].id == 'mailus' && arrInput[a].value != "") {
                    const emailvalidate = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;
                    if (!emailvalidate.test(arrInput[a].value)) {
                        fshowtypealert('Atencion', 'El correo ingresado ' + arrInput[a].value + ' no contiene un formato valido', 'warning', arrInput[a], 1);
                        validate = 1;
                        break;
                    }
                }
            }
        }
        if (validate == 0) {
            gotoppage(navImssTab, '#nav-imss-tab', "Ahora completa los datos del apartado Imss!");
            const dataLocStoGen = {
                key: 'general', data: {
                    clvemp: clvemp.value,
                    name: name.value, apep: apep.value,
                    apem: apem.value, fnaci: fnaci.value,
                    lnaci: lnaci.value, title: title.value,
                    sex: sex.value, nacion: nacion.value,
                    estciv: estciv.value, codpost: codpost.value,
                    state: state.value, city: city.value,
                    colony: colony.value, street: street.value,
                    numberst: numberst.value, telfij: telfij.value,
                    telmov: telmov.value, mailus: mailus.value
                }
            };
            document.getElementById('icouser').classList.remove('d-none');
            document.getElementById('nameuser').textContent = "Empleado: " + name.value + " " + apep.value + " " + apem.value + ".";
            objectDataTabDataGen.datagen = dataLocStoGen;
            localStorage.setItem('objectTabDataGen', JSON.stringify(objectDataTabDataGen));
            localStorage.setItem('tabSelected', 'imss');
        }
    });

    btnSaveDataImss.addEventListener('click', () => {
        const arrInput = [imss, rfc, curp, nivest, nivsoc];
        let validate = 0;
        for (let i = 0; i < arrInput.length; i++) {
            if (arrInput[i].hasAttribute("tp-select")) {
                if (arrInput[i].value == "0") {
                    const attrselect = arrInput[i].getAttribute('tp-select');
                    fshowtypealert('Atención', 'Selecciona una opción de ' + String(attrselect), 'warning', arrInput[i], 0);
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
            gotoppage(navDataNomTab, '#nav-datanom-tab', "Ahora completa los datos del apartado Datos de nomina!");
            const dataLocSto = {
                key: 'imss', data: {
                    clvimss: clvimss.value,
                    imss: imss.value,
                    rfc: rfc.value,
                    curp: curp.value,
                    nivest: nivest.value,
                    nivsoc: nivsoc.value,
                }
            };
            objectDataTabImss.dataimss = dataLocSto;
            localStorage.setItem('objectDataTabImss', JSON.stringify(objectDataTabImss));
            localStorage.setItem('tabSelected', 'datanom');
        }
    });

    btnSaveDataNomina.addEventListener('click', () => {
        const arrInput = [numnom, salmen, pagret, tipemp, nivemp, tipjor, tipcon, fecing, estats];
        let validate = 0;
        for (let t = 0; t < arrInput.length; t++) {
            if (arrInput[t].hasAttribute("tp-select")) {
                if (arrInput[t].value == "0") {
                    const attrselect = arrInput[t].getAttribute('tp-select');
                    fshowtypealert('Atención', 'Selecciona una opción de ' + String(attrselect), 'warning', arrInput[t], 0);
                    validate = 1;
                    break;
                }
                if (arrInput[t].id == "tipemp" && arrInput[t].value == 76) {
                    arrInput.push(vencon);
                }
            } else {
                if (arrInput[t].hasAttribute("tp-date")) {
                    const attrdate = arrInput[t].getAttribute("tp-date");
                    const d = new Date();
                    const fechAct = d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate();
                    if (arrInput[t].value != "" && attrdate == "less") {
                        if (arrInput[t].value > fechAct) {
                            fshowtypealert('Atención', 'La ' + arrInput[t].placeholder + ' seleccionada ' + arrInput[t].value + ' no puede ser mayor a la fecha actual', 'warning', arrInput[t], 1);
                            validate = 1;
                            break;
                        }
                    } else if (arrInput[t].value != "" && attrdate == "higher") {
                        if (arrInput[t].value < fechAct) {
                            fshowtypealert('Atención', 'La fecha de ' + arrInput[t].placeholder + ' seleccionada ' + arrInput[t].value + ' no puede ser menor a la fecha actual', 'warning', arrInput[t], 1);
                            validate = 1;
                            break;
                        }
                    } else {
                        fshowtypealert('Atención', 'Completa el campo ' + String(arrInput[t].placeholder), 'warning', arrInput[t], 0);
                        validate = 1;
                        break;
                    }
                } else {
                    if (arrInput[t].value == "") {
                        fshowtypealert('Atención', 'Completa el campo ' + arrInput[t].placeholder, 'warning', arrInput[t], 0);
                        validate = 1;
                        break;
                    }
                }
            }
        }
        if (validate == 0) {
            gotoppage(navEstructureTab, '#nav-estructure-tab', "Ahora completa los datos del apartado Estructura!");
            const dataLocSto = {
                key: 'nom', data: {
                    clvnom: clvnom.value,
                    numnom: numnom.value, salmen: salmen.value,
                    pagret: pagret.value,
                    tipemp: tipemp.value, tipmon: tipmon.value,
                    nivemp: nivemp.value, tipjor: tipjor.value,
                    tipcon: tipcon.value, fecing: fecing.value,
                    fecant: fecant.value, vencon: vencon.value,
                    estats: estats.value,
                }
            };
            objectDataTabNom.datanom = dataLocSto;
            localStorage.setItem('objectDataTabNom', JSON.stringify(objectDataTabNom));
            localStorage.setItem('tabSelected', 'dataestructure');
        }
    });

    btnSaveDataEstructure.addEventListener('click', () => {
        const arrInput = [numpla, depart, pueusu, emprep, report, tippag];
        let validate = 0;
        for (let i = 0; i < arrInput.length; i++) {
            if (arrInput[i].hasAttribute('tp-select')) {
                if (arrInput[i].value == "0") {
                    const attrselect = arrInput[i].getAttribute('tp-select');
                    fshowtypealert('Atención', 'Selecciona una opción para ' + String(attrselect), 'warning', arrInput[i], 0);
                    validate = 1;
                    break;
                }
                if (arrInput[i].value == "Cuenta cheques" || arrInput[i].value == "Cuenta clabe") {
                    arrInput.push(banuse, cunuse);
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
            gotoppage(navEstructureTab, '#nav-estructure-tab', "Los datos esperan para ser guardados");
            const dataLocSto = {
                key: 'estructure', data: {
                    clvstr: clvstr.value,
                    numpla: numpla.value,
                    depaid: depaid.value,
                    depart: depart.value,
                    puesid: puesid.value,
                    pueusu: pueusu.value,
                    emprep: emprep.value,
                    report: report.value,
                    tippag: tippag.value,
                    banuse: banuse.value,
                    cunuse: cunuse.value,
                    clvbank: clvbank.textContent
                }
            };
            objectDataTabEstructure.dataestructure = dataLocSto;
            localStorage.setItem('objectDataTabEstructure', JSON.stringify(objectDataTabEstructure));
            localStorage.setItem('tabSelected', 'dataestructure');
        }
    });


});