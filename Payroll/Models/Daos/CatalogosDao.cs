using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Payroll.Models.Utilerias;
using Payroll.Models.Beans;
using System.Data.SqlClient;
using System.Data;

namespace Payroll.Models.Daos
{
    public class CatalogosDao { }

    public class CatalogoGeneralDao : Conexion
    {
        public List<CatalogoGeneralBean> sp_CatalogoGeneral_Consulta_CatalogoGeneral(int state, string type, int keycat, int keycam)
        {
            List<CatalogoGeneralBean> listCatGenBean = new List<CatalogoGeneralBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_CatalogoGeneral_Consulta_CatalogoGeneral", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlCancelado", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlId", keycat));
                cmd.Parameters.Add(new SqlParameter("@ctrlCampoCatalogoId", keycam));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        CatalogoGeneralBean catGenBean = new CatalogoGeneralBean();
                        catGenBean.iId = Convert.ToInt32(data["id"].ToString());
                        catGenBean.iCampoCatalogoId = Convert.ToInt32(data["Campos_Catalogo_Id"].ToString());
                        catGenBean.sValor = data["Valor"].ToString();
                        catGenBean.iIdValor = Convert.ToInt32(data["IdValor"].ToString());
                        if (keycat != 0)
                        {
                            catGenBean.sDescripcion = (String.IsNullOrEmpty(data["Descripcion"].ToString())) ? "Sin resultado" : data["Descripcion"].ToString();
                            catGenBean.iCancelado = Convert.ToInt32(data["Cancelado"].ToString());
                            catGenBean.iIdUsuAlta = Convert.ToInt32(data["UsuAlta_id"].ToString());
                            catGenBean.sFechaAlta = data["FechaAlta"].ToString();
                        }
                        listCatGenBean.Add(catGenBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listCatGenBean;
        }
    }

    public class InfDomicilioDao : Conexion
    {

        public List<InfDomicilioBean> sp_CatalogoGeneral_Retrieve_CatalogoGeneral(int catalogid)
        {
            List<InfDomicilioBean> listInfDomBean = new List<InfDomicilioBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_CatalogoGeneral_Retrieve_CatalogoGeneral", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlCatalogoId", catalogid));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        InfDomicilioBean infDomBean = new InfDomicilioBean();
                        infDomBean.iIdValor = Convert.ToInt32(data["IdValor"].ToString());
                        infDomBean.sValor = data["Valor"].ToString();
                        infDomBean.iId = Convert.ToInt32(data["id"].ToString());
                        listInfDomBean.Add(infDomBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listInfDomBean;
        }

