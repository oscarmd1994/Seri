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
                string origenerror = "ListTablesdao";
                string mensajeerror = exc.ToString();
                CapturaErroresBean capturaErrorBean = new CapturaErroresBean();
                CapturaErrores capturaErrorDao = new CapturaErrores();
                capturaErrorBean = capturaErrorDao.sp_Errores_Insert_Errores(origenerror, mensajeerror);
                Console.WriteLine(exc);
            }
            return listEmpleadosBean;
        }
        public EmpleadosBean sp_Empleados_Retrieve_Empleado(int keyemploye)
        {
            EmpleadosBean empleadoBean = new EmpleadosBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Empleados_Retrieve_Empleado", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpleado", keyemploye));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    empleadoBean.iIdEmpleado = Convert.ToInt32(data["IdEmpleado"].ToString());
                    empleadoBean.sNombreEmpleado = (String.IsNullOrEmpty(data["Nombre_Empleado"].ToString())) ? "" : data["Nombre_Empleado"].ToString();
                    empleadoBean.sApellidoPaterno = (String.IsNullOrEmpty(data["Apellido_Paterno_Empleado"].ToString())) ? "" : data["Apellido_Paterno_Empleado"].ToString();
                    empleadoBean.sApellidoMaterno = (String.IsNullOrEmpty(data["Apellido_Materno_Empleado"].ToString())) ? "" : data["Apellido_Materno_Empleado"].ToString();
                    empleadoBean.sFechaNacimiento = (String.IsNullOrEmpty(data["Fecha_Nacimiento_Empleado"].ToString())) ? "" : data["Fecha_Nacimiento_Empleado"].ToString();
                    empleadoBean.sLugarNacimiento = (String.IsNullOrEmpty(data["Lugar_Nacimiento_Empleado"].ToString())) ? "" : data["Lugar_Nacimiento_Empleado"].ToString();
                    if (data["Cg_Titulo_id"].ToString().Length != 0)
                    {
                        empleadoBean.iTitulo_id = Convert.ToInt32(data["Cg_Titulo_id"].ToString());
                    }
                    else
                    {
                        empleadoBean.iTitulo_id = 0;
                    }
                    if (data["Cg_Genero_Empleado_id"].ToString().Length != 0)
                    {
                        empleadoBean.iGeneroEmpleado = Convert.ToInt32(data["Cg_Genero_Empleado_id"].ToString());
                    }
                    else
                    {
                        empleadoBean.iGeneroEmpleado = 0;
                    }
                    if (data["Nacionalidad_id"].ToString().Length != 0)
                    {
                        empleadoBean.iNacionalidad = Convert.ToInt32(data["Nacionalidad_id"].ToString());
                    }
                    else
                    {
                        empleadoBean.iNacionalidad = 0;
                    }
                    if (data["Cg_EstadoCivil_Empleado_id"].ToString().Length != 0)
                    {
                        empleadoBean.iEstadoCivil = Convert.ToInt32(data["Cg_EstadoCivil_Empleado_id"].ToString());
                    }
                    else
                    {
                        empleadoBean.iEstadoCivil = 0;
                    }
                    empleadoBean.sCodigoPostal = (String.IsNullOrEmpty(data["Codigo_Postal"].ToString())) ? "" : data["Codigo_Postal"].ToString();
                    if (data["Cg_Estado_id"].ToString().Length != 0)
                    {
                        empleadoBean.iEstado_id = Convert.ToInt32(data["Cg_Estado_id"].ToString());
                    }
                    else
                    {
                        empleadoBean.iEstado_id = 0;
                    }
                    empleadoBean.sCiudad = (String.IsNullOrEmpty(data["Ciudad"].ToString())) ? "" : data["Ciudad"].ToString();
                    empleadoBean.sColonia = (String.IsNullOrEmpty(data["Colonia"].ToString())) ? "" : data["Colonia"].ToString();
                    empleadoBean.sCalle = (String.IsNullOrEmpty(data["Calle"].ToString())) ? "" : data["Calle"].ToString();
                    empleadoBean.sNumeroCalle = (String.IsNullOrEmpty(data["Numero_Calle"].ToString())) ? "S/N" : data["Numero_Calle"].ToString();
                    empleadoBean.sTelefonoFijo = (String.IsNullOrEmpty(data["Telefono_Fijo"].ToString())) ? "" : data["Telefono_Fijo"].ToString();
                    empleadoBean.sTelefonoMovil = (String.IsNullOrEmpty(data["Telefono_Movil"].ToString())) ? "" : data["Telefono_Movil"].ToString();
                    empleadoBean.sCorreoElectronico = (String.IsNullOrEmpty(data["Correo_Electronico"].ToString())) ? "" : data["Correo_Electronico"].ToString();
                    empleadoBean.sFechaMatrimonio = (String.IsNullOrEmpty(data["Fecha_Matrimonio"].ToString())) ? "" : data["Fecha_Matrimonio"].ToString();
                    empleadoBean.sTipoSangre = (String.IsNullOrEmpty(data["Tipo_Sangre"].ToString())) ? "" : data["Tipo_Sangre"].ToString();
                    empleadoBean.sMensaje = "success";
                }
                else
                {
                    empleadoBean.sMensaje = "error";
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
            return empleadoBean;
        }
        public ImssBean sp_Imss_Retrieve_ImssEmpleado(int keyemploye, int keyemp)
        {
            ImssBean imssBean = new ImssBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Imss_Retrieve_ImssEmpleado", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpleado", keyemploye));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpresa", keyemp));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    imssBean.iIdImss = Convert.ToInt32(data["IdImss"].ToString());
                    imssBean.iEmpleado_id = Convert.ToInt32(data["Empleado_id"].ToString());
                    imssBean.iEmpresa_id = Convert.ToInt32(data["Empresa_id"].ToString());
                    // (String.IsNullOrEmpty(data["Effdt"].ToString())) ? "" : data["Effdt"].ToString();
                    imssBean.sFechaEfectiva = Convert.ToDateTime(data["Effdt"].ToString()).ToString("yyyy-MM-dd");
                    imssBean.sRegistroImss = (String.IsNullOrEmpty(data["RegistroImss"].ToString())) ? "" : data["RegistroImss"].ToString();
                    imssBean.sRfc = (String.IsNullOrEmpty(data["RFC"].ToString())) ? "" : data["RFC"].ToString();
                    imssBean.sCurp = (String.IsNullOrEmpty(data["CURP"].ToString())) ? "" : data["CURP"].ToString();
                    if (data["Cg_NivelEstudio_id"].ToString().Length != 0)
                    {
                        imssBean.iNivelEstudio_id = Convert.ToInt32(data["Cg_NivelEstudio_id"].ToString());
                    }
                    else
                    {
                        imssBean.iNivelEstudio_id = 0;
                    }
                    if (data["Cg_NivelSocioeconomico_id"].ToString().Length != 0)
                    {
                        imssBean.iNivelSocioeconomico_id = Convert.ToInt32(data["Cg_NivelSocioeconomico_id"].ToString());
                    }
                    else
                    {
                        imssBean.iNivelSocioeconomico_id = 0;
                    }
                    imssBean.sMensaje = "success";
                }
                else
                {
                    imssBean.sMensaje = "error";
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
            return imssBean;
        }
        public DatosNominaBean sp_Nominas_Retrieve_NominaEmpleado(int keyemploye, int keyemp)
        {
            DatosNominaBean nominaBean = new DatosNominaBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Nominas_Retrieve_NominaEmpleado", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpleado", keyemploye));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpresa", keyemp));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
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
                    {
                        nominaBean.iBanco_id = 0;
                    }
                    nominaBean.sCuentaCheques = (String.IsNullOrEmpty(data["Cta_Cheques"].ToString())) ? "" : data["Cta_Cheques"].ToString();
                    nominaBean.iUsuarioAlta_id = Convert.ToInt32(data["Usuario_Alta_id"].ToString());
                    nominaBean.sFechaAlta = data["Fecha_Alta"].ToString();
                    nominaBean.sMensaje = "success";
                }
                else
                {
                    nominaBean.sMensaje = "error";
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
            return nominaBean;
        }
        public DatosPosicionesBean sp_Posiciones_Retrieve_PosicionEmpleado(int keyemploye, int keyemp)
        {
            DatosPosicionesBean posicionBean = new DatosPosicionesBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Posiciones_Retrieve_PosicionEmpleado", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpleado", keyemploye));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpresa", keyemp));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
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
                }
                else
                {
                    posicionBean.sMensaje = "error";
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


    }
}