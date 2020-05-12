using Payroll.Models.Beans;
using Payroll.Models.Utilerias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
                        { infDomBean.sCiudad = "Sin Ciudad"; }
                        else { infDomBean.sCiudad = data["Ciudad"].ToString(); }
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
        public List<BancosBean> sp_Bancos_Retrieve_Bancos(int keyban)
        {
            List<BancosBean> listBanBean = new List<BancosBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Bancos_Retrieve_Bancos", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdBanco", keyban));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        BancosBean banBean = new BancosBean();
                        banBean.iIdBanco = Convert.ToInt32(data["IdBanco"].ToString());
                        banBean.sNombreBanco = data["Descripcion"].ToString();
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
                SqlCommand cmd = new SqlCommand("sp_Empresas_RetrieveFiltro_Empresas", this.conexion)
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

<<<<<<< HEAD
=======
        public List<LocalidadesBean2> sp_Localidades_Retrieve_Search_Localidades(string wordsearch, int keyemp)
        {
            List<LocalidadesBean2> listLocalidadesBean = new List<LocalidadesBean2>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Localidades_Retrieve_Search_Localidades", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlWordSearch", wordsearch));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpresa", keyemp));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        LocalidadesBean2 localidadBean = new LocalidadesBean2();
                        localidadBean.iIdLocalidad = Convert.ToInt32(data["IdLocalidad"].ToString());
                        localidadBean.iIdEmpresa = Convert.ToInt32(data["Empresa_id"].ToString());
                        localidadBean.iCodigoLocalidad = Convert.ToInt32(data["Codigo_Localidad"].ToString());
                        localidadBean.sDescripcion = data["Descripcion"].ToString();
                        localidadBean.sRegistroPatronal = data["Afiliacion_IMSS"].ToString();
                        //localidadBean.dTazIva = Convert.ToDouble(data["TasaIva"].ToString());
                        if (data["RegistroPatronal_id"].ToString().Length != 0)
                        {
                            localidadBean.iRegistroPatronal_id = Convert.ToInt32(data["RegistroPatronal_id"].ToString());
                        }
                        else
                        {
                            localidadBean.iRegistroPatronal_id = 0;
                        }
                        if (data["Regional_id"].ToString().Length != 0)
                        {
                            localidadBean.iRegional_id = Convert.ToInt32(data["Regional_id"].ToString());
                        }
                        else
                        {
                            localidadBean.iRegional_id = 0;
                        }
                        if (data["ZonaEconomica_id"].ToString().Length != 0)
                        {
                            localidadBean.iZonaEconomica_id = Convert.ToInt32(data["ZonaEconomica_id"].ToString());
                        }
                        else
                        {
                            localidadBean.iZonaEconomica_id = 0;
                        }
                        if (data["Sucursal_id"].ToString().Length != 0)
                        {
                            localidadBean.iSucursal_id = Convert.ToInt32(data["Sucursal_id"].ToString());
                        }
                        else
                        {
                            localidadBean.iSucursal_id = 0;
                        }
                        if (data["Cg_Estado_id"].ToString().Length != 0)
                        {
                            localidadBean.iEstado_id = Convert.ToInt32(data["Cg_Estado_id"].ToString());
                        }
                        else
                        {
                            localidadBean.iEstado_id = 0;
                        }
                        listLocalidadesBean.Add(localidadBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                string origenerror = "CatalogosDao";
                string mensajeerror = exc.ToString();
                CapturaErroresBean capturaErrorBean = new CapturaErroresBean();
                CapturaErrores capturaErrorDao = new CapturaErrores();
                capturaErrorBean = capturaErrorDao.sp_Errores_Insert_Errores(origenerror, mensajeerror);
                Console.WriteLine(exc);
            }
            return listLocalidadesBean;
        }

        public List<LocalidadesBean2> sp_TLocalicades_Retrieve_Localidades(int keyemp)
        {
            List<LocalidadesBean2> listLocalidadesBean = new List<LocalidadesBean2>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_TLocalicades_Retrieve_Localidades", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrliIdEmpresa", keyemp));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        LocalidadesBean2 localidadBean = new LocalidadesBean2();
                        localidadBean.iIdLocalidad = Convert.ToInt32(data["IdLocalidad"].ToString());
                        localidadBean.iIdEmpresa = Convert.ToInt32(data["Empresa_id"].ToString());
                        localidadBean.iCodigoLocalidad = Convert.ToInt32(data["Codigo_Localidad"].ToString());
                        localidadBean.sDescripcion = data["Descripcion"].ToString();
                        localidadBean.dTazIva = Convert.ToDouble(data["TasaIva"].ToString());
                        if (data["RegistroPatronal_id"].ToString().Length != 0)
                        {
                            localidadBean.iRegistroPatronal_id = Convert.ToInt32(data["RegistroPatronal_id"].ToString());
                        }
                        else
                        {
                            localidadBean.iRegistroPatronal_id = 0;
                        }
                        if (data["Regional_id"].ToString().Length != 0)
                        {
                            localidadBean.iRegional_id = Convert.ToInt32(data["Regional_id"].ToString());
                        }
                        else
                        {
                            localidadBean.iRegional_id = 0;
                        }
                        if (data["ZonaEconomica_id"].ToString().Length != 0)
                        {
                            localidadBean.iZonaEconomica_id = Convert.ToInt32(data["ZonaEconomica_id"].ToString());
                        }
                        else
                        {
                            localidadBean.iZonaEconomica_id = 0;
                        }
                        if (data["Sucursal_id"].ToString().Length != 0)
                        {
                            localidadBean.iSucursal_id = Convert.ToInt32(data["Sucursal_id"].ToString());
                        }
                        else
                        {
                            localidadBean.iSucursal_id = 0;
                        }
                        if (data["Cg_Estado_id"].ToString().Length != 0)
                        {
                            localidadBean.iEstado_id = Convert.ToInt32(data["Cg_Estado_id"].ToString());
                        }
                        else
                        {
                            localidadBean.iEstado_id = 0;
                        }
                        listLocalidadesBean.Add(localidadBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                string origenerror = "CatalogosDao";
                string mensajeerror = exc.ToString();
                CapturaErroresBean capturaErrorBean = new CapturaErroresBean();
                CapturaErrores capturaErrorDao = new CapturaErrores();
                capturaErrorBean = capturaErrorDao.sp_Errores_Insert_Errores(origenerror, mensajeerror);
                Console.WriteLine(exc);
            }
            return listLocalidadesBean;
        }
    }
    public class RegistroPatronalDao : Conexion
    {
        public List<RegistroPatronalBean2> sp_Registro_Patronal_Retrieve_Registros_Patronales(int keyemp)
        {
            List<RegistroPatronalBean2> listRegPatronal = new List<RegistroPatronalBean2>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Registro_Patronal_Retrieve_Registros_Patronales", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrliEmpresa_id", keyemp));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        RegistroPatronalBean2 regPatronal = new RegistroPatronalBean2();
                        regPatronal.iIdRegPat = Convert.ToInt32(data["IdRegPat"].ToString());
                        regPatronal.iEmpresaid = Convert.ToInt32(data["Empresa_id"].ToString());
                        regPatronal.sAfiliacionIMSS = data["Afiliacion_IMSS"].ToString();
                        regPatronal.sNombreAfiliacion = data["Nombre_Afiliacion"].ToString();
                        regPatronal.sRiesgoTrabajo = data["Riesgo_Trabajo"].ToString();
                        regPatronal.iClasesRegPat_id = Convert.ToInt32(data["ClasesRegPat_id"].ToString());
                        regPatronal.sCancelado = data["Cancelado"].ToString();
                        listRegPatronal.Add(regPatronal);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                string origenerror = "CatalogosDao";
                string mensajeerror = exc.ToString();
                CapturaErroresBean capturaErrorBean = new CapturaErroresBean();
                CapturaErrores capturaErrorDao = new CapturaErrores();
                capturaErrorBean = capturaErrorDao.sp_Errores_Insert_Errores(origenerror, mensajeerror);
                Console.WriteLine(exc);
            }
            return listRegPatronal;
        }
    }
    public class RegionesDao : Conexion
    {
        public List<RegionalesBean> sp_Regionales_Retrieve_Search_Regionales(string wordsearch, int keyemp)
        {
            List<RegionalesBean> listRegionalesBean = new List<RegionalesBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Regionales_Retrieve_Search_Regionales", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlWordSearch", wordsearch));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpresa", keyemp));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        RegionalesBean regionalBean = new RegionalesBean();
                        regionalBean.iIdRegional = Convert.ToInt32(data["IdRegional"].ToString());
                        regionalBean.iEmpresaId = Convert.ToInt32(data["Empresa_id"].ToString());
                        regionalBean.sDescripcionRegional = data["Descripcion_Regional"].ToString();
                        regionalBean.sClaveRegional = data["Clave_Regional"].ToString();
                        regionalBean.iUsuarioAltaId = Convert.ToInt32(data["Usuario_Alta_Id"].ToString());
                        regionalBean.sFechaAlta = data["Fecha_Alta"].ToString();
                        listRegionalesBean.Add(regionalBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                string origenerror = "CatalogosDao";
                string mensajeerror = exc.ToString();
                CapturaErroresBean capturaErrorBean = new CapturaErroresBean();
                CapturaErrores capturaErrorDao = new CapturaErrores();
                capturaErrorBean = capturaErrorDao.sp_Errores_Insert_Errores(origenerror, mensajeerror);
                Console.WriteLine(exc);
            }
            return listRegionalesBean;
        }

        public RegionalesBean sp_Regionales_Retrieve_Regional(int clvregion)
        {
            RegionalesBean regionalBean = new RegionalesBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Regionales_Retrieve_Regional", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdRegional", clvregion));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    regionalBean.iIdRegional = Convert.ToInt32(data["IdRegional"].ToString());
                    regionalBean.iEmpresaId = Convert.ToInt32(data["Empresa_id"].ToString());
                    regionalBean.sDescripcionRegional = data["Descripcion_Regional"].ToString();
                    regionalBean.sClaveRegional = data["Clave_Regional"].ToString();
                    regionalBean.iUsuarioAltaId = Convert.ToInt32(data["Usuario_Alta_Id"].ToString());
                    regionalBean.sFechaAlta = data["Fecha_Alta"].ToString();
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                string origenerror = "CatalogosDao";
                string mensajeerror = exc.ToString();
                CapturaErroresBean capturaErrorBean = new CapturaErroresBean();
                CapturaErrores capturaErrorDao = new CapturaErrores();
                capturaErrorBean = capturaErrorDao.sp_Errores_Insert_Errores(origenerror, mensajeerror);
                Console.WriteLine(exc);
            }
            return regionalBean;
        }
        public List<RegionalesBean> sp_Regionales_Retrieve_Regionales()
        {
            List<RegionalesBean> listRegionalesBean = new List<RegionalesBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Regionales_Retrieve_Regionales", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        RegionalesBean regionalBean = new RegionalesBean();
                        regionalBean.iIdRegional = Convert.ToInt32(data["IdRegional"].ToString());
                        regionalBean.sDescripcionRegional = data["Descripcion_Regional"].ToString();
                        regionalBean.sClaveRegional = data["Clave_Regional"].ToString();
                        regionalBean.iUsuarioAltaId = Convert.ToInt32(data["Usuario_Alta_Id"].ToString());
                        regionalBean.sFechaAlta = data["Fecha_Alta"].ToString();
                        listRegionalesBean.Add(regionalBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                string origenerror = "CatalogosDao";
                string mensajeerror = exc.ToString();
                CapturaErroresBean capturaErrorBean = new CapturaErroresBean();
                CapturaErrores capturaErrorDao = new CapturaErrores();
                capturaErrorBean = capturaErrorDao.sp_Errores_Insert_Errores(origenerror, mensajeerror);
                Console.WriteLine(exc);
            }
            return listRegionalesBean;
        }

        public RegionalesBean sp_Regionales_Insert_Regionales(string descregion, string claregion, int usuario, int keyemp)
        {
            RegionalesBean regionBean = new RegionalesBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Regionales_Insert_Regionales", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlDescripcion", descregion));
                cmd.Parameters.Add(new SqlParameter("@ctrlClaveRegion", claregion));
                cmd.Parameters.Add(new SqlParameter("@ctrlUsuario", usuario));
                cmd.Parameters.Add(new SqlParameter("@ctrlIdEmpresa", keyemp));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    regionBean.sMensaje = "success";
                }
                else
                {
                    regionBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); conexion.Close();
            }
            catch (Exception exc)
            {
                string origenerror = "CatalogosDao";
                string mensajeerror = exc.ToString();
                CapturaErroresBean capturaErrorBean = new CapturaErroresBean();
                CapturaErrores capturaErrorDao = new CapturaErrores();
                capturaErrorBean = capturaErrorDao.sp_Errores_Insert_Errores(origenerror, mensajeerror);
                Console.WriteLine(exc);
            }
            return regionBean;
        }
    }
    public class SucursalesDao : Conexion
    {

        public List<SucursalesBean> sp_Sucursales_Retrieve_Search_Sucursales(string wordsearch)
        {
            List<SucursalesBean> listSucursalesBean = new List<SucursalesBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Sucursales_Retrieve_Search_Sucursales", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlWordSearch", wordsearch));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        SucursalesBean sucursalBean = new SucursalesBean();
                        sucursalBean.iIdSucursal = Convert.ToInt32(data["IdSucursal"].ToString());
                        sucursalBean.sDescripcionSucursal = data["Descripcion_Sucursal"].ToString();
                        sucursalBean.sClaveSucursal = data["Clave_Sucursal"].ToString();
                        sucursalBean.iUsuarioAltaId = Convert.ToInt32(data["Usuario_Alta_Id"].ToString());
                        sucursalBean.sFechaAlta = data["Fecha_Alta"].ToString();
                        listSucursalesBean.Add(sucursalBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                string origenerror = "CatalogosDao";
                string mensajeerror = exc.ToString();
                CapturaErroresBean capturaErrorBean = new CapturaErroresBean();
                CapturaErrores capturaErrorDao = new CapturaErrores();
                capturaErrorBean = capturaErrorDao.sp_Errores_Insert_Errores(origenerror, mensajeerror);
                Console.WriteLine(exc);
            }
            return listSucursalesBean;
        }

        public SucursalesBean sp_Sucursales_Retrieve_Sucursal(int clvsucursal)
        {
            SucursalesBean sucursalBean = new SucursalesBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Sucursales_Retrieve_Sucursal", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlIdSucursal", clvsucursal));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    sucursalBean.iIdSucursal = Convert.ToInt32(data["IdSucursal"].ToString());
                    sucursalBean.sDescripcionSucursal = data["Descripcion_Sucursal"].ToString();
                    sucursalBean.sClaveSucursal = data["Clave_Sucursal"].ToString();
                    sucursalBean.iUsuarioAltaId = Convert.ToInt32(data["Usuario_Alta_Id"].ToString());
                    sucursalBean.sFechaAlta = data["Fecha_Alta"].ToString();
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                string origenerror = "CatalogosDao";
                string mensajeerror = exc.ToString();
                CapturaErroresBean capturaErrorBean = new CapturaErroresBean();
                CapturaErrores capturaErrorDao = new CapturaErrores();
                capturaErrorBean = capturaErrorDao.sp_Errores_Insert_Errores(origenerror, mensajeerror);
                Console.WriteLine(exc);
            }
            return sucursalBean;
        }
        public List<SucursalesBean> sp_Sucursales_Retrieve_Sucursales()
        {
            List<SucursalesBean> listSucursalesBean = new List<SucursalesBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Sucursales_Retrieve_Sucursales", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        SucursalesBean sucursalBean = new SucursalesBean();
                        sucursalBean.iIdSucursal = Convert.ToInt32(data["IdSucursal"].ToString());
                        sucursalBean.sDescripcionSucursal = data["Descripcion_Sucursal"].ToString();
                        sucursalBean.sClaveSucursal = data["Clave_Sucursal"].ToString();
                        sucursalBean.iUsuarioAltaId = Convert.ToInt32(data["Usuario_Alta_Id"].ToString());
                        sucursalBean.sFechaAlta = data["Fecha_Alta"].ToString();
                        listSucursalesBean.Add(sucursalBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                string origenerror = "CatalogosDao";
                string mensajeerror = exc.ToString();
                CapturaErroresBean capturaErrorBean = new CapturaErroresBean();
                CapturaErrores capturaErrorDao = new CapturaErrores();
                capturaErrorBean = capturaErrorDao.sp_Errores_Insert_Errores(origenerror, mensajeerror);
                Console.WriteLine(exc);
            }
            return listSucursalesBean;
        }

        public SucursalesBean sp_Sucursales_Insert_Sucursales(string descsucursal, string clasucursal, int usuario)
        {
            SucursalesBean sucursalBean = new SucursalesBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Sucursales_Insert_Sucursales", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlDescripcion", descsucursal));
                cmd.Parameters.Add(new SqlParameter("@ctrlClaveSucursal", clasucursal));
                cmd.Parameters.Add(new SqlParameter("@ctrlUsuario", usuario));
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read()) {
                    if (data["sRespuesta"].ToString() == "") {
                        sucursalBean.sMensaje = "success";
                    } else {
                        sucursalBean.sMensaje = data["sRespuesta"].ToString();
                    }
                } else {
                    sucursalBean.sMensaje = "error";
                }
                cmd.Dispose(); cmd.Parameters.Clear(); conexion.Close();
            }
            catch (Exception exc)
            {
                string origenerror = "CatalogosDao";
                string mensajeerror = exc.ToString();
                CapturaErroresBean capturaErrorBean = new CapturaErroresBean();
                CapturaErrores capturaErrorDao = new CapturaErrores();
                capturaErrorBean = capturaErrorDao.sp_Errores_Insert_Errores(origenerror, mensajeerror);
                Console.WriteLine(exc);
            }
            return sucursalBean;
        }

    }
    public class NacionalidadesDao : Conexion
    {
        public List<NacionalidadesBean> sp_Nacionalidades_Retrieve_Nacionalidades()
        {
            List<NacionalidadesBean> listNacionBean = new List<NacionalidadesBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Nacionalidades_Retrieve_Nacionalidades", this.conexion) { CommandType = CommandType.StoredProcedure };
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        NacionalidadesBean nacionBean = new NacionalidadesBean();
                        nacionBean.iIdNacionalidad = Convert.ToInt32(data["IdNacionalidad"].ToString());
                        nacionBean.sDescripcion = data["Descripcion"].ToString();
                        listNacionBean.Add(nacionBean);
                    }
                }
                cmd.Dispose(); cmd.Parameters.Clear(); data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return listNacionBean;
        }
    }
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400
}