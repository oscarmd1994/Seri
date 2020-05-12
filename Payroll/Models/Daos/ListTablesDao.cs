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
<<<<<<< HEAD
=======
        public List<EmpleadosBean> sp_Empleados_Retrieve_Search_Empleados(int keyemp, string wordsearch, string filtered)
        {
            List<EmpleadosBean> listEmpleadosBean = new List<EmpleadosBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Empleados_Retrieve_Search_Empleados", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpresa", keyemp));
                cmd.Parameters.Add(new SqlParameter("@ctrlWordSearch", wordsearch));
                cmd.Parameters.Add(new SqlParameter("@ctrlFiltered", filtered));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        EmpleadosBean empleadoBean = new EmpleadosBean();
                        empleadoBean.iIdEmpleado = Convert.ToInt32(data["IdEmpleado"].ToString());
                        empleadoBean.sNombreEmpleado = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(data["Nombre_Empleado"].ToString() + " " + data["Apellido_Paterno_Empleado"].ToString() + " " + data["Apellido_Materno_Empleado"].ToString());
                        empleadoBean.iNumeroNomina = Convert.ToInt32(data["IdEmpleado"].ToString());
                        listEmpleadosBean.Add(empleadoBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                string origenerror = "ListTablesdao";
                string mensajeerror = exc.ToString();
                CapturaErroresBean capturaErrorBean = new CapturaErroresBean();
                CapturaErrores capturaErrorDao = new CapturaErrores();
                capturaErrorBean = capturaErrorDao.sp_Errores_Insert_Errores(origenerror, mensajeerror);
                Console.WriteLine(exc);
            }
            return listEmpleadosBean;
        }
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400
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
<<<<<<< HEAD
                if (data.Read()) {
                    imssBean.iIdImss       = Convert.ToInt32(data["IdImss"].ToString());
=======
                if (data.Read())
                {
                    imssBean.iIdImss = Convert.ToInt32(data["IdImss"].ToString());
                    imssBean.iEmpleado_id = Convert.ToInt32(data["Empleado_id"].ToString());
                    imssBean.iEmpresa_id = Convert.ToInt32(data["Empresa_id"].ToString());
                    // (String.IsNullOrEmpty(data["Effdt"].ToString())) ? "" : data["Effdt"].ToString();
                    imssBean.sFechaEfectiva = Convert.ToDateTime(data["Effdt"].ToString()).ToString("yyyy-MM-dd");
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400
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

        public List<EmpleadosBean> sp_EmpleadosDEmpresa_Retrieve_EmpleadosDEmpresa(int CtrliIdEmpresa)
        {
            List<EmpleadosBean> list = new List<EmpleadosBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_EmpleadosDEmpresa_Retrieve_EmpleadosDEmpresa", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrliIdEmpresa", CtrliIdEmpresa));

                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
<<<<<<< HEAD
                    while (data.Read())
=======
                    nominaBean.iIdNomina = Convert.ToInt32(data["IdNomina"].ToString());
                    nominaBean.iEmpleado_id = Convert.ToInt32(data["Empleado_id"].ToString());
                    nominaBean.iEmpresa_id = Convert.ToInt32(data["Empresa_id"].ToString());
                    nominaBean.sFechaEfectiva = Convert.ToDateTime(data["Effdt"].ToString()).ToString("yyyy-MM-dd");
                    nominaBean.dSalarioMensual = Convert.ToDouble(data["SalarioMensual"].ToString());
                    if (data["Cg_TipoEmpleado_id"].ToString().Length != 0)
                    {
                        nominaBean.iTipoEmpleado_id = Convert.ToInt32(data["Cg_TipoEmpleado_id"].ToString());
                    }
                    else
                    {
                        nominaBean.iTipoEmpleado_id = 0;
                    }
                    if (data["Cg_NivelEmpleado_id"].ToString().Length != 0)
                    {
                        nominaBean.iNivelEmpleado_id = Convert.ToInt32(data["Cg_NivelEmpleado_id"].ToString());
                    }
                    else
                    {
                        nominaBean.iNivelEmpleado_id = 0;
                    }
                    if (data["Cg_TipoJornada_id"].ToString().Length != 0)
                    {
                        nominaBean.iTipoJornada_id = Convert.ToInt32(data["Cg_TipoJornada_id"].ToString());
                    }
                    else
                    {
                        nominaBean.iTipoJornada_id = 0;
                    }
                    if (data["Cg_TipoContrato_id"].ToString().Length != 0)
                    {
                        nominaBean.iTipoContrato_id = Convert.ToInt32(data["Cg_TipoContrato_id"].ToString());
                    }
                    else
                    {
                        nominaBean.iTipoContrato_id = 0;
                    }
                    if (data["Cg_TipoContratacion_id"].ToString().Length != 0)
                    {
                        nominaBean.iTipoContratacion_id = Convert.ToInt32(data["Cg_TipoContratacion_id"].ToString());
                    }
                    else
                    {
                        nominaBean.iTipoContratacion_id = 0;
                    }
                    if (data["Cg_MotivoIncremento_id"].ToString().Length != 0)
                    {
                        nominaBean.iMotivoIncremento_id = Convert.ToInt32(data["Cg_MotivoIncremento_id"].ToString());
                    }
                    else
                    {
                        nominaBean.iMotivoIncremento_id = 0;
                    }
                    nominaBean.sFechaIngreso = Convert.ToDateTime(data["Effdt"].ToString()).ToString("yyyy-MM-dd");
                    nominaBean.sFechaAntiguedad = Convert.ToDateTime(data["Effdt"].ToString()).ToString("yyyy-MM-dd");
                    nominaBean.sVencimientoContrato = Convert.ToDateTime(data["Effdt"].ToString()).ToString("yyyy-MM-dd");
                    if (data["Posicion_id"].ToString().Length != 0)
                    {
                        nominaBean.iPosicion_id = Convert.ToInt32(data["Posicion_id"].ToString());
                    }
                    else
                    {
                        nominaBean.iPosicion_id = 0;
                    }
                    if (data["Cg_tipoPago_id"].ToString().Length != 0)
                    {
                        nominaBean.iTipoPago_id = Convert.ToInt32(data["Cg_tipoPago_id"].ToString());
                    }
                    else
                    {
                        nominaBean.iTipoPago_id = 0;
                    }
                    if (data["Banco_id"].ToString().Length != 0)
                    {
                        nominaBean.iBanco_id = Convert.ToInt32(data["Banco_id"].ToString());
                    }
                    else
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400
                    {
                        EmpleadosBean ls = new EmpleadosBean();
                        
                       ls.iIdEmpleado = int.Parse(data["IdEmpleado"].ToString());
                       ls.sNombreEmpleado = data["NombreCompleto"].ToString();
                       list.Add(ls);
                    }
                }
                else
                {
                    list = null;
                }
                data.Close(); cmd.Dispose(); conexion.Close(); cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;
        }

        public List<EmisorReceptorBean> sp_EmisorReceptor_Retrieve_EmisorReceptor(int CrtliIdEmpresa, string CrtlsNombre, string CrtlsAPaterno,string CrtlsAMaterno)
        {
            List<EmisorReceptorBean> list = new List<EmisorReceptorBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_EmisorReceptor_Retrieve_EmisorReceptor", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrliIdEmpresa", CrtliIdEmpresa));
                cmd.Parameters.Add(new SqlParameter("@CrtlsNombre", CrtlsNombre));
                cmd.Parameters.Add(new SqlParameter("@CrtlsAPaterno", CrtlsAPaterno));
                cmd.Parameters.Add(new SqlParameter("@CrtlsAMaterno", CrtlsAMaterno));
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
<<<<<<< HEAD
                    while (data.Read())
                    {
                        EmisorReceptorBean ls = new EmisorReceptorBean();
                        ls.sNombreEmpresa =data["NombreEmpresa"].ToString();
                        ls.sCalle = data["Calle"].ToString();
                        ls.sColonia = data["Colonia"].ToString();
                        ls.sCiudad = data["Ciudad"].ToString();
                        ls.sRFC = data["RFC"].ToString();
                        ls.sAfiliacionIMSS = data["Afiliacion_IMSS"].ToString();
                        ls.sNombreComp = data["NombreComp"].ToString();
                        ls.sRFCEmpleado = data["RFCEmpleado"].ToString();
                        ls.iIdEmpleado = int.Parse(data["IdEmpleado"].ToString());
                        ls.sDescripcionDepartamento = data["DescripcionDepartamento"].ToString();
                        ls.sNombrePuesto = data["NombrePuesto"].ToString();
                        ls.sFechaIngreso = data["FechaIngreso"].ToString();
                        ls.sTipoContrato = data["TipoContrato"].ToString();
                        ls.sCentroCosto = data["CentroCosto"].ToString();
                        ls.dSalarioMensual = decimal.Parse(data["SalarioMensual"].ToString());
                        ls.sRegistroImss = data["RegistroImss"].ToString();
                        ls.sCURP = data["CURP"].ToString();
                        list.Add(ls);
                    }
