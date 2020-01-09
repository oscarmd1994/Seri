using System;
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
        public JsonResult SaveDataPuestos(string puesto, string descripcion, int profesion, int etiqueta, int colectivo, string grado, string tarjeta, int clasificacion, int nivel, int perfomance, int tabulador, string sindicato, int clavesat)
        {
            PuestosBean addPuestoBean = new PuestosBean();
            SavePuestosDao savePuestoDao = new SavePuestosDao();
            string usuario = Session["sUsuario"].ToString();
            addPuestoBean = savePuestoDao.sp_Puestos_Insert_Puestos(puesto, descripcion, profesion, etiqueta, colectivo, grado, tarjeta, clasificacion, nivel, perfomance, tabulador, sindicato, clavesat, usuario);
            return Json(addPuestoBean);
        }

        //Guarda los datos del departamento
        [HttpPost]
        public JsonResult SaveDepartament(string regdepart, string descdepart, int reportaa, int centrcost, int edific, int nivestuc, string ubicac, string plaza, string titul, string sucurbanc, string categ)
        {
            DepartamentosBean addDepartamentoBean = new DepartamentosBean();
            SaveDepartamentosDao saveDepartamentoDao = new SaveDepartamentosDao();
            string usuario = Session["sUsuario"].ToString();
            addDepartamentoBean = saveDepartamentoDao.sp_Departamentos_Insert_Departamento(regdepart, descdepart, reportaa, centrcost, edific, nivestuc, ubicac, plaza, titul, sucurbanc, categ, usuario);
            string result = "error";
            if (addDepartamentoBean.sMensaje == "success") {
                result = addDepartamentoBean.sMensaje;
            }
            var data = new { result = result };
            return Json(data);
        }

        //Guarda los datos generales del empleado
        [HttpPost]
        public JsonResult DataGeneral(string name, string apepat, string apemat, int sex, int estciv, string fnaci, string lnaci, int title, string nacion, int state, string codpost, string city, int colony, string street, string numberst, string telfij, string telmov, string email)
        {
            EmpleadosBean addEmpleadoBean = new EmpleadosBean();
            EmpleadosDao empleadoDao = new EmpleadosDao();
            string usuario = Session["sUsuario"].ToString();
            int empresa = 32;
            addEmpleadoBean = empleadoDao.sp_Empleados_Insert_Empleado(name, apepat, apemat, sex, estciv, fnaci, lnaci, title, nacion, state, codpost, city, colony, street, numberst, telfij, telmov, email, usuario, empresa);
            var data = new { result = addEmpleadoBean.sMensaje };
            return Json(data);
        }

        //Guarda los datos del imss del empleado
        [HttpPost]
        public JsonResult DataImss(string regimss, string rfc, string curp, int nivest, int nivsoc, string empleado, string apepat, string apemat, string fechanaci)
        {
            ImssBean addImssBean = new ImssBean();
            ImssDao imssDao = new ImssDao();
            string usuario = Session["sUsuario"].ToString();
            addImssBean = imssDao.sp_Imss_Insert_Imss(regimss, rfc, curp, nivest, nivsoc, usuario, empleado, apepat, apemat, fechanaci);
            var data = new { result = addImssBean.sMensaje };
            return Json(data);
        }

        //Guarda los datos de la nomina del empleado
        [HttpPost]
        public JsonResult DataNomina(int numnom, double salmen, string pagret, int tipemp, string tipmon, int nivemp, int tipjor, int tipcon, string fecing, string fecant, string vencon, string estats, string empleado, string apepat, string apemat, string fechanaci, int keyemp)
        {
            DatosNominaBean addDatoNomina = new DatosNominaBean();
            DatosNominaDao datoNominaDao = new DatosNominaDao();
            string usuario = Session["sUsuario"].ToString();
            addDatoNomina = datoNominaDao.sp_DatosNomina_Insert_DatoNomina(numnom, salmen, pagret, tipemp, tipmon, nivemp, tipjor, tipcon, fecing, fecant, vencon, estats, usuario, empleado, apepat, apemat, fechanaci, keyemp);
            var data = new { result = addDatoNomina.sMensaje };
            return Json(data);
        }

        //Guarda los datos de estructura del empleado
        [HttpPost]
        public JsonResult DataEstructura(int numpla, int depaid, int puesid, string emprep, string report, string tippag, int banuse, string cunuse, string empleado, string apepat, string apemat, string fechanaci)
        {
            DatosPosicionesBean addPosicionBean = new DatosPosicionesBean();
            DatosPosicionesDao datoPosicionDao = new DatosPosicionesDao();
            int empresa = 17;
            string usuario = Session["sUsuario"].ToString();
            addPosicionBean = datoPosicionDao.sp_Posiciones_Insert_Posicion(empresa, numpla, depaid, puesid, emprep, report, tippag, banuse, cunuse, usuario, empleado, apepat, apemat, fechanaci);
            var data = new { result = addPosicionBean.sMensaje };
            return Json(data);
        }
    }
}