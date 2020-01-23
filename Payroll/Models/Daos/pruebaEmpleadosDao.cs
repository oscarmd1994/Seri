using Payroll.Models.Beans;
using Payroll.Models.Utilerias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Payroll.Models.Daos
{
    public class pruebaEmpleadosDao : Conexion
    {
        public List<DescEmpleadoVacacionesBean> sp_Retrieve_liveSearchEmpleado(int IdEmp, string txtSearch)
        {
            string txt = txtSearch;
            List<DescEmpleadoVacacionesBean> list = new List<DescEmpleadoVacacionesBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Retrieve_liveSearchEmpleado", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrliIdEmpresa", IdEmp));
            cmd.Parameters.Add(new SqlParameter("@ctrlsNombreEmpleado", txt));
          SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    DescEmpleadoVacacionesBean listEmpleados = new DescEmpleadoVacacionesBean();
                    if (int.Parse(data["iFlag"].ToString()) == 0)
                    {
                        listEmpleados.iFlag = int.Parse(data["iFlag"].ToString());
                        listEmpleados.IdEmpleado = int.Parse(data["IdEmpleado"].ToString());
                        listEmpleados.Nombre_Empleado = data["Nombre_Empleado"].ToString();
                        listEmpleados.Apellido_Paterno_Empleado = data["Apellido_Paterno_Empleado"].ToString();
                        listEmpleados.Apellido_Materno_Empleado = data["Apellido_Materno_Empleado"].ToString();
                        listEmpleados.DescripcionDepartamento = data["DescripcionDepartamento"].ToString();
                        listEmpleados.DescripcionPuesto = data["DescripcionPuesto"].ToString();
                        listEmpleados.FechaIngreso = data["FechaIngreso"].ToString();
                    }
                    else
                    {
                        listEmpleados.iFlag = int.Parse(data["iFlag"].ToString());
                        listEmpleados.Nombre_Empleado = data["title"].ToString();
                        listEmpleados.DescripcionPuesto = data["resume"].ToString();
                    }
                    list.Add(listEmpleados);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }
        public List<PruebaEmpleadosBean> sp_Retrieve_pruebaEmpleado(int IdEmpleado)
        {
            List<PruebaEmpleadosBean> list = new List<PruebaEmpleadosBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Retrieve_pruevaEmpleado", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@IdEmpleado", IdEmpleado));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    PruebaEmpleadosBean listEmpleados = new PruebaEmpleadosBean
                    {
                        IdEmpleado = int.Parse(data["IdEmpleado"].ToString()),
                        NombreEmpleado = data["NombreEmpleado"].ToString(),
                        ApellidosEmpleado = data["ApellidosEmpleado"].ToString(),
                        NombreDepartamento = data["NombreDepartamento"].ToString(),
                        Puesto = data["Puesto"].ToString(),
                        FechaIngreso = data["FechaIngreso"].ToString(),
                        Sueldo = decimal.Parse(data["Sueldo"].ToString()),
                        IdEmpresa = int.Parse(data["IdEmpresa"].ToString())
                    };
                    list.Add(listEmpleados);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }
        public List<PeriodoVacacionesBean> sp_Retrieve_PeriodosVacaciones(int IdEmpleado)
        {
            List<PeriodoVacacionesBean> list = new List<PeriodoVacacionesBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Retrieve_PeriodosVacaciones", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@IdEmpleado", IdEmpleado));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    PeriodoVacacionesBean listEmpleados = new PeriodoVacacionesBean
                    {
                        iIdEmpleado = int.Parse(data["IdEmpleado"].ToString()),
                        iAnio = int.Parse(data["Anio"].ToString()),
                        sFechaInicio = DateTime.Parse(data["FechaInicio"].ToString()),
                        sFechaTermino = DateTime.Parse(data["FechaTermino"].ToString()),
                        iDiasDisfrutados = int.Parse(data["DiasDisfrutados"].ToString()),
                        iDiasPrima = decimal.Parse(data["DiasPrima"].ToString())

                    };
                    list.Add(listEmpleados);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }

        public List<PoliticasVacacionesBean> sp_Retrieve_PoliticasVacaciones()
        {

            List<PoliticasVacacionesBean> list = new List<PoliticasVacacionesBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_Retrieve_PoliticasVacaciones", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    PoliticasVacacionesBean listPoliticas = new PoliticasVacacionesBean
                    {
                        iIdPolitica = int.Parse(data["iIdPolitica"].ToString()),
                        iAnio = int.Parse(data["iAnio"].ToString()),
                        iDias = int.Parse(data["iDias"].ToString()),
                        iDiasAdicionales = int.Parse(data["iDiasAdicionales"].ToString()),
                        iDiasPrima = decimal.Parse(data["iDiasPrima"].ToString())

                    };
                    list.Add(listPoliticas);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }

    }
}