using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Payroll.Models.Beans;
using Payroll.Models.Utilerias;

namespace Payroll.Models.Daos
{
    public class SaveDataGeneralDao
    {
       
    }

    public class SavePuestosDao :  Conexion
    {
        public PuestosBean sp_Puestos_Insert_Puestos(string puesto, string descripcion, int profesion, int etiqueta, int colectivo, string grado, string tarjeta, int clasificacion, int nivel, int perfomance, int tabulador, string sindicato, int clavesat, string usuario)
        {
            PuestosBean addPuestoBean = new PuestosBean();
            int idempresa = 5;
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Puestos_Insert_Puesto", this.conexion) {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpresa", idempresa));
                cmd.Parameters.Add(new SqlParameter("@ctrlNombrePuesto", puesto));
                cmd.Parameters.Add(new SqlParameter("@ctrlDescripcion", descripcion));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdProfesion", profesion));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEtiqueta", etiqueta));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdClasificacion", clasificacion));
                cmd.Parameters.Add(new SqlParameter("@ctrlColectivo", colectivo));
                cmd.Parameters.Add(new SqlParameter("@ctrlClaveSat", clavesat));
                cmd.Parameters.Add(new SqlParameter("@ctrlNivel", nivel));
                cmd.Parameters.Add(new SqlParameter("@ctrlPerfomance", perfomance));
                cmd.Parameters.Add(new SqlParameter("@ctrlTabulador", tabulador));
                cmd.Parameters.Add(new SqlParameter("@ctrlSindicato", sindicato));
                cmd.Parameters.Add(new SqlParameter("@ctrlGrado", grado));
                cmd.Parameters.Add(new SqlParameter("@ctrlTarjeta", tarjeta));
                cmd.Parameters.Add(new SqlParameter("@ctrlUsuarioRegistro", usuario));
                if (cmd.ExecuteNonQuery() > 0) {
                    addPuestoBean.sMensaje = "success";
                } else {
                    addPuestoBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return addPuestoBean;
        }
    }

    public class SaveDepartamentosDao : Conexion
    {
        public DepartamentosBean sp_Departamentos_Insert_Departamento(string regdepart, string descdepart, int reportaa, int centrcost, int edific, int nivestuc, string ubicac, string plaza, string titul, string sucurbanc, string categ, string usuario)
        {
            DepartamentosBean addDepartamentoBean = new DepartamentosBean();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Departamentos_Insert_Departamento", this.conexion) {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlDepartamento", regdepart));
                cmd.Parameters.Add(new SqlParameter("@ctrlDescripcion", descdepart));
                cmd.Parameters.Add(new SqlParameter("@ctrlEmpresaReporta", reportaa));
                cmd.Parameters.Add(new SqlParameter("@ctrlCentroCosto", centrcost));
                cmd.Parameters.Add(new SqlParameter("@ctrlEdificio", edific));
                cmd.Parameters.Add(new SqlParameter("@ctrlNivelEstructura", nivestuc));
                cmd.Parameters.Add(new SqlParameter("@ctrlUbicacion", ubicac));
                cmd.Parameters.Add(new SqlParameter("@ctrlPlaza", plaza));
                cmd.Parameters.Add(new SqlParameter("@ctrlTitulo", titul));
                cmd.Parameters.Add(new SqlParameter("@ctrlSucursal", sucurbanc));
                cmd.Parameters.Add(new SqlParameter("@ctrlCategoria", categ));
                cmd.Parameters.Add(new SqlParameter("@ctrlUsuario", usuario));
                if (cmd.ExecuteNonQuery() > 0) {
                    addDepartamentoBean.sMensaje = "success";
                } else {
                    addDepartamentoBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return addDepartamentoBean;
        }
    }

    public class EmpleadosDao : Conexion
    {
        public EmpleadosBean sp_Empleados_Insert_Empleado(string name, string apepat, string apemat, int sex, int estciv, string fnaci, string lnaci, int title, string nacion, int state, string codpost, string city, int colony, string street, string numberst, string telfij, string telmov, string email, string usuario, int keyemp)
        {
            EmpleadosBean empleadoBean = new EmpleadosBean();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Empleados_Insert_Empleado", this.conexion) {
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
                cmd.Parameters.Add(new SqlParameter("@ctrlUsuario", usuario));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpresa", keyemp));
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
    }

    public class ImssDao : Conexion
    {
        public ImssBean sp_Imss_Insert_Imss(string regimss, string rfc, string curp, int nivest, int nivsoc, string usuario, string empleado, string apepat, string apemat, string fechanaci)
        {
            ImssBean imssBean = new ImssBean();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Imss_Insert_Imss", this.conexion){
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlRegistroImss", regimss));
                cmd.Parameters.Add(new SqlParameter("@ctrlRfc", rfc));
                cmd.Parameters.Add(new SqlParameter("@ctrlCurp", curp));
                cmd.Parameters.Add(new SqlParameter("@ctrlNivelEstudios", nivest));
                cmd.Parameters.Add(new SqlParameter("@ctrlNivelSocioeconomico", nivsoc));
                cmd.Parameters.Add(new SqlParameter("@ctrlUsuario", usuario));
                cmd.Parameters.Add(new SqlParameter("@ctrlEmpleado", empleado));
                cmd.Parameters.Add(new SqlParameter("@ctrlApellidoP", apepat));
                cmd.Parameters.Add(new SqlParameter("@ctrlApellidoM", apemat));
                cmd.Parameters.Add(new SqlParameter("@ctrlFechaNaci", fechanaci));
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
    }

    public class DatosNominaDao : Conexion
    {
        public DatosNominaBean sp_DatosNomina_Insert_DatoNomina(int numnom, double salmen, string pagret, int tipemp, string tipmon, int nivemp, int tipjor, int tipcon, string fecing, string fecant, string vencon, string estats, string usuario, string empleado, string apepat, string apemat, string fechanaci, int keyemp)
        {
            DatosNominaBean datoNominaBean = new DatosNominaBean();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_DatosNomina_Insert_DatoNomina", this.conexion) {
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
                cmd.Parameters.Add(new SqlParameter("@ctrlUsuario", usuario));
                cmd.Parameters.Add(new SqlParameter("@ctrlEmpleado", empleado));
                cmd.Parameters.Add(new SqlParameter("@ctrlApellidoP", apepat));
                cmd.Parameters.Add(new SqlParameter("@ctrlApellidoM", apemat));
                cmd.Parameters.Add(new SqlParameter("@ctrlFechaNaci", fechanaci));
                cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa", keyemp));
                if (cmd.ExecuteNonQuery() > 0) {
                    datoNominaBean.sMensaje = "success";
                } else {
                    datoNominaBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return datoNominaBean;
        }
    }

    public class DatosPosicionesDao : Conexion
    {
        public DatosPosicionesBean sp_Posiciones_Insert_Posicion(int keyemp, int numpla, int depaid, int puesid, string emprep, string report, string tippag, int banuse, string cunuse, string usuario, string empleado, string apepat, string apemat, string fechanaci)
        {
            DatosPosicionesBean datoPosicionBean = new DatosPosicionesBean();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Posiciones_Insert_Posicion", this.conexion) {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEmpresaId",keyemp));
                cmd.Parameters.Add(new SqlParameter("@ctrlPuestoId", puesid));
                cmd.Parameters.Add(new SqlParameter("@ctrlDepartamentoId", depaid));
                cmd.Parameters.Add(new SqlParameter("@ctrlPosicion", numpla));
                cmd.Parameters.Add(new SqlParameter("@ctrlEmpresaRe", emprep));
                cmd.Parameters.Add(new SqlParameter("@ctrlReportaA", report));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoPago", tippag));
                cmd.Parameters.Add(new SqlParameter("@ctrlBanco_id", banuse));
                cmd.Parameters.Add(new SqlParameter("@ctrlCuenta", cunuse));
                cmd.Parameters.Add(new SqlParameter("@ctrlUsuario", usuario));
                cmd.Parameters.Add(new SqlParameter("@ctrlEmpleado", empleado));
                cmd.Parameters.Add(new SqlParameter("@ctrlApellidoP", apepat));
                cmd.Parameters.Add(new SqlParameter("@ctrlApellidoM", apemat));
                cmd.Parameters.Add(new SqlParameter("@ctrlFechaNaci", fechanaci));
                if (cmd.ExecuteNonQuery() > 0) {
                    datoPosicionBean.sMensaje = "success";
                } else {
                    datoPosicionBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return datoPosicionBean;
        }
    }

}