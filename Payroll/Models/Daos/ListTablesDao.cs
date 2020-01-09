using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Payroll.Models.Beans;
using Payroll.Models.Utilerias;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace Payroll.Models.Daos
{
    public class ListTablesDao { }

    public class ListEmpleadosDao : Conexion
    {
        public List<EmpleadosBean> sp_Empleados_Retrieve_Empleados(int keyemp)
        {
            List<EmpleadosBean> listEmpleadosBean = new List<EmpleadosBean>();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Empleados_Retrieve_Empleados", this.conexion) {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpresa", keyemp));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows) {
                    while (data.Read()) {
                        EmpleadosBean empleadoBean   = new EmpleadosBean();
                        empleadoBean.iIdEmpleado     = Convert.ToInt32(data["IdEmpleado"].ToString());
                        empleadoBean.sNombreEmpleado = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(data["NombreEmpleado"].ToString() + " " + data["ApellidoPaternoEmpleado"].ToString() + " " + data["ApellidoMaternoEmpleado"].ToString());
                        empleadoBean.iNumeroNomina   = Convert.ToInt32(data["NumeroNomina"].ToString());
                        listEmpleadosBean.Add(empleadoBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return listEmpleadosBean;
        }

        public EmpleadosBean sp_Empleados_Retrieve_Empleado(int keyemploye)
        {
            EmpleadosBean empleadoBean = new EmpleadosBean();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Empleados_Retrieve_Empleado", this.conexion) {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpleado", keyemploye));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read()) {
                    empleadoBean.iIdEmpleado        = Convert.ToInt32(data["IdEmpleado"].ToString());
                    empleadoBean.sNombreEmpleado    = data["NombreEmpleado"].ToString();
                    empleadoBean.sApellidoPaterno   = data["ApellidoPaternoEmpleado"].ToString();
                    empleadoBean.sApellidoMaterno   = data["ApellidoMaternoEmpleado"].ToString();
                    empleadoBean.sFechaNacimiento   = data["FechaNacimientoEmpleado"].ToString();
                    empleadoBean.sLugarNacimiento   = data["LugarNacimientoEmpleado"].ToString();
                    empleadoBean.iTitulo_id         = Convert.ToInt32(data["Titulo_id"].ToString());
                    empleadoBean.iGeneroEmpleado    = Convert.ToInt32(data["GeneroEmpleado_id"].ToString());
                    empleadoBean.sNacionalidad      = data["Nacionalidad"].ToString();
                    empleadoBean.iEstadoCivil       = Convert.ToInt32(data["EstadoCivilEmpleado_id"].ToString());
                    empleadoBean.sCodigoPostal      = data["CodigoPostal"].ToString();
                    empleadoBean.iEstado_id         = Convert.ToInt32(data["Estado_id"].ToString());
                    empleadoBean.sCiudad            = data["Ciudad"].ToString();
                    empleadoBean.iColonia_id        = Convert.ToInt32(data["Colonia_id"].ToString());
                    empleadoBean.sCalle             = data["Calle"].ToString();
                    empleadoBean.sNumeroCalle       = (String.IsNullOrEmpty(data["NumeroCalle"].ToString())) ? "S/N" : data["NumeroCalle"].ToString();
                    empleadoBean.sTelefonoFijo      = (String.IsNullOrEmpty(data["TelefonoFijo"].ToString())) ? "" : data["TelefonoFijo"].ToString();
                    empleadoBean.sTelefonoMovil     = (String.IsNullOrEmpty(data["TelefonoMovil"].ToString())) ? "" : data["TelefonoMovil"].ToString();
                    empleadoBean.sCorreoElectronico = (String.IsNullOrEmpty(data["CorreoElectronico"].ToString())) ? "" : data["CorreoElectronico"].ToString();
                    empleadoBean.sMensaje         = "success";
                } else {
                    empleadoBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return empleadoBean;
        }

        public ImssBean sp_Imss_Retrieve_ImssEmpleado(int keyemploye)
        {
            ImssBean imssBean = new ImssBean();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Imss_Retrieve_ImssEmpleado", this.conexion) { 
                    CommandType = CommandType.StoredProcedure 
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpleado", keyemploye));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read()) {
                    imssBean.iIdImss       = Convert.ToInt32(data["IdImss"].ToString());
                    imssBean.sRegistroImss = (String.IsNullOrEmpty(data["RegistroImss"].ToString())) ? "" : data["RegistroImss"].ToString();
                    imssBean.sRfc          = (String.IsNullOrEmpty(data["RFC"].ToString())) ? "" : data["RFC"].ToString();
                    imssBean.sCurp         = (String.IsNullOrEmpty(data["CURP"].ToString())) ? "" : data["CURP"].ToString();
                    imssBean.iNivelEstudio_id        = Convert.ToInt32(data["NivelEstudio_id"].ToString());
                    imssBean.iNivelSocioeconomico_id = Convert.ToInt32(data["NivelSocioeconomico_id"].ToString());
                    imssBean.sMensaje = "success";
                } else {
                    imssBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return imssBean;
        }

        public DatosNominaBean sp_Nominas_Retrieve_NominaEmpleado(int keyemploye)
        {
            DatosNominaBean nominaBean = new DatosNominaBean();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Nominas_Retrieve_NominaEmpleado", this.conexion) {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpleado", keyemploye));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read()) {
                    nominaBean.iIdNomina            = Convert.ToInt32(data["IdNomina"].ToString());
                    nominaBean.iNumeroNomina        = Convert.ToInt32(data["NumeroNomina"].ToString());
                    nominaBean.dSalarioMensual      = Convert.ToDouble(data["SalarioMensual"].ToString());
                    nominaBean.sPagoRetroactivo     = data["PagoRetroactivo"].ToString();
                    nominaBean.iTipoEmpleado_id     = Convert.ToInt32(data["TipoEmpleado_id"].ToString());
                    nominaBean.sTipoMoneda          = data["TipoMoneda"].ToString();
                    nominaBean.iNivelEmpleado_id    = Convert.ToInt32(data["NivelEmpleado_id"].ToString());
                    nominaBean.iTipoJornada_id      = Convert.ToInt32(data["TipoJornada_id"].ToString());
                    nominaBean.iTipoContrato_id     = Convert.ToInt32(data["TipoContrato_id"].ToString());
                    nominaBean.sFechaIngreso        = data["FechaIngreso"].ToString();
                    nominaBean.sFechaAntiguedad     = data["FechaAntiguedad"].ToString();
                    nominaBean.sVencimientoContrato = data["VencimientoContrato"].ToString();
                    nominaBean.sTipoAlta            = data["TipoAlta"].ToString();
                    nominaBean.sMensaje = "success";
                } else {
                    nominaBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return nominaBean;
        }

        public DatosPosicionesBean sp_Posiciones_Retrieve_PosicionEmpleado(int keyemploye)
        {
            DatosPosicionesBean posicionBean = new DatosPosicionesBean();
            try {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Posiciones_Retrieve_PosicionEmpleado", this.conexion) {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpleado", keyemploye));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read()) {
                    posicionBean.iIdPosicion         = Convert.ToInt32(data["IdPosicion"].ToString());
                    posicionBean.iPuesto_id          = Convert.ToInt32(data["Puesto_id"].ToString());
                    posicionBean.sNombrePuesto       = data["NombrePuesto"].ToString();
                    posicionBean.iDepartamento_id    = Convert.ToInt32(data["Departamento_id"].ToString());
                    posicionBean.sNombreDepartamento = data["Departamento"].ToString();
                    posicionBean.iPosicion       = Convert.ToInt32(data["Posicion"].ToString());
                    posicionBean.sEmpresaReporta = string.IsNullOrEmpty(data["EmpresaReportaA"].ToString()) ? "" : data["EmpresaReportaA"].ToString();
                    posicionBean.sReporta        = string.IsNullOrEmpty(data["ReportaA"].ToString()) ? "" : data["ReportaA"].ToString();
                    posicionBean.sTipoPago       = string.IsNullOrEmpty(data["TipoPago"].ToString()) ? "" : data["TipoPago"].ToString();
                    posicionBean.iBanco_id       = Convert.ToInt32(data["Banco_id"].ToString());
                    posicionBean.sCuenta         = string.IsNullOrEmpty(data["Cuenta"].ToString()) ? "" : data["Cuenta"].ToString();
                    posicionBean.sMensaje        = "success";
                } else {
                    posicionBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            } catch (Exception exc) {
                Console.WriteLine(exc);
            }
            return posicionBean;
        }

    }
}