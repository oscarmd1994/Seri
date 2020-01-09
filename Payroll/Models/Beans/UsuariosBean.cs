using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll.Models.Beans
{
    public class UsuariosBean
    {
        public int iIdUsuario { get; set; }
        public int iPerfil { get; set; }
        public string sUsuario { get; set; }
        public string sPassword { get; set; }
        public string sMensaje { get; set; }
    }
}