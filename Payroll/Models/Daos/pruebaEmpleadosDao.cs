﻿using Payroll.Models.Beans;
using Payroll.Models.Utilerias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
        public List<DescEmpleadoVacacionesBean> sp_CEmpleado_Retrieve_Empleado(int IdEmpleado, int IdEmpresa)
        {
            List<DescEmpleadoVacacionesBean> list = new List<DescEmpleadoVacacionesBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TPeriodos_Verify_AllPeriods", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrliIdEmpleado", IdEmpleado));
            cmd.Parameters.Add(new SqlParameter("@ctrliIdEmpresa", IdEmpresa));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    DescEmpleadoVacacionesBean listEmpleados = new DescEmpleadoVacacionesBean();

                    listEmpleados.iFlag = int.Parse(data["iFlag"].ToString());
                    listEmpleados.IdEmpleado = int.Parse(data["IdEmpleado"].ToString());
                    listEmpleados.Nombre_Empleado = data["Nombre_Empleado"].ToString();
                    listEmpleados.Apellido_Paterno_Empleado = data["Apellido_Paterno_Empleado"].ToString();
                    listEmpleados.Apellido_Materno_Empleado = data["Apellido_Materno_Empleado"].ToString();
                    listEmpleados.DescripcionDepartamento = data["DescripcionDepartamento"].ToString();
                    listEmpleados.DescripcionPuesto = data["DescripcionPuesto"].ToString();
                    listEmpleados.FechaIngreso = data["FechaIngreso"].ToString();
                    listEmpleados.Id_Per_Vac = int.Parse(data["IdPer_Vac"].ToString());
                    listEmpleados.Fecha_Aniversario = data["FechaAntiguedad"].ToString();
                    listEmpleados.Id_Per_Vac_Ln = int.Parse(data["IdPer_Vac_Ln"].ToString());
                    listEmpleados.Anio = int.Parse(data["Anio"].ToString());
                    listEmpleados.DiasPrima = int.Parse(data["DiasPrima"].ToString());
                    listEmpleados.DiasDisfrutados = int.Parse(data["DiasDisfrutados"].ToString());
                    listEmpleados.DiasRestantes = int.Parse(data["DiasRestantes"].ToString());

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
        public List<CreditosBean> sp_TCreditos_Retrieve_Creditos(int IdEmpleado, int IdEmpresa)
        {

            List<CreditosBean> list = new List<CreditosBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TCreditos_Retrieve_Creditos", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa_id", IdEmpresa));
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpleado_id", IdEmpleado));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    CreditosBean listCreditos = new CreditosBean();
                    listCreditos.IdCredito = int.Parse(data["IdCredito"].ToString());
                    listCreditos.Empleado_id = int.Parse(data["Empleado_id"].ToString());
                    listCreditos.Empresa_id = int.Parse(data["Empresa_id"].ToString());
                    listCreditos.TipoDescuento = data["TipoDescuento"].ToString();
                    listCreditos.SeguroVivienda = data["SeguroVivienda"].ToString();
                    listCreditos.Descuento = data["Descuento"].ToString();
                    listCreditos.NoCredito = data["NoCredito"].ToString();
                    listCreditos.FechaAprovacionCredito = data["FechaAprovacionCredito"].ToString();
                    listCreditos.Descontar = data["Descontar"].ToString();
                    if (data["FechaBajaCredito"].ToString().Length < 1)
                    { listCreditos.FechaBaja = ""; }
                    else
                    { listCreditos.FechaBaja = data["FechaBajaCredito"].ToString(); }
                    if (data["FechaReinicioCredito"].ToString().Length < 1)
                    { listCreditos.FechaReinicio = ""; }
                    else
                    { listCreditos.FechaReinicio = data["FechaReinicioCredito"].ToString(); }

                    listCreditos.Finalizado = data["Finalizado"].ToString();

                    list.Add(listCreditos);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }
        public List<CreditosBean> sp_TCreditos_Insert_Credito(int Empleado_id, int Empresa_id, string TipoDescuento, int SeguroVivienda, string Descuento, string NoCredito, string FechaAprovacion, string Descontar, string FechaBaja, string FechaReinicio)
        {
            if (FechaBaja == null)
            {
                FechaBaja = "";
            }
            if (FechaReinicio == null)
            {
                FechaReinicio = "";
            }
            List<CreditosBean> list = new List<CreditosBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TCreditos_Insert_Credito", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpleado_id", Empleado_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa_id", Empresa_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlTipoDescuento", TipoDescuento));
            cmd.Parameters.Add(new SqlParameter("@ctrlSeguroVivienda", SeguroVivienda));
            cmd.Parameters.Add(new SqlParameter("@ctrlDescuento", Descuento));
            cmd.Parameters.Add(new SqlParameter("@ctrlNoCredito", NoCredito));
            cmd.Parameters.Add(new SqlParameter("@ctrlFechaAprovacionCredito", FechaAprovacion));
            cmd.Parameters.Add(new SqlParameter("@ctrlDescontar", Descontar));
            cmd.Parameters.Add(new SqlParameter("@ctrlFechaBajaCredito", FechaBaja));
            cmd.Parameters.Add(new SqlParameter("@ctrlFechaReinicioCredito", FechaReinicio));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();

            data.Close();

            return list;
        }
        public List<AusentismosEmpleadosBean> sp_TAusentismos_Retrieve_Ausentismos_Empleado(int Empresa_id, int Empleado_id)
        {
            List<AusentismosEmpleadosBean> list = new List<AusentismosEmpleadosBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TAusentismos_Retrieve_Ausentismos_Empleado", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa_id", Empresa_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpleado_id", Empleado_id));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    AusentismosEmpleadosBean lista = new AusentismosEmpleadosBean();

                    lista.IdAusentismo = int.Parse(data["IdAusentismo"].ToString());
                    lista.Tipo_Ausentismo_id = int.Parse(data["Tipo_Ausentismo_id"].ToString());
                    lista.Nombre_Ausentismo = data["Descripcion"].ToString();
                    lista.Empleado_id = int.Parse(data["Empleado_id"].ToString());
                    lista.Empresa_id = int.Parse(data["Empresa_id"].ToString());
                    lista.Fecha_Ausentismo = data["Fecha_Ausentismo"].ToString();
                    lista.Dias_Ausentismo = int.Parse(data["Dias_Ausentismo"].ToString());
                    lista.Certificado_imss = data["Fecha_Ausentismo"].ToString();
                    lista.Comentarios_imss = data["Fecha_Ausentismo"].ToString();
                    lista.Causa_FaltaInjustificada = data["Fecha_Ausentismo"].ToString();

                    list.Add(lista);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }
        public List<AusentismosEmpleadosBean> sp_TAusentismos_Retrieve_Ausentismo_Empleado(int Empresa_id, int Empleado_id, int IdAusentismo)
        {
            List<AusentismosEmpleadosBean> list = new List<AusentismosEmpleadosBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TAusentismos_Retrieve_Ausentismo_Empleado", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa_id", Empresa_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpleado_id", Empleado_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlAusentismo_id", IdAusentismo));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    AusentismosEmpleadosBean lista = new AusentismosEmpleadosBean();

                    lista.IdAusentismo = int.Parse(data["IdAusentismo"].ToString());
                    lista.Tipo_Ausentismo_id = int.Parse(data["Tipo_Ausentismo_id"].ToString());
                    lista.RecuperaAusentismo = data["Recupera_Ausentismo"].ToString();
                    lista.Empleado_id = int.Parse(data["Empleado_id"].ToString());
                    lista.Empresa_id = int.Parse(data["Empresa_id"].ToString());
                    lista.Fecha_Ausentismo = data["Fecha_Ausentismo"].ToString();
                    lista.Dias_Ausentismo = int.Parse(data["Dias_Ausentismo"].ToString());
                    lista.Certificado_imss = data["Certificado_imss"].ToString();
                    lista.Comentarios_imss = data["Comentarios_imss"].ToString();
                    lista.Causa_FaltaInjustificada = data["Causa_FaltaInjustificada"].ToString();

                    list.Add(lista);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }
        public List<AusentismosEmpleadosBean> sp_TAusentismos_Retrieve_Ausentismos()
        {
            List<AusentismosEmpleadosBean> list = new List<AusentismosEmpleadosBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TAusentismos_Retrieve_Ausentismos", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    AusentismosEmpleadosBean lista = new AusentismosEmpleadosBean();

                    lista.IdAusentismo = int.Parse(data["IdAusentismo"].ToString());
                    lista.Tipo_Ausentismo_id = int.Parse(data["Tipo_Ausentismo_id"].ToString());
                    lista.Empleado_id = int.Parse(data["Empleado_id"].ToString());
                    lista.Empresa_id = int.Parse(data["Empresa_id"].ToString());
                    lista.Fecha_Ausentismo = data["Fecha_Ausentismo"].ToString();
                    lista.Dias_Ausentismo = int.Parse(data["Dias_Ausentismo"].ToString());
                    lista.Certificado_imss = data["Fecha_Ausentismo"].ToString();
                    lista.Comentarios_imss = data["Fecha_Ausentismo"].ToString();
                    lista.Causa_FaltaInjustificada = data["Fecha_Ausentismo"].ToString();

                    list.Add(lista);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }
        public List<string> sp_TAusentismos_Delete_Ausentismos(int Empresa_id, int Empleado_id, int IdAusentismo)
        {
            List<string> list = new List<string>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TAusentismos_Delete_Ausentismos", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa_id", Empresa_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpleado_id", Empleado_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlIdAusentismo", IdAusentismo));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                list.Add("1");
                list.Add("Ausentismo Eliminado con éxito");
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }
        public void sp_TAusentismos_Insert_Ausentismo(int Tipo_Ausentismo_id, int Empleado_id, int Empresa_id, string Recupera_Ausentismo, string Fecha_Ausentismo, int Dias_Ausentismo, string Certificado_imss, string Comentarios_imss, string Causa_FaltaInjustificada)
        {
            List<string> lista = new List<string>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TAusentismos_Insert_Ausentismo", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlTipo_Ausentismo_id", Tipo_Ausentismo_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa_id", Empresa_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpleado_id", Empleado_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlRecupera_Ausentismo", Recupera_Ausentismo));
            cmd.Parameters.Add(new SqlParameter("@ctrlFecha_Ausentismo", Fecha_Ausentismo));
            cmd.Parameters.Add(new SqlParameter("@ctrlDias_Ausentismo", Dias_Ausentismo));
            cmd.Parameters.Add(new SqlParameter("@ctrlCertificado_imss", Certificado_imss));
            cmd.Parameters.Add(new SqlParameter("@ctrlComentarios_imss", Comentarios_imss));
            cmd.Parameters.Add(new SqlParameter("@ctrlCausa_FaltaInjustificada", Causa_FaltaInjustificada));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            data.Close();
        }
        public List<string> sp_TPensiones_Alimenticias_Insert_Pensiones(int Empresa_id, int Empleado_id, string Cuota_fija, int Porcentaje, string AplicaEn, string Descontar_en_finiquito, string No_Oficio, string Fecha_Oficio, int Tipo_Calculo, string Aumentar_segun_salario_minimo_general, string Aumentar_segun_aumento_de_sueldo, string Beneficiaria, int Banco, string Sucursal, string Tarjeta_vales, string Cuenta_Cheques, string Fecha_baja)
        {
            List<string> list = new List<string>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TPensiones_Alimenticias_Insert_Pensiones", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa_id", Empresa_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpleado_id", Empleado_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlCuota_fija", Cuota_fija));
            cmd.Parameters.Add(new SqlParameter("@ctrlPorcentaje", Porcentaje));
            cmd.Parameters.Add(new SqlParameter("@ctrlAplicaEn", AplicaEn));
            cmd.Parameters.Add(new SqlParameter("@ctrlDescontar_en_Finiquito", Descontar_en_finiquito));
            cmd.Parameters.Add(new SqlParameter("@ctrlNo_Oficio", No_Oficio));
            cmd.Parameters.Add(new SqlParameter("@ctrlFecha_Oficio", Fecha_Oficio));
            cmd.Parameters.Add(new SqlParameter("@ctrlTipo_Calculo", Tipo_Calculo));
            cmd.Parameters.Add(new SqlParameter("@ctrlAumentar_segun_SMG", Aumentar_segun_salario_minimo_general));
            cmd.Parameters.Add(new SqlParameter("@ctrlAumentar_segun_AS", Aumentar_segun_aumento_de_sueldo));
            cmd.Parameters.Add(new SqlParameter("@ctrlBeneficiaria", Beneficiaria));
            cmd.Parameters.Add(new SqlParameter("@ctrlBanco", Banco));
            cmd.Parameters.Add(new SqlParameter("@ctrlSucursal", Sucursal));
            cmd.Parameters.Add(new SqlParameter("@ctrlTarjeta_Vales", Tarjeta_vales));
            cmd.Parameters.Add(new SqlParameter("@ctrlCuenta_Cheques", Cuenta_Cheques));
            cmd.Parameters.Add(new SqlParameter("@ctrlFecha_Baja", Fecha_baja));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    list.Add(data["iFlag"].ToString());
                    list.Add(data["sRespuesta"].ToString());
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }
        public List<PensionesAlimentariasBean> sp_TPensiones_Alimenticias_Retrieve_Pensiones(int Empresa_id, int Empleado_id)
        {
            List<PensionesAlimentariasBean> lista = new List<PensionesAlimentariasBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TPensiones_Alimenticias_Retrieve_Pensiones", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa_id", Empresa_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpleado_id", Empleado_id));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                //list.Add("1");
                //list.Add("Pension  Eliminado con éxito");
                while (data.Read())
                {
                    PensionesAlimentariasBean list = new PensionesAlimentariasBean();
                    list.IdPension = int.Parse(data["IdPension"].ToString());
                    list.Empresa_id = int.Parse(data["Empresa_id"].ToString());
                    list.Empleado_id = int.Parse(data["Empleado_id"].ToString());
                    if (data["Cuota_fija"].ToString().Length == 0) { list.Cuota_Fija = ""; } else { list.Cuota_Fija = data["Cuota_fija"].ToString(); }
                    if (data["Porcentaje"].ToString().Length == 0) { list.Porcentaje = 0; } else { list.Porcentaje = int.Parse(data["Porcentaje"].ToString()); }
                    if (data["AplicaEn"].ToString().Length == 0) { list.AplicaEn = ""; } else { list.AplicaEn = data["AplicaEn"].ToString(); }

                    list.Descontar_en_Finiquito = data["Descontar_en_Finiquito"].ToString();
                    list.No_Oficio = data["No_Oficio"].ToString();
                    list.Fecha_Oficio = data["Fecha_Oficio"].ToString().Substring(0, 10);
                    list.Tipo_Calculo = data["Tipo_Calculo"].ToString();
                    list.Aumentar_segun_salario_minimo_general = data["Aumentar_segun_salario_minimo_general"].ToString();
                    list.Aumentar_segun_aumento_de_sueldo = data["Aumentar_segun_aumento_de_sueldo"].ToString();
                    list.Beneficiaria = data["Beneficiaria"].ToString();
                    list.Banco = int.Parse(data["Banco"].ToString());
                    if (data["Sucursal"].ToString().Length == 0) { list.Sucursal = ""; } else { list.Sucursal = data["Sucursal"].ToString(); }
                    if (data["Tarjeta_vales"].ToString().Length == 0) { list.Tarjeta_vales = ""; } else { list.Tarjeta_vales = data["Tarjeta_vales"].ToString(); }
                    if (data["Cuenta_cheques"].ToString().Length == 0) { list.Cuenta_cheques = ""; } else { list.Cuenta_cheques = data["Cuenta_cheques"].ToString(); }
                    if (data["Fecha_baja"].ToString().Length == 0) { list.Fecha_baja = ""; } else { list.Fecha_baja = data["Fecha_baja"].ToString().Substring(0, 10); }

                    lista.Add(list);

                }
            }
            else
            {
                lista = null;
            }
            data.Close();

            return lista;
        }
        public List<VW_TipoIncidenciaBean> sp_VW_tipo_Incidencia_Retrieve_LoadTipoIncidencia(int Empresa_id)
        {
            List<VW_TipoIncidenciaBean> list = new List<VW_TipoIncidenciaBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_VW_tipo_Incidencia_Retrieve_LoadTipoIncidencia", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa_id", Empresa_id));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    VW_TipoIncidenciaBean lista = new VW_TipoIncidenciaBean();
                    lista.Ren_incid_id = int.Parse(data["Ren_incid_id"].ToString());
                    lista.Descripcion = data["Descripcion"].ToString();
                    list.Add(lista);
                }
            }
            else
            {
                list = null;
            }
            data.Close();

            return list;
        }
        public List<string> sp_TRegistro_incidencias_Insert_Incidencia(int Empresa_id, int Empleado_id, int Renglon, int Cantidad, int Plazos, string Leyenda, string Referencia, string Fecha_Aplicacion)
        {
            List<string> list = new List<string>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TRegistro_incidencias_Insert_Incidencia", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa_id", Empresa_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpleado_id", Empleado_id));
            cmd.Parameters.Add(new SqlParameter("@ctrlTipoIncidencia", Renglon));
            cmd.Parameters.Add(new SqlParameter("@ctrlCantidad", Cantidad));
            cmd.Parameters.Add(new SqlParameter("@ctrlPlazos", Plazos));
            cmd.Parameters.Add(new SqlParameter("@ctrlLeyenda", Leyenda));
            cmd.Parameters.Add(new SqlParameter("@ctrlReferencia", Referencia));
            cmd.Parameters.Add(new SqlParameter("@ctrlFechaAplicacion", Fecha_Aplicacion));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    list.Add(data["iFlag"].ToString());
                    list.Add(data["Descripcion"].ToString());
                }
            }
            else
            {
                list = null;
            }
            data.Close();
            return list;
        }
        public List<VW_TipoIncidenciaBean> sp_TRegistro_incidencias_Update_Incidencia( int Empresa_id, int Empleado_id, int Renglon, int Cantidad, int Plazos, string Descripcion, string Referencia, string Fecha_Aplicacion)
        {
            List<VW_TipoIncidenciaBean> list = new List<VW_TipoIncidenciaBean>();
            this.Conectar();
            SqlCommand cmd = new SqlCommand("sp_TRegistro_incidencias_Update_Incidencia", this.conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa_id", Empresa_id));
            SqlDataReader data = cmd.ExecuteReader();
            cmd.Dispose();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    VW_TipoIncidenciaBean lista = new VW_TipoIncidenciaBean();
                    lista.Ren_incid_id = int.Parse(data["Ren_incid_id"].ToString());
                    lista.Descripcion = data["Descripcion"].ToString();
                    list.Add(lista);
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