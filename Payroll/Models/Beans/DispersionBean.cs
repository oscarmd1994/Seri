using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll.Models.Beans
{
    public class DispersionBean { }


    public class LoadTypePeriodPayrollBean
    {
        public int iEmpresa_id     { get; set; }
        public int iAnio           { get; set; }
        public int iTipoPeriodo    { get; set; }
        public int iPeriodo        { get; set; }
        public string sFechaInicio { get; set; }
        public string sFechaFinal  { get; set; }
        public string sMensaje     { get; set; }
    }

    public class PayrollRetainedEmployeesBean
    {
        public int iIdNominaRetenida  { get; set; }
        public string sNombreEmpleado { get; set; }
        public int iIdEmpresa         { get; set; }
        public int iIdEmpleado        { get; set; }
        public int iTipoPeriodo       { get; set; }
        public int iPeriodo           { get; set; }
        public string sAnio           { get; set; }
        public string sDescripcion    { get; set; }
        public int iActivo            { get; set; }
        public string sFechaAlta      { get; set; }
        public int iUsuarioId         { get; set; }
        public string sMensaje        { get; set; }
    }

    public class SearchEmployeePayRetainedBean
    {
        public int iIdEmpleado        { get; set; }
        public string sNombreEmpleado { get; set; }
        public string sNominaEmpleado { get; set; }
        public int iTipoPeriodo       { get; set; }
        public string sMensaje        { get; set; }
    }

    public class LoadTypePeriodBean
    {
        public int iEmpresa_id     { get; set; }
        public int iAnio           { get; set; }
        public int iTipoPeriodo    { get; set; }
        public int iPeriodo        { get; set; }
        public string sFechaInicio { get; set; }
        public string sFechaFinal  { get; set; }
        public string sMensaje     { get; set; }
    }

}