=======
                    posicionBean.iIdPosicionAsig = Convert.ToInt32(data["IdPosicion_Asig"].ToString());
                    posicionBean.iIdPosicion = Convert.ToInt32(data["IdPosicion"].ToString());
                    posicionBean.sPosicionCodigo = data["PosCode1"].ToString();
                    posicionBean.sFechaEffectiva = Convert.ToDateTime(data["Effdt"].ToString()).ToString("yyyy-MM-dd");
                    posicionBean.sFechaInicio = Convert.ToDateTime(data["Fecha_Inicio_Asign"].ToString()).ToString("yyyy-MM-dd");
                    posicionBean.iPuesto_id = Convert.ToInt32(data["Puesto_id"].ToString());
                    posicionBean.sNombrePuesto = data["NombrePuesto"].ToString();
                    posicionBean.sPuestoCodigo = data["PuestoCodigo"].ToString();
                    posicionBean.iDepartamento_id = Convert.ToInt32(data["Departamento_id"].ToString());
                    posicionBean.sDeptoCodigo = data["Depto_Codigo"].ToString();
                    posicionBean.sNombreDepartamento = data["DescripcionDepartamento"].ToString();
                    posicionBean.iIdLocalidad = Convert.ToInt32(data["Localidad_id"].ToString());
                    posicionBean.sLocalidad = data["Descripcion"].ToString();
                    posicionBean.iIdReportaAPosicion = Convert.ToInt32(data["Reporta_A_Posicion_id"].ToString());
                    posicionBean.sCodRepPosicion = data["PosCode2"].ToString();
                    posicionBean.iIdRegistroPat = Convert.ToInt32(data["RegPat_id"].ToString());
                    posicionBean.sRegistroPat = data["Afiliacion_IMSS"].ToString();
                    posicionBean.iIdReportaAEmpresa = Convert.ToInt32(data["Reporta_A_Empresa"].ToString());
                    posicionBean.sNombreEmrpesaRepo = data["NombreEmpresa"].ToString();
                    posicionBean.sMensaje = "success";
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400
                }
                else
                {
                    list = null;
                }
                data.Close(); cmd.Dispose(); conexion.Close(); cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;
        }
