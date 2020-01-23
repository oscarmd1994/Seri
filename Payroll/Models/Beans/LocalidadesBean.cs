using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll.Models.Beans
{
    public class LocalidadesBean
    {
        public int IdLocalidad { get; set; }
        public int Empresa_id { get; set; }
        public int Codigo_Localidad { get; set; }
        public string Descripcion { get; set; }
        public string TasaIva { get; set; }
        public int RegistroPatronal_id { get; set; }
        public int Regional_id { get; set; }
        public int ZonaEconomica_id { get; set; }
        public int Sucursal_id { get; set; }
        public int Estado_id { get; set; }
    }
}