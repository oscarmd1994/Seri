using Payroll.Models.Beans;
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
        public void DefineEmpresas(int IdEmpresa, string NombreEmpresa)
        {
            @Session["IdEmpresa"] = IdEmpresa;
            @Session["sEmpresa"] = NombreEmpresa;
        }
        public PartialViewResult Datos_Generales()
        {

            return PartialView();
        }
        public JsonResult New_ClaveEmpresa()
        {
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            int ClaveEmpresa = Dao.sp_Retrieve_ClaveEmpresa();
            return Json(ClaveEmpresa);
        }
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

                                "<small class=''>" + item.NombreEmpresa + "</small>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                    "";
            }
            btnsEmpresas += "</div>";
            return Json(btnsEmpresas);
        }
        [HttpPost]
        public JsonResult SearchEmpresas(int txt)
        {
            List<PruebaEmpresaBean> empresas = new List<PruebaEmpresaBean>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            empresas = Dao.sp_Retrieve_NombreEmpresa(txt);
            return Json(empresas);
        }

        [HttpPost]
        public JsonResult Insert_Empresa_FirstStep(
                        string inNombre_empresa,
                        string inNomCorto_empresa,
                        string inRfc_empresa,
                        string inGiro_empresa,
                        int inCodigo_postal,
                        int inEstado_empresa,
                        int inMunicipio_empresa,
                        string inCiudad_empresa,
                        int inColonia_empresa,
                        string inDelegacion_Empresa,
                        string inCalle_Empresa,
                        int inUltimo_nomina,
                        int inInicio_nomina,
                        int inFinal_nomina,
                        string inPeriodo_pago,
                        string inPago,
                        string inAfiliacionIMSS,
                        string inRiesgoTrabajo

            )
        {
            List<string> empresas = new List<string>();
            PruebaEmpresaDao Dao = new PruebaEmpresaDao();
            empresas = Dao.sp_Insert_FirstStep_Empresas(inNombre_empresa, inNomCorto_empresa, inRfc_empresa, inGiro_empresa, inCodigo_postal, inEstado_empresa, inMunicipio_empresa, inCiudad_empresa, inDelegacion_Empresa, inColonia_empresa, inCalle_Empresa, inUltimo_nomina, inInicio_nomina, inFinal_nomina, inPeriodo_pago, inPago, inAfiliacionIMSS, inRiesgoTrabajo, int.Parse(Session["iIdUsuario"].ToString()));
            return Json(empresas);
        }

    }
}