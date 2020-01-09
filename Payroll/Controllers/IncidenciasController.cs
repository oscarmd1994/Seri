using Payroll.Models.Beans;
using Payroll.Models.Daos;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Payroll.Controllers
{
    public class IncidenciasController : Controller
    {
        // GET: Incidencias
        public PartialViewResult Incidencias()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult ResumenVacaciones(int IdEmpleado = 4)
        {
            List<PeriodoVacacionesBean> empleados = new List<PeriodoVacacionesBean>();
            pruebaEmpleadosDao Dao = new pruebaEmpleadosDao();
            empleados = Dao.sp_Retrieve_PeriodosVacaciones(IdEmpleado);
            //
            string tabla = "";
            foreach (var emp in empleados)
            {
                tabla += "<tr>" +
                    "<td>" + emp.iAnio + "</td>" +
                    "<td>" + emp.iDiasDisfrutados + "</td>" +
                    "<td>" + emp.iDiasPrima + "</td>" +
                    "<td>" + emp.iIdEmpleado + "</td>" +
                    "<td>" + emp.sFechaInicio.ToString().Substring(0, 10) + "</td>" +
                    "<td>" + emp.sFechaTermino.ToString().Substring(0, 10) + "</td>" +
                    "</tr>";
            }
            //
            return Json(tabla);
        }
        public PartialViewResult Ausentismos()
        {
            return PartialView();
        }
        public PartialViewResult PensionesAlimenticias()
        {
            return PartialView();
        }
    }
}