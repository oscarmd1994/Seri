﻿using Payroll.Models.Beans;
using Payroll.Models.Daos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace Payroll.Controllers
{
    public class EmpresasController : Controller
    {
        // GET: Empresas
        public JsonResult LoadSEmp()
        {
            List<PruebaEmpresaBean> empresas;
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            empresas = Dao.sp_Retrieve_PruevaEmpresas();

            return Json(empresas);
        }
        [HttpPost]
        public JsonResult DefineEmpresa(int IdEmpresa, string NombreEmpresa)
        {
            @Session["IdEmpresa"] = IdEmpresa;
            @Session["sEmpresa"] = NombreEmpresa;
            List<string> Periodo;
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            Periodo = Dao.sp_CInicio_Fechas_Periodo_Verify_id(IdEmpresa);
            return Json(Periodo);
        }
        [HttpPost]
        public void DefinePeriodoActual(int IdPeriodo)
        {
            @Session["Periodo_id"] = IdPeriodo;
        }

        public PartialViewResult Datos_Generales()
        {
            if (Session["iIdUsuario"] == null)
            {
                return PartialView(Redirect("../Home/Index"));
            }
            else
            {
                return PartialView();
            }
        }
        public JsonResult New_ClaveEmpresa()
        {
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            int ClaveEmpresa = Dao.sp_Retrieve_ClaveEmpresa();
            return Json(ClaveEmpresa);
        }
        [HttpPost]
        public JsonResult LoadEmpresas()
        {
            List<PruebaEmpresaBean> empresas;
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            empresas = Dao.sp_Retrieve_NombreEmpresas();
            string btnsEmpresas = "<div class='row'>"; 
            foreach (var item in empresas)
            {
                btnsEmpresas += "" +
                    "<div class='col-12 col-md-4 col-lg-3 col-sm-6'>" +
                        "<div class='input-group mb-3'>" +
                            "<div class='input-group-prepend'>" +
                                "<div class='input-group-text text-dark bg-white'><i class='fas fa-city'></i></div>" +
                            "</div>" +
                            "<div class='form-control btn btn-menu btnsEmpresas' onclick='btnsEmpresas(\"" + item.IdEmpresa + "\",\"" + item.NombreEmpresa + "\")'>" +

                                "<small class='badge p-0 m-0 text-wrap'>" + item.NombreEmpresa + "&nbsp;&nbsp;&nbsp; <small class='badge badge-pill badge-light text-center aling-middle'> " + item.IdEmpresa + " </small></small>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                    "";
            }
            btnsEmpresas += "</div>";
            return Json(btnsEmpresas);
        }
        [HttpPost]
        public JsonResult SearchEmpresa()
        {
            int IdEmpresa;
            List<PruebaEmpresaBean> empresas = new List<PruebaEmpresaBean>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            empresas = Dao.sp_Retrieve_NombreEmpresa(IdEmpresa = int.Parse(Session["IdEmpresa"].ToString()));
            return Json(empresas);
        }
        [HttpPost]
        public JsonResult LoadDatosEmpresa()
        {
            List<string> empresas = new List<string>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            int IdEmpresa = int.Parse(Session["IdEmpresa"].ToString());
            empresas = Dao.sp_CEmpresas_Retrieve_EmpresaD(IdEmpresa);
            return Json(empresas);
        }
        [HttpPost]
        public JsonResult LoadEmpresa()
        {
            List<string> empresas = new List<string>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            int IdEmpresa = int.Parse(Session["IdEmpresa"].ToString());
            empresas = Dao.sp_CEmpresas_Retrieve_Empresa(IdEmpresa);
            return Json(empresas);
        }
        [HttpPost]
        public JsonResult Insert_Empresa_FirstStep(string inNombre_empresa, string inNomCorto_empresa, string inRfc_empresa, string inGiro_empresa,int inRegimenFiscal_Empresa, int inCodigo_postal, int inEstado_empresa, int inMunicipio_empresa, string inCiudad_empresa, int inColonia_empresa, string inDelegacion_Empresa, string inCalle_Empresa, string inAfiliacionIMSS,string inNombre_Afiliacion, string inRiesgoTrabajo, int inClase )
        {
            List<string> empresas = new List<string>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            empresas = Dao.sp_Insert_FirstStep_Empresas(inNombre_empresa, inNomCorto_empresa, inRfc_empresa, inGiro_empresa, inRegimenFiscal_Empresa, inCodigo_postal, inEstado_empresa, inMunicipio_empresa, inCiudad_empresa, inDelegacion_Empresa, inColonia_empresa, inCalle_Empresa, inAfiliacionIMSS, inNombre_Afiliacion, inRiesgoTrabajo, int.Parse(Session["iIdUsuario"].ToString()), inClase);
            return Json(empresas);
        }
        public PartialViewResult Registros_Patronales()
        {
            return PartialView();
        }
        public PartialViewResult Localidades()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult LoadRegistrosPatronales() {
            List<RegistroPatronalBean> RP = new List<RegistroPatronalBean>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            RP = Dao.sp_Registro_Patronal_Retrieve_Registros_Patronales(int.Parse(Session["IdEmpresa"].ToString()));
            var data = new { data = RP };
            return Json(data);
        }
        public JsonResult LoadRegPat()
        {
            List<RegistroPatronalBean> RP = new List<RegistroPatronalBean>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            RP = Dao.sp_Registro_Patronal_Retrieve_Registros_Patronales(int.Parse(Session["IdEmpresa"].ToString()));
            return Json(RP);
        }public JsonResult LoadRegistroPatronal( int IdRegPat)
        {
            List<RegistroPatronalBean> RP = new List<RegistroPatronalBean>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            int Empresa_id = int.Parse(Session["IdEmpresa"].ToString());
            RP = Dao.sp_Registro_Patronal_Retrieve_Registro_Patronal(Empresa_id, IdRegPat);
            return Json(RP);
        }
        [HttpPost]
        public JsonResult LoadLocalidades()
        {
            List<LocalidadesBean> RP = new List<LocalidadesBean>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            RP = Dao.sp_TLocalicades_Retrieve_Localidades(int.Parse(Session["IdEmpresa"].ToString()));
            var data = new { data = RP };
            return Json(data);
        }
        public JsonResult LoadClasesRP()
        {
            List<CClases_RegPatBean> RP = new List<CClases_RegPatBean>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            RP = Dao.sp_CClases_RegPat();
            return Json(RP);
        }
        public JsonResult LoadRegimenesFiscales()
        {
            List<RegimenFiscalBean> RP = new List<RegimenFiscalBean>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            RP = Dao.sp_CRegimen_Fiscal_Retrieve();
            return Json(RP);
        }
        [HttpPost]
        public JsonResult Insert_Registro_Patronal( int Empresa_id , string Afiliacion_IMSS, string Nombre_Afiliacion, string Riesgo_Trabajo, int ClasesRegPat, int Status  )
        {
            List<string> RP = new List<string>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            RP = Dao.sp_Registro_Patronal_Insert_Registros_Patronales( Empresa_id, Afiliacion_IMSS, Nombre_Afiliacion, Riesgo_Trabajo, ClasesRegPat, Status );
            var data = new { data = RP };
            return Json(data);
        }
        public JsonResult LoadRegionalesEmp()
        {
            List<RegionalesBean> RP = new List<RegionalesBean>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            RP = Dao.sp_CRegionales_Retrieve_Regionales_xEmpresa(int.Parse(Session["IdEmpresa"].ToString()));
            return Json(RP);
        }
        public JsonResult LoadSucursales()
        {
            List<SucursalesBean> RP = new List<SucursalesBean>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            RP = Dao.sp_CSucursales_Retrieve_Sucursales();
            return Json(RP);
        }
        public JsonResult LoadZonaEconomica()
        {
            List<ZonaEconomicaBean> RP = new List<ZonaEconomicaBean>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            RP = Dao.sp_CZonaEconomica_Retrieve_ZonaEconomica();
            return Json(RP);
        }
        [HttpPost]
        public JsonResult Insert_Localidad( string Descripcion,string TasaIva,int Afiliacion_IMSS, int Regional_id,int ZonaEconomica_id,int Sucursal_id, int Estado_id)
        {
            List<string> RP = new List<string>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            RP = Dao.sp_TLocalidades_Insert_Localidades( int.Parse(Session["IdEmpresa"].ToString()), Descripcion, TasaIva, Afiliacion_IMSS, Regional_id, ZonaEconomica_id, Sucursal_id, Estado_id);
            var data = new { data = RP };
            return Json(data);
        }
    }
}