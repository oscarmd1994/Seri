using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll.Models.Beans
{
    public class RegistroPatronalBean
    {
        public int IdRegPat { get; set; }
        public int Empresa_id { get; set; }
        public string Afiliacion_IMSS { get; set; }
		public string Nombre_Afiliacion { get; set; }
        public string Riesgo_Trabajo { get; set; }
        public int ClasesRegPat_id { get; set; }
        public string Cancelado { get; set; }
    }
    public class CClases_RegPatBean
    {
        public int IdClase { get; set; }
        public string Nombre_Clase { get; set; }
        public string Descripcion_Clase { get; set; }
    }
    public class RegimenFiscalBean
    {
        public int IdRegimenFiscal { get; set; }
        public string Descripcion { get; set; }
    }

}