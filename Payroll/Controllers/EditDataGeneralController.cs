using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Payroll.Models.Beans;
using Payroll.Models.Daos;

namespace Payroll.Controllers
{
    public class EditDataGeneralController : Controller
    {
        // GET: EditDataGeneral
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult EditDepartament(string edidepart, string edidescdepart, int edireportaa, int edicentrcost, int ediedific, int edinivestuc, string ediubicac, string ediplaza, string edititul, string edisucurbanc, string edicateg, int clvdepart)
        {
            DepartamentosBean editDepartamentoBean = new DepartamentosBean();
            EditDepartamentosDao editDepartamentoDao = new EditDepartamentosDao();
            editDepartamentoBean = editDepartamentoDao.sp_Departamentos_Update_Departamento(edidepart, edidescdepart, edireportaa, edicentrcost, ediedific, edinivestuc, ediubicac, ediplaza, edititul, edisucurbanc, edicateg, clvdepart);
            var data = new { result = editDepartamentoBean.sMensaje };
            return Json(data);
        }

        [HttpPost]
        public JsonResult EditPuesto(string edipuesto, string edidescpuesto, int ediproffamily, int edietiqcont, int edicolect, string edigraddom, string editarjpres, int ediclasifpuesto, int edinivjerarpuesto, int ediperfmanager, int editabpuesto, string edisindcat, int ediclvsat, int clvpuesto)
        {
            PuestosBean editPuestoBean = new PuestosBean();
            EditPuestosDao editPuestoDao = new EditPuestosDao();
            editPuestoBean = editPuestoDao.sp_Puestos_Update_Puesto(edipuesto, edidescpuesto, ediproffamily, edietiqcont, edicolect, edigraddom, editarjpres, ediclasifpuesto, edinivjerarpuesto, ediperfmanager, editabpuesto, edisindcat, ediclvsat, clvpuesto);
            var data = new { result = editPuestoBean.sMensaje };
            return Json(data);
        }

        // Edicion de los datos generales del empleados

        [HttpPost]
        public JsonResult EditDataGeneral(string name, string apepat, string apemat, int sex, int estciv, string fnaci, string lnaci, int title, string nacion, int state, string codpost, string city, int colony, string street, string numberst, string telfij, string telmov, string email, int clvemp)
        {
            EmpleadosBean empleadoBean = new EmpleadosBean();
            EditEmpleadoDao editEmpleadoDao = new EditEmpleadoDao();
            empleadoBean = editEmpleadoDao.sp_Empleados_Update_Empleado(name, apepat, apemat, sex, estciv, fnaci, lnaci, title, nacion, state, codpost, city, colony, street, numberst, telfij, telmov, email, clvemp);
            var data = new { result = empleadoBean.sMensaje };
            return Json(data);
        }

        // Edicion de los datos del imss del empleado

        [HttpPost]
        public JsonResult EditDataImss(string regimss, string rfc, string curp, int nivest, int nivsoc, int clvimss)
        {
            ImssBean imssBean = new ImssBean();
            EditEmpleadoDao editEmpleadoDao = new EditEmpleadoDao();
            imssBean = editEmpleadoDao.sp_Imss_Update_DatoImss(regimss, rfc, curp, nivest, nivsoc, clvimss);
            var data = new { result = imssBean.sMensaje };
            return Json(data);
        }

        // Edicion de los datos de la nomina del empleado

        [HttpPost]
        public JsonResult EditDataNomina(int numnom, double salmen, string pagret, int tipemp, string tipmon, int nivemp, int tipjor, int tipcon, string fecing, string fecant, string vencon, string estats, int clvnom)
        {
            DatosNominaBean nominaBean = new DatosNominaBean();
            EditEmpleadoDao editEmpleadoDao = new EditEmpleadoDao();
            nominaBean = editEmpleadoDao.sp_Nomina_Update_DatoNomina(numnom, salmen, pagret, tipemp, tipmon, nivemp, tipjor, tipcon, fecing, fecant, vencon, estats, clvnom);
            var data = new { result = nominaBean.sMensaje };
            return Json(data);
        }

        // Edicion de los datos de estructura del empleado

        [HttpPost]
        public JsonResult EditDataStructure(int numpla, int depaid, int puesid, string emprep, string report, string tippag, int banuse, string cunuse, int clvstr)
        {
            DatosPosicionesBean posicionBean = new DatosPosicionesBean();
            EditEmpleadoDao editEmpleadoDao = new EditEmpleadoDao();
            posicionBean = editEmpleadoDao.sp_Posiciones_Update_DatoPosicion(numpla, depaid, puesid, emprep, report, tippag, banuse, cunuse, clvstr);
            var data = new { result = posicionBean.sMensaje };
            return Json(data);
        }

    }
}