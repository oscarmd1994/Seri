﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Payroll.Models.Beans;
using Payroll.Models.Daos;

namespace Payroll.Controllers
{
    public class SaveDataGeneralController : Controller
    {
        // GET: SaveDataGeneral
        public ActionResult Index()
        {
            return View();
        }

        //Guarda los datos de puesto
        [HttpPost]
        public JsonResult SaveDataPuestos(string regcodpuesto, string regpuesto, string regdescpuesto, int proffamily, int clasifpuesto, int regcolect, int nivjerarpuesto, int perfmanager, int tabpuesto)
        {
            PuestosBean addPuestoBean = new PuestosBean();
            SavePuestosDao savePuestoDao = new SavePuestosDao();
            // Reemplazar por la sesion de la empresa
            int keyemp = 5;
            int usuario = Convert.ToInt32(Session["iIdUsuario"].ToString());
            addPuestoBean = savePuestoDao.sp_Puestos_Insert_Puestos(regcodpuesto, regpuesto, regdescpuesto, proffamily, clasifpuesto, regcolect, nivjerarpuesto, perfmanager, tabpuesto, usuario, keyemp);
            return Json(addPuestoBean);
        }

        //Guarda los datos del departamento
        [HttpPost]
        public JsonResult SaveDepartament(string regdepart, string descdepart, string nivestuc, string nivsuptxt, int edific, string piso, string ubicac, int centrcost, int reportaa, string dgatxt, string dirgentxt, string direjetxt, string diraretxt, int dirgen, int direje, int dirare)
        {
            DepartamentosBean addDepartamentoBean = new DepartamentosBean();
            SaveDepartamentosDao saveDepartamentoDao = new SaveDepartamentosDao();
            int usuario = Convert.ToInt32(Session["iIdUsuario"].ToString());
            // Reemplazar por la sesion de la empresa
            int keyemp  = 5;
            addDepartamentoBean = saveDepartamentoDao.sp_Departamentos_Insert_Departamento(keyemp, regdepart, descdepart, nivestuc, nivsuptxt, edific, piso, ubicac, centrcost, reportaa, dgatxt, dirgentxt, direjetxt, diraretxt, dirgen, direje, dirare, usuario);
            string result = "error";
            if (addDepartamentoBean.sMensaje == "success") {
                result = addDepartamentoBean.sMensaje;
            }
            var data = new { result = result };
            return Json(addDepartamentoBean);
        }

        [HttpPost]
        public JsonResult SavePositions(string codposic, int depaid, int puesid, int regpatcla, int localityr, int emprepreg, int reportempr) 
        {
            DatosPosicionesBean addPosicionBean = new DatosPosicionesBean();
            DatosPosicionesDao savePosicionDao = new DatosPosicionesDao();
            int usuario = Convert.ToInt32(Session["iIdUsuario"].ToString());
            // Reemplazar por la sesion de la empresa
            int keyemp = 5;
            addPosicionBean = savePosicionDao.sp_Posiciones_Insert_Posicion(codposic, depaid, puesid, regpatcla, localityr, emprepreg, reportempr, usuario, keyemp);
            var data = new { result = addPosicionBean.sMensaje };
            return Json(data);
            
        }

        //Guarda los datos generales del empleado
        [HttpPost]
        public JsonResult DataGeneral(string name, string apepat, string apemat, int sex, int estciv, string fnaci, string lnaci, int title, string nacion, int state, string codpost, string city, string colony, string street, string numberst, string telfij, string telmov, string email, string tipsan, string fecmat)
        {
            EmpleadosBean addEmpleadoBean = new EmpleadosBean();
            EmpleadosDao empleadoDao = new EmpleadosDao();
            int usuario = Convert.ToInt32(Session["iIdUsuario"].ToString());
            // Reemplazar por la sesion de la empresa
            int empresa = 5;
            addEmpleadoBean = empleadoDao.sp_Empleados_Insert_Empleado(name, apepat, apemat, sex, estciv, fnaci, lnaci, title, nacion, state, codpost, city, colony, street, numberst, telfij, telmov, email, usuario, empresa, tipsan, fecmat);
            var data = new { result = addEmpleadoBean.sMensaje };
            return Json(addEmpleadoBean);
        }