<<<<<<< HEAD
=======
        public List<EmpleadosBean> sp_EmpleadosDEmpresa_Retrieve_EmpleadosDEmpresa(int CtrliIdEmpresa)
        {
            List<EmpleadosBean> list = new List<EmpleadosBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_EmpleadosDEmpresa_Retrieve_EmpleadosDEmpresa", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrliIdEmpresa", CtrliIdEmpresa));

                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        EmpleadosBean ls = new EmpleadosBean();

                        ls.iIdEmpleado = int.Parse(data["IdEmpleado"].ToString());
                        ls.sNombreEmpleado = data["NombreCompleto"].ToString();
                        list.Add(ls);
                    }
                }
                else
                {
                    list = null;
                }
                data.Close(); cmd.Dispose(); conexion.Close(); cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;
        }

        public List<EmisorReceptorBean> sp_EmisorReceptor_Retrieve_EmisorReceptor(int CrtliIdEmpresa, int CrtliIdEmpleado)
        {
            List<EmisorReceptorBean> list = new List<EmisorReceptorBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_EmisorReceptor_Retrieve_EmisorReceptor", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CrtliIdEmpresa", CrtliIdEmpresa));
                cmd.Parameters.Add(new SqlParameter("@CrtliIdEmpleado", CrtliIdEmpleado));
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        EmisorReceptorBean ls = new EmisorReceptorBean();
                        ls.sNombreEmpresa = data["RazonSocial"].ToString();
                        ls.sCalle = data["Calle"].ToString();
                        //ls.sColonia = data["Colonia"].ToString();
                        ls.sCiudad = data["Ciudad"].ToString();
                        ls.sRFC = data["RFC"].ToString();
                        ls.sAfiliacionIMSS = data["Afiliacion_IMSS"].ToString();
                        ls.sNombreComp = data["NombreComp"].ToString();
                        ls.sRFCEmpleado = data["RFCEmpleado"].ToString();
                        ls.iIdEmpleado = int.Parse(data["IdEmpleado"].ToString());
                        ls.sDescripcionDepartamento = data["DescripcionDepartamento"].ToString();
                        ls.sNombrePuesto = data["NombrePuesto"].ToString();
                        ls.sFechaIngreso = data["FechaIngreso"].ToString();
                        ls.sTipoContrato = data["TipoContrato"].ToString();
                        ls.sCentroCosto = data["CentroCosto"].ToString();
                        ls.dSalarioMensual = decimal.Parse(data["SalarioMensual"].ToString());
                        ls.sRegistroImss = data["RegistroImss"].ToString();
                        ls.sCURP = data["CURP"].ToString();
                        ls.sDescripcion = data[""].ToString();
                        ls.iCtaCheques = int.Parse(data[""].ToString());
                        ls.iRegimenFiscal = int.Parse(data[""].ToString());

                        list.Add(ls);
                    }
                }
                else
                {
                    list = null;
                }
                data.Close(); cmd.Dispose(); conexion.Close(); cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;
        }

        public List<CInicioFechasPeriodoBean> sp_DatosPerido_Retrieve_DatosPerido(int CtrliIdEmpresa, int CtrliAnio, int CtrliTipoPereriodo, int CtrliPeriodo)
        {
            List<CInicioFechasPeriodoBean> list = new List<CInicioFechasPeriodoBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_DatosPerido_Retrieve_DatosPerido", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrliIdEmpresa", CtrliIdEmpresa));
                cmd.Parameters.Add(new SqlParameter("@CtrliAnio", CtrliAnio));
                cmd.Parameters.Add(new SqlParameter("@CtrliTipoPereriodo", CtrliTipoPereriodo));
                cmd.Parameters.Add(new SqlParameter("@CtrliPeriodo", CtrliPeriodo));
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        CInicioFechasPeriodoBean LP = new CInicioFechasPeriodoBean();
                        {
                            LP.iId = int.Parse(data["Id"].ToString());
                            LP.sNominaCerrada = data["Nomina_Cerrada"].ToString();
                            LP.sFechaInicio = data["Fecha_Inicio"].ToString();
                            LP.sFechaFinal = data["Fecha_Final"].ToString();
                            LP.sFechaProceso = data["Fecha_Proceso"].ToString();
                            LP.sFechaPago = data["Fecha_Pago"].ToString();
                            LP.iDiasEfectivos = int.Parse(data["Dias_Efectivos"].ToString());

                        };

                        list.Add(LP);
                    }
                }
                else
                {
                    list = null;
                }

                data.Close(); cmd.Dispose(); conexion.Close(); cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;

        }


>>>>>>> 372449f08200e247f5d4c46af2d806e69867fc5a
    }
}