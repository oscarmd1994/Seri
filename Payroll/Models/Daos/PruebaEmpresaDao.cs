using Payroll.Models.Beans;
using Payroll.Models.Utilerias;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Payroll.Models.Daos
{
    public class PruebaEmpresaDao : Conexion
    {

        public List<PruebaEmpresaBean> sp_Retrieve_PruevaEmpresas()
        {
            List<PruebaEmpresaBean> list = new List<PruebaEmpresaBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Retrieve_pruevaEmpresas", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    PruebaEmpresaBean listEmpresas = new PruebaEmpresaBean
                    {
                        IdEmpresa = int.Parse(data["IdEmpresa"].ToString()),
                        NombreEmpresa = data["NombreEmpresa"].ToString()
                    };
                    list.Add(listEmpresas);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }
        public List<PruebaEmpresaBean> sp_Retrieve_NombreEmpresas()
        {
            List<PruebaEmpresaBean> list = new List<PruebaEmpresaBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Retrieve_pruevaEmpresas", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            //cmd.Parameters.Add(new SqlParameter("@ctrlNombreEmpresa", txt));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    PruebaEmpresaBean listEmpresas = new PruebaEmpresaBean
                    {
                        IdEmpresa = int.Parse(data["IdEmpresa"].ToString()),
                        RazonSocial = data["NombreEmpresa"].ToString(),
                        NombreEmpresa = data["NombreCorto"].ToString()
                    };
                    list.Add(listEmpresas);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }

        public int sp_Retrieve_ClaveEmpresa()
        {
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Retrieve_ClaveEmpresa", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            int ClaveEmpresa = 0;
            if (data.HasRows)
            {
                while (data.Read())
                {
                    ClaveEmpresa = int.Parse(data["max"].ToString());
                }
            }
            data.Close();
            return ClaveEmpresa + 1;
        }
        public List<PruebaEmpresaBean> sp_Retrieve_NombreEmpresa(int IdEmpresa)
        {
            List<PruebaEmpresaBean> list = new List<PruebaEmpresaBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Retrieve_pruevaEmpresas", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    PruebaEmpresaBean listEmpresas = new PruebaEmpresaBean
                    {
                        IdEmpresa = int.Parse(data["IdEmpresa"].ToString()),
                        RazonSocial = data["NombreEmpresa"].ToString(),
                        NombreEmpresa = data["NombreCorto"].ToString()
                    };
                    list.Add(listEmpresas);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }
        public List<string> sp_Insert_FirstStep_Empresas(string inNombre_empresa, string inNomCorto_empresa, string inRfc_empresa, string inGiro_empresa, int inCodigo_postal, int inEstado_empresa, int inMunicipio_empresa, string inCiudad_empresa, string inDelegacion, int inColonia_empresa, string inCalle_Empresa, int inUltimo_nomina, int inInicio_nomina, int inFinal_nomina, string inPeriodo_pago, string inPago, string inAfiliacionesIMSS, string inRiesgoTrabajo, int usuario_id)
        {
            List<string> res = new List<string>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Insert_FirstStep_Empresas", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlsNombreEmpresa", inNomCorto_empresa));
            cmd.Parameters.Add(new SqlParameter("@ctrlsRazonSocial", inNombre_empresa));
            cmd.Parameters.Add(new SqlParameter("@ctrliCodigoPostal", inCodigo_postal));
            cmd.Parameters.Add(new SqlParameter("@ctrliEstadoId", inEstado_empresa));
            cmd.Parameters.Add(new SqlParameter("@ctrliCiudad", inCiudad_empresa));
            cmd.Parameters.Add(new SqlParameter("@ctrliDelegacion", inDelegacion));
            cmd.Parameters.Add(new SqlParameter("@ctrlsColonia", inColonia_empresa));
            cmd.Parameters.Add(new SqlParameter("@ctrlsCalle", inCalle_Empresa));
            cmd.Parameters.Add(new SqlParameter("@ctrlsGiro", inGiro_empresa));
            cmd.Parameters.Add(new SqlParameter("@ctrlsRFC", inRfc_empresa));
            cmd.Parameters.Add(new SqlParameter("@ctrliNominaUltimo", inUltimo_nomina));
            cmd.Parameters.Add(new SqlParameter("@ctrliNominaInicial", inInicio_nomina));
            cmd.Parameters.Add(new SqlParameter("@ctrliNominaFinal", inFinal_nomina));
            cmd.Parameters.Add(new SqlParameter("@ctrlsSueldoPeriodo", inPeriodo_pago));
            cmd.Parameters.Add(new SqlParameter("@ctrlsPagoSueldo", inPago));
            cmd.Parameters.Add(new SqlParameter("@ctrliUsuarioAltaId", usuario_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlsAfiliacionIMSS", inAfiliacionesIMSS));
            cmd.Parameters.Add(new SqlParameter("@ctrliRiesgoTrabajo", inRiesgoTrabajo));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    res.Add(data["iFlag"].ToString());
                    res.Add(data["sRespuesta"].ToString());
                    res.Add(data["id"].ToString());
                    res.Add(data["RT"].ToString());
                }
            }
            else
            {
                res = null;
            }
            data.Close();
            return res;
        }



    }
}