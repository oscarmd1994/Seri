using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Payroll.Models.Beans;
using Payroll.Models.Utilerias;
using System.Data.SqlClient;
using System.Data;

namespace Payroll.Models.Daos
{
    public class EditDataGeneralDao { }

    public class EditDepartamentosDao : Conexion
    {
        public DepartamentosBean sp_Departamentos_Update_Departamento(string edidepart, string edidescdepart, int edireportaa, int edicentrcost, int ediedific, int edinivestuc, string ediubicac, string ediplaza, string edititul, string edisucurbanc, string edicateg, int clvdepart)
        {
            DepartamentosBean departamentoBean = new DepartamentosBean();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Departamentos_Update_Departamento", this.conexion) {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlDepartamento", edidepart));
                cmd.Parameters.Add(new SqlParameter("@ctrlDescripcion", edidescdepart));
                cmd.Parameters.Add(new SqlParameter("@ctrlEmpresaReporta", edireportaa));
                cmd.Parameters.Add(new SqlParameter("@ctrlCentroCosto", edicentrcost));
                cmd.Parameters.Add(new SqlParameter("@ctrlEdificio", ediedific));
                cmd.Parameters.Add(new SqlParameter("@ctrlNivelEstructura", edinivestuc));
                cmd.Parameters.Add(new SqlParameter("@ctrlUbicacion", ediubicac));
                cmd.Parameters.Add(new SqlParameter("@ctrlPlaza", ediplaza));
                cmd.Parameters.Add(new SqlParameter("@ctrlTitulo", edititul));
                cmd.Parameters.Add(new SqlParameter("@ctrlSucursal", edisucurbanc));
                cmd.Parameters.Add(new SqlParameter("@ctrlCategoria", edicateg));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdDepartamento", clvdepart));
                if (cmd.ExecuteNonQuery() > 0) {
                    departamentoBean.sMensaje = "success";
                } else {
                    departamentoBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return departamentoBean;
        }
    }

    public class EditPuestosDao : Conexion
    {
        public PuestosBean sp_Puestos_Update_Puesto(string edipuesto, string edidescpuesto, int ediproffamily, int edietiqcont, int edicolect, string edigraddom, string editarjpres, int ediclasifpuesto, int edinivjerarpuesto, int ediperfmanager, int editabpuesto, string edisindcat, int ediclvsat, int clvpuesto)
        {
            PuestosBean puestoBean = new PuestosBean();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Puestos_Update_Puesto", this.conexion) {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlNombrePuesto", edipuesto));
                cmd.Parameters.Add(new SqlParameter("@ctrlDescripcion", edidescpuesto));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdProfesion", ediproffamily));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEtiqueta", edietiqcont));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdClasificacion", ediclasifpuesto));
                cmd.Parameters.Add(new SqlParameter("@ctrlColectivo", edicolect));
                cmd.Parameters.Add(new SqlParameter("@ctrlClaveSat", ediclvsat));
                cmd.Parameters.Add(new SqlParameter("@ctrlNivel", edinivjerarpuesto));
                cmd.Parameters.Add(new SqlParameter("@ctrlPerfomance", ediperfmanager));
                cmd.Parameters.Add(new SqlParameter("@ctrlTabulador", editabpuesto));
                cmd.Parameters.Add(new SqlParameter("@ctrlSindicato", edisindcat));
                cmd.Parameters.Add(new SqlParameter("@ctrlGrado", edigraddom));
                cmd.Parameters.Add(new SqlParameter("@ctrlTarjeta", editarjpres));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdPuesto", clvpuesto));
                if (cmd.ExecuteNonQuery() > 0) {
                    puestoBean.sMensaje = "success";
                } else {
                    puestoBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return puestoBean;
        }
    } 

    public class EditEmpleadoDao : Conexion
    {
        public EmpleadosBean sp_Empleados_Update_Empleado(string name, string apepat, string apemat, int sex, int estciv, string fnaci, string lnaci, int title, string nacion, int state, string codpost, string city, int colony, string street, string numberst, string telfij, string telmov, string email, int clvemp)
        {
            EmpleadosBean empleadoBean = new EmpleadosBean();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Empleados_Update_Empleado", this.conexion) {
                   CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlNombre", name));
                cmd.Parameters.Add(new SqlParameter("@ctrlApellidoPaterno", apepat));
                cmd.Parameters.Add(new SqlParameter("@ctrlApellidoMaterno", apemat));
                cmd.Parameters.Add(new SqlParameter("@ctrlSexo", sex));
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoCivil", estciv));
                cmd.Parameters.Add(new SqlParameter("@ctrlFechaNacimiento", fnaci));
                cmd.Parameters.Add(new SqlParameter("@ctrlLugarNacimiento", lnaci));
                cmd.Parameters.Add(new SqlParameter("@ctrlTitulo", title));
                cmd.Parameters.Add(new SqlParameter("@ctrlNacionalidad", nacion));
                cmd.Parameters.Add(new SqlParameter("@ctrlEstado", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlCodigoPostal", codpost));
                cmd.Parameters.Add(new SqlParameter("@ctrlCiudad", city));
                cmd.Parameters.Add(new SqlParameter("@ctrlColonia", colony));
                cmd.Parameters.Add(new SqlParameter("@ctrlCalle", street));
                cmd.Parameters.Add(new SqlParameter("@ctrlNumeroCalle", numberst));
                cmd.Parameters.Add(new SqlParameter("@ctrlTelefonoFijo", telfij));
                cmd.Parameters.Add(new SqlParameter("@ctrlTelefonoMovil", telmov));
                cmd.Parameters.Add(new SqlParameter("@ctrlCorreoElectronico", email));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpleado", clvemp));
                if (cmd.ExecuteNonQuery() > 0) {
                    empleadoBean.sMensaje = "success";
                } else {
                    empleadoBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return empleadoBean;
        }

        public ImssBean sp_Imss_Update_DatoImss(string regimss, string rfc, string curp, int nivest, int nivsoc, int clvimss)
        {
            ImssBean imssBean = new ImssBean();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Imss_Update_DatoImss", this.conexion) {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlRegistroImss", regimss));
                cmd.Parameters.Add(new SqlParameter("@ctrlRfc", rfc));
                cmd.Parameters.Add(new SqlParameter("@ctrlCurp", curp));
                cmd.Parameters.Add(new SqlParameter("@ctrlNivelEstudios", nivest));
                cmd.Parameters.Add(new SqlParameter("@ctrlNivelSocioeconomico", nivsoc));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdImss", clvimss));
                if (cmd.ExecuteNonQuery() > 0) {
                    imssBean.sMensaje = "success";
                } else {
                    imssBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return imssBean;
        }

        public DatosNominaBean sp_Nomina_Update_DatoNomina(int numnom, double salmen, string pagret, int tipemp, string tipmon, int nivemp, int tipjor, int tipcon, string fecing, string fecant, string vencon, string estats, int clvnom)
        {
            DatosNominaBean nominaBean = new DatosNominaBean();
            try{
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Nomina_Update_DatoNomina", this.conexion) {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlNumeroNomina", numnom));
                cmd.Parameters.Add(new SqlParameter("@ctrlSalarioMensual", salmen));
                cmd.Parameters.Add(new SqlParameter("@ctrlPagoRetroactivo", pagret));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoEmpleado", tipemp));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoMoneda", tipmon));
                cmd.Parameters.Add(new SqlParameter("@ctrlNivelEmpleado", nivemp));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoJornada", tipjor));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoContrato", tipcon));
                cmd.Parameters.Add(new SqlParameter("@ctrlFechaIngreso", fecing));
                cmd.Parameters.Add(new SqlParameter("@ctrlFechaAntiguedad", fecant));
                cmd.Parameters.Add(new SqlParameter("@ctrlVencimientoCont", vencon));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoAlta", estats));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdNomina", clvnom));
                if (cmd.ExecuteNonQuery() > 0) {
                    nominaBean.sMensaje = "success";
                } else {
                    nominaBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); conexion.Close();
            } catch (Exception exc){
                Console.WriteLine(exc);
            }
            return nominaBean;
        }

        public DatosPosicionesBean sp_Posiciones_Update_DatoPosicion(int numpla, int depaid, int puesid, string emprep, string report, string tippag, int banuse, string cunuse, int clvstr)
        {
            DatosPosicionesBean posicionBean = new DatosPosicionesBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Posiciones_Update_DatoPosicion", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlPuestoId", puesid));
                cmd.Parameters.Add(new SqlParameter("@ctrlDepartamentoId", depaid));
                cmd.Parameters.Add(new SqlParameter("@ctrlPosicion", numpla));
                cmd.Parameters.Add(new SqlParameter("@ctrlEmpresaRe", emprep));
                cmd.Parameters.Add(new SqlParameter("@ctrlReportaA", report));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoPago", tippag));
                cmd.Parameters.Add(new SqlParameter("@ctrlBanco_id", banuse));
                cmd.Parameters.Add(new SqlParameter("@ctrlCuenta", cunuse));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdPosicion", clvstr));
                if (cmd.ExecuteNonQuery() > 0) {
                    posicionBean.sMensaje = "success";
                } else {
                    posicionBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return posicionBean;
        }

    }

}