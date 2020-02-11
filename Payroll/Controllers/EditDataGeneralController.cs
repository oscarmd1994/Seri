using Payroll.Models.Beans;
using Payroll.Models.Daos;
using System.Web.Mvc;

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
        public JsonResult EditDepartament(string edidepart, string edidescdepart, string edinivestuc, string nivsuptxtedit, int ediedific, string edipiso, string ediubicac, int edicentrcost, int edireportaa, string edidgatxt, string edidirgentxt, string edidirejetxt, string edidiraretxt, int edidirgen, int edidireje, int edidirare, int clvdepart)
        {
            DepartamentosBean editDepartamentoBean = new DepartamentosBean();
            EditDepartamentosDao editDepartamentoDao = new EditDepartamentosDao();
            editDepartamentoBean = editDepartamentoDao.sp_Departamentos_Update_Departamento(edidepart, edidescdepart, edinivestuc, nivsuptxtedit, ediedific, edipiso, ediubicac, edicentrcost, edireportaa, edidgatxt, edidirgentxt, edidirejetxt, edidiraretxt, edidirgen, edidireje, edidirare, clvdepart);
            var data = new { result = editDepartamentoBean.sMensaje };
            return Json(data);
        }

        [HttpPost]
        public JsonResult EditPuesto(string edicodpuesto, string edipuesto, string edidescpuesto, int ediproffamily, int ediclasifpuesto, int edicolect, int edinivjerarpuesto, int ediperfmanager, int editabpuesto, int clvpuesto)
        {
            PuestosBean editPuestoBean = new PuestosBean();
            EditPuestosDao editPuestoDao = new EditPuestosDao();
            editPuestoBean = editPuestoDao.sp_Puestos_Update_Puesto(edicodpuesto, edipuesto, edidescpuesto, ediproffamily, ediclasifpuesto, edicolect, edinivjerarpuesto, ediperfmanager, editabpuesto, clvpuesto);
            var data = new { result = editPuestoBean.sMensaje };
            return Json(data);
        }

        // Edicion de los datos generales del empleados

        [HttpPost]
        public JsonResult EditDataGeneral(string name, string apepat, string apemat, int sex, int estciv, string fnaci, string lnaci, int title, int nacion, int state, string codpost, string city, string colony, string street, string numberst, string telfij, string telmov, string email, string tipsan, string fecmat, int clvemp)
        {
            EmpleadosBean empleadoBean = new EmpleadosBean();
            EditEmpleadoDao editEmpleadoDao = new EditEmpleadoDao();
            empleadoBean = editEmpleadoDao.sp_Empleados_Update_Empleado(name, apepat, apemat, sex, estciv, fnaci, lnaci, title, nacion, state, codpost, city, colony, street, numberst, telfij, telmov, email, fecmat, tipsan, clvemp);
            var data = new { result = empleadoBean.sMensaje };
            return Json(data);
        }

        // Edicion de los datos del imss del empleado

        [HttpPost]
        public JsonResult EditDataImss(string regimss, string fecefe, string rfc, string curp, int nivest, int nivsoc, int clvimss)
        {
            ImssBean imssBean = new ImssBean();
            EditEmpleadoDao editEmpleadoDao = new EditEmpleadoDao();
            imssBean = editEmpleadoDao.sp_Imss_Update_DatoImss(regimss, fecefe, rfc, curp, nivest, nivsoc, clvimss);
            var data = new { result = imssBean.sMensaje };
            return Json(data);
        }

        // Edicion de los datos de la nomina del empleado

        [HttpPost]
        public JsonResult EditDataNomina(string fechefectact, string fecefecnom, double salmen, int tipper, int tipemp, int nivemp, int tipjor, int tipcon, int tipcontra, int motinc, string fecing, string fecant, string vencon, int tippag, int banuse, string cunuse, int clvnom, int position)
        {
            DatosNominaBean nominaBean = new DatosNominaBean();
            EditEmpleadoDao editEmpleadoDao = new EditEmpleadoDao();
            nominaBean = editEmpleadoDao.sp_Nomina_Update_DatoNomina(fecefecnom, salmen, tipper, tipemp, nivemp, tipjor, tipcon, tipcontra, motinc, fecing, fecant, vencon, tippag, banuse, cunuse, clvnom, position);
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
        // Edita las regiones
        [HttpPost]
        public JsonResult EditRegionales(string descregionedit, string claregionedit, int clvregion)
        {
            RegionalesBean regionBean = new RegionalesBean();
            EditRegionalesDao editRegionalesDao = new EditRegionalesDao();
            regionBean = editRegionalesDao.sp_Regionales_Update_Regionales(descregionedit, claregionedit, clvregion);
            var data = new { result = regionBean.sMensaje };
            return Json(data);
        }

        // Edita las sucursales
        [HttpPost]
        public JsonResult EditSucursales(string descsucursaledit, string clasucursaledit, int clvsucursal)
        {
            SucursalesBean sucursalBean = new SucursalesBean();
            EditSucursalesDao editSucursalesDao = new EditSucursalesDao();
            sucursalBean = editSucursalesDao.sp_Sucursales_Update_Sucursales(descsucursaledit, clasucursaledit, clvsucursal);
            var data = new { result = sucursalBean.sMensaje };
            return Json(data);
        }
    }
}