        public List<InfDomicilioBean> sp_Domicilio_Retrieve_Domicilio(int codepost, int state)
        {
            List<InfDomicilioBean> listInfDomBean = new List<InfDomicilioBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Domicilio_Retrieve_Domicilio", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlCodigoPostal", codepost));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEstado", state));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        InfDomicilioBean infDomBean = new InfDomicilioBean();
                        infDomBean.sCiudad = data["Ciudad"].ToString();
                        infDomBean.iIdColonia = Convert.ToInt32(data["IdColonia"].ToString());
                        infDomBean.sColonia = data["Colonia"].ToString();
                        infDomBean.iIdMunicipio = Convert.ToInt32(data["IdMunicipio"].ToString());
                        listInfDomBean.Add(infDomBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listInfDomBean;
        }
        public List<InfoDireccionByCPBean> sp_Domicilio_Retrieve_Domicilio2(int codepost)
        {
            List<InfoDireccionByCPBean> listInfDomBean = new List<InfoDireccionByCPBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Domicilio_Retrieve_Domicilio2", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlCodigoPostal", codepost));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        InfoDireccionByCPBean infDomBean = new InfoDireccionByCPBean();
                        if (data["Ciudad"].ToString() == "" || data["Ciudad"].ToString().Length == 0 || data["Ciudad"] == null)
                        {    infDomBean.sCiudad = "Sin Ciudad";    }    
                        else    {   infDomBean.sCiudad = data["Ciudad"].ToString();    }
                        infDomBean.iIdColonia = int.Parse(data["IdColonia"].ToString());
                        infDomBean.sColonia = data["Colonia"].ToString();
                        infDomBean.iIdMunicipio = int.Parse(data["IdMunicipio"].ToString());
                        infDomBean.sMunicipio = data["Municipio"].ToString();
                        infDomBean.sEstado = data["Estado"].ToString();
                        infDomBean.iIdEstado = int.Parse(data["IdEstado"].ToString());
                        listInfDomBean.Add(infDomBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listInfDomBean;
        }

    }

    public class NivelEstudiosDao : Conexion
    {
        public List<NivelEstudiosBean> sp_NivelEstudios_Retrieve_NivelEstudios(int state, string type, int keynivel)
        {
            List<NivelEstudiosBean> listNivEstBean = new List<NivelEstudiosBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_NivelEstudios_Retrieve_NivelEstudios", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoNivelEstudio", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdNivelEstudio", keynivel));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        NivelEstudiosBean nivEstBean = new NivelEstudiosBean();
                        nivEstBean.iIdNivelEstudio = Convert.ToInt32(data["IdNivelEstudio"].ToString());
                        nivEstBean.sNombreNivelEstudio = data["NombreNivelEstudio"].ToString();
                        if (keynivel != 0)
                        {
                            nivEstBean.iEstadoNivelEstudio = Convert.ToInt32(data["EstadoNivelEstudio"].ToString());
                            nivEstBean.sUsuarioRegistroNivel = data["UsuarioRegistroNivel"].ToString();
                            nivEstBean.sFechaRegistroNivel = data["FechaRegistroNivel"].ToString();
                            nivEstBean.sUsuarioModificaNivel = (String.IsNullOrEmpty(data["UsuarioModificaNivel"].ToString())) ? "Sin resultado" : data["UsuarioModificaNivel"].ToString();
                            nivEstBean.sFechaModificaNivel = (String.IsNullOrEmpty(data["FechaModificaNivel"].ToString())) ? "Sin resultado" : data["FechaModificaNivel"].ToString();
                        }
                        listNivEstBean.Add(nivEstBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listNivEstBean;
        }
    }

    public class TabuladoresDao : Conexion
    {
        public List<TabuladoresBean> sp_Tabuladores_Retrieve_Tabuladores(int state, string type, int keytab)
        {
            List<TabuladoresBean> listTabBean = new List<TabuladoresBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Tabuladores_Retrieve_Tabuladores", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoTabulador", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdTabulador", keytab));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        TabuladoresBean tabBean = new TabuladoresBean();
                        tabBean.iIdTabulador = Convert.ToInt32(data["IdTabulador"].ToString());
                        tabBean.sTabulador = data["Tabulador"].ToString();
                        if (keytab > 0)
                        {
                            tabBean.iEstadoTabulador = Convert.ToInt32(data["EstadoTabulador"].ToString());
                            tabBean.sUsuarioRegistroTabulador = data["UsuarioRegistroTabulador"].ToString();
                            tabBean.sFechaRegistroTabulador = data["FechaRegistroTabulador"].ToString();
                            tabBean.sUsuarioModificaTabulador = (String.IsNullOrEmpty(data["UsuarioModificaTabulador"].ToString())) ? "Sin resultado" : data["UsuarioModificaTabulador"].ToString();
                            tabBean.sFechaModificaTabulador = (String.IsNullOrEmpty(data["FechaModificaTabulador"].ToString())) ? "Sin resultado" : data["FechaModificaTabulador"].ToString();
                        }
                        listTabBean.Add(tabBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listTabBean;
        }
    }

    public class BancosDao : Conexion
    {
        public List<BancosBean> sp_Bancos_Retrieve_Bancos(int state, string type, int keyban)
        {
            List<BancosBean> listBanBean = new List<BancosBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Bancos_Retrieve_Bancos", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoBanco", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdBanco", keyban));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        BancosBean banBean = new BancosBean();
                        banBean.iIdBanco = Convert.ToInt32(data["IdBanco"].ToString());
                        banBean.sNombreBanco = data["NombreBanco"].ToString();
                        banBean.iClave = Convert.ToInt32(data["Clave"].ToString());
                        if (keyban != 0)
                        {
                            banBean.iEstadoBanco = Convert.ToInt32(data["EstadoBanco"].ToString());
                            banBean.sUsuarioRegistroBanco = data["UsuarioRegistroBanco"].ToString();
                            banBean.sFechaRegistroBanco = data["FechaRegistroBanco"].ToString();
                            banBean.sUsuarioModificaBanco = (String.IsNullOrEmpty(data["UsuarioModificaBanco"].ToString())) ? "Sin resultado"
                                : data["UsuarioModificaBanco"].ToString();
                            banBean.sFechaModificaBanco = (String.IsNullOrEmpty(data["FechaModificaBanco"].ToString())) ? "Sin resultado"
                                : data["FechaModificaBanco"].ToString();
                        }
                        listBanBean.Add(banBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listBanBean;
        }
    }

    public class PuestosDao : Conexion
    {
        public List<PuestosBean> sp_Puestos_Retrieve_Puestos(int state, string type, int keyjob, int keyemp)
        {
            List<PuestosBean> listPuestoBean = new List<PuestosBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Puestos_Retrieve_Puestos", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoPuesto", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdPuesto", keyjob));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpresa", keyemp));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        PuestosBean puestoBean = new PuestosBean();
                        puestoBean.iIdPuesto = Convert.ToInt32(data["IdPuesto"].ToString());
                        puestoBean.sNombrePuesto = data["NombrePuesto"].ToString();
                        puestoBean.sDescripcionPuesto = data["DescripcionPuesto"].ToString();
                        puestoBean.iIdProfesionFamilia = Convert.ToInt32(data["ProfesionFamilia_id"].ToString());
                        puestoBean.iIdEtiquetaContable = Convert.ToInt32(data["EtiquetaContable_id"].ToString());
                        puestoBean.iIdClasificacionPuesto = Convert.ToInt32(data["ClasificacionPuesto_id"].ToString());
                        puestoBean.iIdColectivo = Convert.ToInt32(data["Colectivo_id"].ToString());
                        puestoBean.iIdClaveSat = Convert.ToInt32(data["ClaveSat_id"].ToString());
                        puestoBean.iIdNivelJerarquico = Convert.ToInt32(data["NivelJerarquico_id"].ToString());
                        puestoBean.iIdPerfomanceManager = Convert.ToInt32(data["PerfomanceManager_id"].ToString());
                        puestoBean.iIdTabulador = Convert.ToInt32(data["Tabulador_id"].ToString());
                        puestoBean.sSindicato = data["Sindicato"].ToString();
                        puestoBean.sGradoDominio = data["GradoDominio"].ToString();
                        puestoBean.sTarjetaPres = data["TarjetasPresentacion"].ToString();
                        if (keyjob != 0)
                        {
                            puestoBean.iEstadoPuesto = Convert.ToInt32(data["EstadoPuesto"].ToString());
                            puestoBean.sUsuarioRegistroPuesto = data["UsuarioRegistroPuesto"].ToString();
                            puestoBean.sFechaRegistroPuesto = data["FechaRegistroPuesto"].ToString();
                        }
                        listPuestoBean.Add(puestoBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listPuestoBean;
        }
    }

    public class ProfesionesFamiliaDao : Conexion
    {
        public List<ProfesionesFamiliaBean> sp_ProfesionesFamilia_Retrieve_ProfesionesFamilia(int state, string type, int keyprof)
        {
            List<ProfesionesFamiliaBean> listProfFamilyBean = new List<ProfesionesFamiliaBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_ProfesionesFamilia_Retrieve_ProfesionesFamilia", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoProfesion", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdProfesion", keyprof));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        ProfesionesFamiliaBean profFamilyBean = new ProfesionesFamiliaBean();
                        profFamilyBean.iIdProfesionFamilia = Convert.ToInt32(data["IdProfesionFamilia"].ToString());
                        profFamilyBean.sNombreProfesion = data["NombreProfesion"].ToString();
                        if (keyprof != 0)
                        {
                            profFamilyBean.iEstadoProfesion = Convert.ToInt32(data["EstadoProfesion"].ToString());
                            profFamilyBean.sUsuarioRegistroProfesion = data["UsuarioRegistroProfesion"].ToString();
                            profFamilyBean.sFechaRegistroProfesoin = data["FechaRegistroProfesion"].ToString();
                        }
                        listProfFamilyBean.Add(profFamilyBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listProfFamilyBean;
        }
    }

    public class EtiquetasContablesDao : Conexion
    {
        public List<EtiquetasContablesBean> sp_EtiquetasContables_Retrieve_EtiquetasContables(int state, string type, int keytag)
        {
            List<EtiquetasContablesBean> listTagContBean = new List<EtiquetasContablesBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_EtiquetasContables_Retrieve_EtiquetasContables", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoEtiqueta", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEtiquetaContable", keytag));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        EtiquetasContablesBean tagContBean = new EtiquetasContablesBean();
                        tagContBean.iIdEtiquetaContable = Convert.ToInt32(data["IdEtiquetaContable"].ToString());
                        tagContBean.sNombreEtiquetaContable = data["NombreEtiquetaContable"].ToString();
                        if (keytag != 0)
                        {
                            tagContBean.iEstadoEtiquetaContable = Convert.ToInt32(data["EstadoEtiquetaContable"].ToString());
                            tagContBean.sUsuarioRegistroEtiqueta = data["UsuarioRegistroEtiqueta"].ToString();
                            tagContBean.sFechaRegistroEtiqueta = data["FechaRegistroEtiqueta"].ToString();
                        }
                        listTagContBean.Add(tagContBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listTagContBean;
        }
    }

    public class NivelJerarDao : Conexion
    {
        public List<NivelJerarBean> sp_NivelJerarquico_Retrieve_NivelJerarquico(int state, string type, int keyniv)
        {
            List<NivelJerarBean> listNivJerarBean = new List<NivelJerarBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_NivelJerarquico_Retrieve_NivelJerarquico", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoNivel", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdNivelJerarquico", keyniv));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        NivelJerarBean nivJerarBean = new NivelJerarBean();
                        nivJerarBean.iIdNivelJerarquico = Convert.ToInt32(data["IdNivelJerarquico"].ToString());
                        nivJerarBean.sNombreNivelJerarquico = data["NombreNivelJerarquico"].ToString();
                        if (keyniv != 0)
                        {
                            nivJerarBean.iEstadoNivelJerarquico = Convert.ToInt32(data["EstadoNivelJerarquico"].ToString());
                            nivJerarBean.sUsuarioRegistroNivel = data["UsuarioRegistroNivel"].ToString();
                            nivJerarBean.sFechaRegistroNivel = data["FechaRegistroNivel"].ToString();
                        }
                        listNivJerarBean.Add(nivJerarBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listNivJerarBean;
        }
    }

    public class PerfomanceManagerDao : Conexion
    {
        public List<PerfomanceManagerBean> sp_PerfomanceManager_Retrieve_PerfomanceManager(int state, string type, int keyper)
        {
            List<PerfomanceManagerBean> listPerfManBean = new List<PerfomanceManagerBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_PerfomanceManager_Retrieve_PerfomanceManager", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoPerfomance", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdPerfomance", keyper));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        PerfomanceManagerBean perfManBean = new PerfomanceManagerBean();
                        perfManBean.iIdPerfomanceManager = Convert.ToInt32(data["IdPerfomanceManager"].ToString());
                        perfManBean.sPerfomanceManager = data["PerfomanceManager"].ToString();
                        if (keyper != 0)
                        {
                            perfManBean.iEstadoPerfomance = Convert.ToInt32(data["EstadoPerfomance"].ToString());
                            perfManBean.sUsuarioRegistroPerfomance = data["UsuarioRegistroPerfomance"].ToString();
                            perfManBean.sFechaRegistroPerfomance = data["FechaRegistroPerfomance"].ToString();
                        }
                        listPerfManBean.Add(perfManBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listPerfManBean;
        }
    }

    public class EmpresasDao : Conexion
    {
        public List<EmpresasBean> sp_Empresas_Retrieve_Empresas(bool state, string type, int keyemp)
        {
            List<EmpresasBean> listEmpresasBean = new List<EmpresasBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Empresas_Retrieve_Empresas", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoEmpresa", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpresa", keyemp));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        EmpresasBean empresaBean = new EmpresasBean();
                        empresaBean.iIdEmpresa = Convert.ToInt32(data["IdEmpresa"].ToString());
                        empresaBean.sNombreEmpresa = data["NombreEmpresa"].ToString();
                        if (keyemp != 0)
                        {
                            empresaBean.iEstadoEmpresa = Convert.ToInt32(data["EstadoEmpresa"].ToString());
                            empresaBean.sUsuarioRegistro = data["UsuarioRegistroEmpresa"].ToString();
                            empresaBean.sFechaRegistro = data["FechaRegistroEmpres"].ToString();
                        }
                        listEmpresasBean.Add(empresaBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listEmpresasBean;
        }
    }

    public class CentrosCostosDao : Conexion
    {
        public List<CentrosCostosBean> sp_CentrosCostos_Retrieve_CentrosCostos(int state, string type, int keycos)
        {
            List<CentrosCostosBean> listCentrosCostosBean = new List<CentrosCostosBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_CentrosCostos_Retrieve_CentrosCostos", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoCentro", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdCentroCosto", keycos));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        CentrosCostosBean centroCostoBean = new CentrosCostosBean();
                        centroCostoBean.iIdCentroCosto = Convert.ToInt32(data["IdCentroCosto"].ToString());
                        centroCostoBean.sCentroCosto = data["CentroCosto"].ToString();
                        centroCostoBean.sDescripcionCentroCosto = data["DescripcionCentroCosto"].ToString();
                        if (keycos != 0)
                        {
                            centroCostoBean.iIdEmpresa = Convert.ToInt32(data["Empresa_id"].ToString());
                            centroCostoBean.iEstadoCentroCosto = Convert.ToInt32(data["EstadoCentroCosto"].ToString());
                            centroCostoBean.sUsuarioRegistroCentro = data["UsuarioRegistroCentro"].ToString();
                            centroCostoBean.sFechaRegistroCentro = data["FechaRegistroCentro"].ToString();
                        }
                        listCentrosCostosBean.Add(centroCostoBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listCentrosCostosBean;
        }
    }

    public class EdificiosDao : Conexion
    {
        public List<EdificiosBean> sp_Edificios_Retrieve_Edificios(int state, string type, int keyedi)
        {
            List<EdificiosBean> listEdificiosBean = new List<EdificiosBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Edificios_Retrieve_Edificios", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoEdificio", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEdificio", keyedi));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        EdificiosBean edificioBean = new EdificiosBean();
                        edificioBean.iIdEdificio = Convert.ToInt32(data["IdEdificio"].ToString());
                        edificioBean.sNombreEdificio = data["NombreEdificio"].ToString();
                        if (keyedi != 0)
                        {
                            edificioBean.iEstadoEdificio = Convert.ToInt32(data["EstadoEdificio"].ToString());
                            edificioBean.sUsuarioRegistraEdificio = data["UsuarioRegistraEdificio"].ToString();
                            edificioBean.sFechaRegistroEdificio = data["FechaRegistroEdificio"].ToString();
                        }
                        listEdificiosBean.Add(edificioBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listEdificiosBean;
        }
    }

    public class NivelEstructuraDao : Conexion
    {
        public List<NivelEstructuraBean> sp_NivelEstructura_Retrieve_NivelEstructura(int state, string type, int keyniv)
        {
            List<NivelEstructuraBean> listNivelEstructuraBean = new List<NivelEstructuraBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_NivelEstructura_Retrieve_NivelEstructura", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstadoNivel", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdNivel", keyniv));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        NivelEstructuraBean nivelEstructuraBean = new NivelEstructuraBean();
                        nivelEstructuraBean.iIdNivelEstructura = Convert.ToInt32(data["IdNivelEstructura"].ToString());
                        nivelEstructuraBean.sNivelEstructura = data["NivelEstructura"].ToString();
                        if (keyniv != 0)
                        {
                            nivelEstructuraBean.iEstadoNivelEstructura = Convert.ToInt32(data["EstadoNivelEstructura"].ToString());
                            nivelEstructuraBean.sUsuarioRegistraNivel = data["UsuarioRegistraNivel"].ToString();
                            nivelEstructuraBean.sFechaRegistraNivel = data["FechaRegistraNivel"].ToString();
                        }
                        listNivelEstructuraBean.Add(nivelEstructuraBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listNivelEstructuraBean;
        }
    }

    public class DepartamentosDao : Conexion
    {
        public List<DepartamentosBean> sp_Departamentos_Retrieve_Departamentos(int state, string type, int keydep)
        {
            List<DepartamentosBean> listDepartamentosBean = new List<DepartamentosBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Departamentos_Retrieve_Departamentos", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEstado", state));
                cmd.Parameters.Add(new SqlParameter("@ctrlTipoFiltro", type));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdDepartamento", keydep));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        DepartamentosBean departamentosBean = new DepartamentosBean();
                        departamentosBean.iIdDepartamento = Convert.ToInt32(data["IdDepartamento"].ToString());
                        departamentosBean.iCentroCosto_id = Convert.ToInt32(data["CentroCosto_id"].ToString());
                        departamentosBean.iNivelEstructura_id = Convert.ToInt32(data["NivelEstructura_id"].ToString());
                        departamentosBean.iEdificio_id = Convert.ToInt32(data["Edificio_id"].ToString());
                        departamentosBean.sDepartamento = data["Departamento"].ToString();
                        departamentosBean.sEmpresa = data["NombreEmpresa"].ToString();
                        departamentosBean.sDescripcionDepartamento = data["DescripcionDepartamento"].ToString();
                        departamentosBean.iEmpresaReporta_id = Convert.ToInt32(data["EmpresaReporta_id"].ToString());
                        departamentosBean.sUbicacion = data["Ubicacion"].ToString();
                        departamentosBean.sPlaza = data["Plaza"].ToString();
                        departamentosBean.sTitular = data["Titular"].ToString();
                        departamentosBean.sSucursalBancaria = data["SucursalBancaria"].ToString();
                        departamentosBean.sCategoria = data["Categoria"].ToString();
                        if (keydep != 0)
                        {
                            departamentosBean.iEstadoDepartamento = Convert.ToInt32(data["EstadoDepartamento"].ToString());
                            departamentosBean.sUsuarioRegistroDepartamento = data["UsuarioRegistroDepartamento"].ToString();
                            departamentosBean.sFechaRegistroDepartamento = data["FechaRegistroDepartamento"].ToString();
                        }
                        listDepartamentosBean.Add(departamentosBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listDepartamentosBean;
        }
    }

}