        //Guarda los datos del imss del empleado
        [HttpPost]
        public JsonResult DataImss(string fecefe, string regimss, string rfc, string curp, int nivest, int nivsoc, string empleado, string apepat, string apemat, string fechanaci)
        {
            ImssBean addImssBean = new ImssBean();
            ImssDao imssDao = new ImssDao();
            int usuario = Convert.ToInt32(Session["iIdUsuario"].ToString());
            //Sesion de la empresa
            int keyemp = 5;
            addImssBean = imssDao.sp_Imss_Insert_Imss(fecefe, regimss, rfc, curp, nivest, nivsoc, usuario, empleado, apepat, apemat, fechanaci, keyemp);
            var data = new { result = addImssBean.sMensaje };
            return Json(data);
        }

        //Guarda los datos de la nomina del empleado
        [HttpPost]
        public JsonResult DataNomina(string fecefecnom, double salmen, int tipemp, int nivemp, int tipjor, int tipcon, string fecing, string fecant, string vencon, string estats, string empleado, string apepat, string apemat, string fechanaci, int tipper, int tipcontra, int tippag, int banuse, string cunuse, int position, int clvemp)
        {
            DatosNominaBean addDatoNomina = new DatosNominaBean();
            DatosNominaDao datoNominaDao = new DatosNominaDao();
            //Reemplazar por la session de la empresa
            int keyemp = 5;
            int usuario = Convert.ToInt32(Session["iIdUsuario"].ToString());
            addDatoNomina = datoNominaDao.sp_DatosNomina_Insert_DatoNomina(fecefecnom, salmen, tipemp, nivemp, tipjor, tipcon, fecing, fecant, vencon, estats, usuario, empleado, apepat, apemat, fechanaci, keyemp, tipper, tipcontra, tippag, banuse, cunuse, position, clvemp);
            var data = new { result = addDatoNomina.sMensaje };
            return Json(data);
        }

        //Guarda los datos de estructura del empleado
        [HttpPost]
        public JsonResult DataEstructura(int clvstr, string fechefectpos, string fechinipos, string empleado, string apepat, string apemat, string fechanaci)
        {
            DatosPosicionesBean addPosicionBean = new DatosPosicionesBean();
            DatosPosicionesDao datoPosicionDao = new DatosPosicionesDao();
            int usuario = Convert.ToInt32(Session["iIdUsuario"].ToString());
            addPosicionBean = datoPosicionDao.sp_PosicionesAsig_Insert_PosicionesAsig(clvstr, fechefectpos, fechinipos, empleado, apepat, apemat, fechanaci, usuario);
            var data = new { result = addPosicionBean.sMensaje };
            return Json(data);
        }

        // Guarda los datos de la estructura al editar el empleado
        [HttpPost]
        public JsonResult DataEstructuraEdit(int clvstr, string fechefectpos, string fechinipos, int clvemp, int clvposasig, int clvnom)
        {
            DatosPosicionesBean addPosicionBean = new DatosPosicionesBean();
            DatosPosicionesDao datoPosicionDao = new DatosPosicionesDao();
            int usuario = Convert.ToInt32(Session["iIdUsuario"].ToString());
            addPosicionBean = datoPosicionDao.sp_PosicionesAsig_Insert_PosicionesAsigEdit(clvstr, fechefectpos, fechinipos, clvemp, clvposasig, clvnom, usuario);
            var data = new { result = addPosicionBean.sMensaje };
            return Json(data);
        }

        //Guarda los datos de las regionales
        [HttpPost]
        public JsonResult SaveRegionales(string descregion, string claregion)
        {
            RegionalesBean addRegionBean = new RegionalesBean();
            RegionesDao regionDao = new RegionesDao();
            int usuario = Convert.ToInt32(Session["iIdUsuario"].ToString());
            // Reemplazar por la session de la empresa
            int keyemp = 5;
            addRegionBean = regionDao.sp_Regionales_Insert_Regionales(descregion, claregion, usuario, keyemp);
            var data = new { result = addRegionBean.sMensaje };
            return Json(data);
        }

        //Guarda los datos de las sucursales
        [HttpPost]
        public JsonResult SaveSucursales(string descsucursal, string clasucursal)
        {
            SucursalesBean addSucursalBean = new SucursalesBean();
            SucursalesDao sucursalDao = new SucursalesDao();
            int usuario = Convert.ToInt32(Session["iIdUsuario"].ToString());
            addSucursalBean = sucursalDao.sp_Sucursales_Insert_Sucursales(descsucursal, clasucursal, usuario);
            var data = new { result = addSucursalBean.sMensaje };
            return Json(data);
        }
    }
}