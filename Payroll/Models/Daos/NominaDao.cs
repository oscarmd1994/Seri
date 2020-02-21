using Payroll.Models.Beans;
using Payroll.Models.Utilerias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Payroll.Models.Daos
{
    public class NominaDao
    {
    }

    public class FuncionesNomina : Conexion
    {
        public NominahdBean sp_DefineNom_insert_DefineNom(string CtrsNombre, string CtrsDEscripcion, int CtriAno, int ctrlsCancelado, int iIdusario)
        {
            NominahdBean bean = new NominahdBean();

            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_DefineNom_insert_DefineNom", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrsNombre", CtrsNombre));
                cmd.Parameters.Add(new SqlParameter("@CtrsDEscripcion", CtrsDEscripcion));
                cmd.Parameters.Add(new SqlParameter("@sCtriAno", CtriAno));
                cmd.Parameters.Add(new SqlParameter("@ctrlsCancelado", ctrlsCancelado));
                cmd.Parameters.Add(new SqlParameter("@ctrlsUsuarioAlta", iIdusario));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    bean.sMensaje = "success";
                }
                else
                {
                    bean.sMensaje = "error";
                }
                cmd.Dispose(); conexion.Close(); //cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return bean;
        }

        public List<EmpresasBean> sp_CEmpresas_Retrieve_Empresas()
        {
            List<EmpresasBean> list = new List<EmpresasBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_CEmpresas_Retrieve_Empresas", this.conexion)
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
                        EmpresasBean ls = new EmpresasBean
                        {
                            iIdEmpresa = int.Parse(data["IdEmpresa"].ToString()),
                            sNombreEmpresa = data["NombreEmpresa"].ToString()

                        };
                        list.Add(ls);
                    }
                }
                else
                {
                    list = null;
                }
                data.Close(); cmd.Dispose(); conexion.Close(); //cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;
        }


        public List<CTipoPeriodoBean> sp_CTipoPeriod_Retrieve_TiposPeriodos(string Ctrsvalor)
        {
            List<CTipoPeriodoBean> list = new List<CTipoPeriodoBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_CTipoPeriod_Retrieve_TiposPeriodos", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlsValor", Ctrsvalor));
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        CTipoPeriodoBean ls = new CTipoPeriodoBean();
                        {
                            ls.iId = int.Parse(data["id"].ToString());
                            ls.sValor = data["Valor"].ToString();

                        };


                        list.Add(ls);
                    }
                }
                else
                {
                    list = null;
                }

                data.Close(); cmd.Dispose(); conexion.Close(); //cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;
        }


        public List<CRenglonesBean> sp_CRenglones_Retrieve_CRenglones(string ctrlsNombreEmpresa)
        {
            List<CRenglonesBean> list = new List<CRenglonesBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_CRenglones_Retrieve_CRenglones", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlsNombreEmpresa", ctrlsNombreEmpresa));
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        CRenglonesBean ls = new CRenglonesBean();
                        {
                            ls.iIdRenglon = int.Parse(data["IdRenglon"].ToString());
                            ls.sNombreRenglon = data["NombreRenglon"].ToString();

                        };


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

        public List<CAcumuladosRenglon> sp_CAcumuladoREnglones_Retrieve_CAcumuladoREnglones(string ctrlsNombreEmpresa, int ctrliIdRenglon)
        {
            List<CAcumuladosRenglon> list = new List<CAcumuladosRenglon>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_CAcumuladoREnglones_Retrieve_CAcumuladoREnglones", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlsNombreEmpresa", ctrlsNombreEmpresa));
                cmd.Parameters.Add(new SqlParameter("@ctrlsiIdRenglon ", ctrliIdRenglon));
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        CAcumuladosRenglon LAc = new CAcumuladosRenglon();
                        {
                            LAc.iIdAcumulado = int.Parse(data["IdAcumulado"].ToString());
                            LAc.sDesAcumulado = data["Descripcion_Acumulado"].ToString();

                        };


                        list.Add(LAc);
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

        public List<NominahdBean> sp_IdDefinicionNomina_Retrieve_IdDefinicionNomina()
        {
            List<NominahdBean> list = new List<NominahdBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_IdDefinicionNomina_Retrieve_IdDefinicionNomina", this.conexion)
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
                        NominahdBean LDNH = new NominahdBean
                        {
                            iIdDefinicionhd = int.Parse(data["IdDefinicionHd"].ToString())
                        };
                        list.Add(LDNH);
                    }
                }
                else
                {
                    list = null;
                }
                data.Close(); cmd.Dispose(); conexion.Close(); //cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;
        }

        public List<NominahdBean> sp_DefCancelados_Retrieve_DefCancelados(int ctrliIdDefinicion)
        {
            List<NominahdBean> list = new List<NominahdBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_DefCancelados_Retrieve_DefCancelados", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrliIdDefinicion", ctrliIdDefinicion));
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        NominahdBean ls = new NominahdBean();
                        {
                            ls.iIdDefinicionhd = int.Parse(data["IdDefinicion_Hd"].ToString());
                            ls.iAno = int.Parse(data["Anio"].ToString());
                            ls.iCancelado = data["Cancelado"].ToString();

                        };


                        list.Add(ls);
                    }
                }
                else
                {
                    list = null;
                }

                data.Close(); cmd.Dispose(); conexion.Close(); //cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;
        }

        public NominaLnBean sp_CDefinicionLN_insert_CDefinicionLN(int CtriIdDefinicion, int CtriIdEmpresaid, int CtriIdTipoPeriodo, int CtriIdPeriodo, int CtriIdRenglon, int CtriCancelado, int CtriIdUsuarioAlta, int sCtriIdElementoNomina, int ctrliEspejo, int ctrliIDAcumulado)
        {
            NominaLnBean bean = new NominaLnBean();

            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_CDefinicionLN_insert_CDefinicionLN", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtriIdDefinicion", CtriIdDefinicion));
                cmd.Parameters.Add(new SqlParameter("@CtriIdEmpresaid", CtriIdEmpresaid));
                cmd.Parameters.Add(new SqlParameter("@CtriIdTipoPeriodo", CtriIdTipoPeriodo));
                cmd.Parameters.Add(new SqlParameter("@CtriIdPeriodo", CtriIdPeriodo));
                cmd.Parameters.Add(new SqlParameter("@CtriIdRenglon", CtriIdRenglon));
                cmd.Parameters.Add(new SqlParameter("@CtriCancelado", CtriCancelado));
                cmd.Parameters.Add(new SqlParameter("@CtriIdUsuarioAlta", CtriIdUsuarioAlta));
                cmd.Parameters.Add(new SqlParameter("@sCtriIdElementoNomina", sCtriIdElementoNomina));
                cmd.Parameters.Add(new SqlParameter("@ctrliEspejo", ctrliEspejo));
                cmd.Parameters.Add(new SqlParameter("@ctrliIDAcumulado", ctrliIDAcumulado));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    bean.sMensaje = "success";
                }
                else
                {
                    bean.sMensaje = "error";
                }
                cmd.Dispose(); conexion.Close(); //cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return bean;
        }

        public List<CInicioFechasPeriodoBean> sp_Cperiodo_Retrieve_Cperiodo(int CtrliIdEmpresa, int CtrliAnio, int CtrliIdTipoPeriodo)
        {
            List<CInicioFechasPeriodoBean> list = new List<CInicioFechasPeriodoBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Cperiodo_Retrieve_Cperiodo", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrliIdEmpresa", CtrliIdEmpresa));
                cmd.Parameters.Add(new SqlParameter("@CtrliAnio ", CtrliAnio));
                cmd.Parameters.Add(new SqlParameter("@CtrliIdTipoPeriodo", CtrliIdTipoPeriodo));
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        CInicioFechasPeriodoBean LP = new CInicioFechasPeriodoBean();
                        {
                            LP.iId = int.Parse(data["Id"].ToString());
                            LP.iPeriodo = int.Parse(data["Periodo"].ToString());

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

        public List<NominaLnDatBean> sp_DefinicionesNomLn_Retrieve_DefinicionesNomLn(int CtrliIdDefinicionHd)
        {
            List<NominaLnDatBean> list = new List<NominaLnDatBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_DefinicionesNomLn_Retrieve_DefinicionesNomLn", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrliIdDefinicionHd", CtrliIdDefinicionHd));
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        NominaLnDatBean LDN = new NominaLnDatBean();
                        {
                            LDN.iIdDefinicionln = data["IdDefinicion_Ln"].ToString();
                            LDN.IdEmpresa = data["NombreEmpresa"].ToString();
                            LDN.iRenglon = data["NombreRenglon"].ToString();
                            LDN.iTipodeperiodo = data["Valor"].ToString();
                            LDN.iIdperiodo = data["Periodo_id"].ToString();
                            LDN.iIdAcumulado = data["Acumulado_id"].ToString();
                            LDN.iEsespejo = data["Es_Espejo"].ToString();
                        };


                        list.Add(LDN);
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

        public List<NominaLnDatBean> sp_DescripAcu_Retrieve_DescripAcu(int CtrliIdAcumulado)
        {
            List<NominaLnDatBean> list = new List<NominaLnDatBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_DescripAcu_Retrieve_DescripAcu", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrliIdAcumulado", CtrliIdAcumulado));
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        NominaLnDatBean LDN = new NominaLnDatBean();
                        {
                            LDN.iIdAcumulado = data["Descripcion_Acumulado"].ToString();
                        };


                        list.Add(LDN);
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

        public List<NominaLnDatBean> sp_DefinicionesDeNomLn_Retrieve_DefinicionesDeNomLn(int CtrliIdDefinicionHd)
        {

            List<NominaLnDatBean> list = new List<NominaLnDatBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_DefinicionesDeNomLn_Retrieve_DefinicionesDeNomLn", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrliIdDefinicionHd", CtrliIdDefinicionHd));
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        NominaLnDatBean LDN = new NominaLnDatBean();
                        {
                            LDN.iIdDefinicionln = data["IdDefinicion_Ln"].ToString();
                            LDN.IdEmpresa = data["NombreEmpresa"].ToString();
                            LDN.iRenglon = data["NombreRenglon"].ToString();
                            LDN.iTipodeperiodo = data["Valor"].ToString();
                            LDN.iIdperiodo = data["Periodo_id"].ToString();
                            LDN.iIdAcumulado = data["Acumulado_id"].ToString();
                            LDN.iEsespejo = data["Es_Espejo"].ToString();

                        };


                        list.Add(LDN);
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

        public List<NominahdBean> sp_DefinicionNombresHd_Retrieve_DefinicionNombresHd()
        {
            List<NominahdBean> list = new List<NominahdBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_DefinicionNombresHd_Retrieve_DefinicionNombresHd", this.conexion)
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
                        NominahdBean ls = new NominahdBean();
                        {

                            ls.sNombreDefinicion = data["Nombre_Definicion"].ToString();

                        };
                        list.Add(ls);
                    }
                }
                else
                {
                    list = null;
                }
                data.Close(); cmd.Dispose(); conexion.Close(); //cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;

        }

        public List<NominahdBean> sp_TpDefinicionesNom_Retrieve_TpDefinicionNom()
        {
            List<NominahdBean> list = new List<NominahdBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_TpDefinicionesNom_Retrieve_TpDefinicionNom", this.conexion)
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
                        NominahdBean ls = new NominahdBean();
                        {
                            ls.iIdDefinicionhd = int.Parse(data["IdDefinicion_Hd"].ToString());
                            ls.sNombreDefinicion = data["Nombre_Definicion"].ToString();
                            ls.sDescripcion = data["Descripcion"].ToString();
                            ls.iAno = int.Parse(data["Anio"].ToString());
                            ls.iCancelado = data["Cancelado"].ToString();
                        };
                        list.Add(ls);
                    }
                }
                else
                {
                    list = null;
                }
                data.Close(); cmd.Dispose(); conexion.Close(); //cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;
        }

        public List<NominahdBean> sp_DeficionNominaCancelados_Retrieve_DeficionNominaCancelados(string CrtlsNombreDefinicio, int CrtliCanceldo)
        {

            List<NominahdBean> list = new List<NominahdBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_DeficionNominaCancelados_Retrieve_DeficionNominaCancelados", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CrtlsNombreDefinicio", CrtlsNombreDefinicio));
                cmd.Parameters.Add(new SqlParameter("@CrtliCanceldo ", CrtliCanceldo));
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        NominahdBean TDN = new NominahdBean();
                        {
                            TDN.iIdDefinicionhd = int.Parse(data["IdDefinicion_Hd"].ToString());
                            TDN.sNombreDefinicion = data["Nombre_Definicion"].ToString();
                            TDN.sDescripcion = data["Descripcion"].ToString();
                            TDN.iAno = int.Parse(data["Anio"].ToString());
                            TDN.iCancelado = data["Cancelado"].ToString();
                        };


                        list.Add(TDN);
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

        public NominahdBean sp_TpDefinicion_Update_TpDefinicion(string CtrsNombre, string CtrsDEscripcion, int CtriAno, int ctrlsCancelado, int CtrliIdDefinicionhd)
        {
            NominahdBean bean = new NominahdBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_TpDefinicion_Update_TpDefinicion", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrlsNombre", CtrsNombre));
                cmd.Parameters.Add(new SqlParameter("@CtrlsDEscripcion", CtrsDEscripcion));
                cmd.Parameters.Add(new SqlParameter("@sCtrliAno", CtriAno));
                cmd.Parameters.Add(new SqlParameter("@ctrlsCancelado", ctrlsCancelado));
                cmd.Parameters.Add(new SqlParameter("@CtrliIdDefinicionhd", CtrliIdDefinicionhd));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    bean.sMensaje = "success";
                }
                else
                {
                    bean.sMensaje = "error";
                }
                cmd.Dispose(); conexion.Close(); cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return bean;
        }

        public NominahdBean sp_EliminarDefinicion_Delete_EliminarDefinicion(int CtrliIdDefinicionHd)
        {
            NominahdBean bean = new NominahdBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_EliminarDefinicion_Delete_EliminarDefinicion", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrliIdDefinicionHd", CtrliIdDefinicionHd));

                if (cmd.ExecuteNonQuery() > 0)
                {
                    bean.sMensaje = "success";
                }
                else
                {
                    bean.sMensaje = "error";
                }
                cmd.Dispose(); conexion.Close(); cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return bean;


        }

        public NominaLnBean sp_TpDefinicionNomLn_Update_TpDefinicionNomLn(int CtrlIdDefinicionLn, int CtriIdEmpresaid, int CtriIdTipoPeriodo, int CtriIdPeriodo, int CtriIdRenglon, int ctrliEspejo, int ctrliIDAcumulado)
        {
            NominaLnBean bean = new NominaLnBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_TpDefinicionNomLn_Update_TpDefinicionNomLn", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrlIdDefinicionLn", CtrlIdDefinicionLn));
                cmd.Parameters.Add(new SqlParameter("@CtriIdEmpresaid", CtriIdEmpresaid));
                cmd.Parameters.Add(new SqlParameter("@CtriIdTipoPeriodo", CtriIdTipoPeriodo));
                cmd.Parameters.Add(new SqlParameter("@CtriIdPeriodo", CtriIdPeriodo));
                cmd.Parameters.Add(new SqlParameter("@CtriIdRenglon", CtriIdRenglon));
                cmd.Parameters.Add(new SqlParameter("@ctrliEspejo", ctrliEspejo));
                cmd.Parameters.Add(new SqlParameter("@ctrliIDAcumulado", ctrliIDAcumulado));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    bean.sMensaje = "success";
                }
                else
                {
                    bean.sMensaje = "error";
                }
                cmd.Dispose(); conexion.Close(); cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return bean;

        }

        public NominaLnBean sp_EliminarDefinicionNl_Delete_EliminarDefinicionNl(int CtrliIdDefinicionNl)
        {
            NominaLnBean bean = new NominaLnBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_EliminarDefinicionNl_Delete_EliminarDefinicionNl", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrliIdDefinicionNl", CtrliIdDefinicionNl));

                if (cmd.ExecuteNonQuery() > 0)
                {
                    bean.sMensaje = "success";
                }
                else
                {
                    bean.sMensaje = "error";
                }
                cmd.Dispose(); conexion.Close(); cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return bean;

        }

        public List<TpCalculosHd> sp_ExiteDefinicionTpCalculo_Retrieve_ExiteDefinicionTpCalculo(int CtrliIdDefinicion)
        {
            List<TpCalculosHd> list = new List<TpCalculosHd>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_ExiteDefinicionTpCalculo_Retrieve_ExiteDefinicionTpCalculo", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrliIdDefinicion", CtrliIdDefinicion));
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        TpCalculosHd ls = new TpCalculosHd();
                        {
                            ls.iIdCalculosHd = int.Parse(data["Existe"].ToString());

                        };
                        list.Add(ls);
                    }
                }
                else
                {
                    TpCalculosHd ls = new TpCalculosHd();
                    {
                        ls.iIdCalculosHd = 0;

                    };
                    list.Add(ls);
                }
                data.Close(); cmd.Dispose(); conexion.Close(); //cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;

        }

        public TpCalculosHd sp_TpCalculos_Insert_TpCalculos(int CtrliIdDefinicionHd, int CtrliNominaCerrada)
        {
            TpCalculosHd bean = new TpCalculosHd();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_TpCalculos_Insert_TpCalculos", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrliIdDefinicionHd", CtrliIdDefinicionHd));
                cmd.Parameters.Add(new SqlParameter("@CtrliNominaCerrada", CtrliNominaCerrada));

                if (cmd.ExecuteNonQuery() > 0)
                {
                    bean.sMensaje = "success";
                }
                else
                {
                    bean.sMensaje = "error";
                }
                cmd.Dispose(); conexion.Close(); //cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return bean;
        }

        public TpCalculosHd sp_TpCalculos_update_TpCalculos(int CtrliIdDedinicionHD, int CtrliNominacerrada)
        {
            TpCalculosHd bean = new TpCalculosHd();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_TpCalculos_update_TpCalculos", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@CtrliIdDedinicionHD", CtrliIdDedinicionHD));
                cmd.Parameters.Add(new SqlParameter("@CtrliNominacerrada", CtrliNominacerrada));

                if (cmd.ExecuteNonQuery() > 0)
                {
                    bean.sMensaje = "success";
                }
                else
                {
                    bean.sMensaje = "error";
                }
                cmd.Dispose(); conexion.Close(); cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return bean;
        }


        public List<NominaLnDatBean> sp_TpDefinicionNomins_Retrieve_TpDefinicionNomins()
        {
            List<NominaLnDatBean> list = new List<NominaLnDatBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_TpDefinicionNomins_Retrieve_TpDefinicionNomins", this.conexion)
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
                        NominaLnDatBean ls = new NominaLnDatBean();
                        {
                            ls.iIdDefinicionln = data["IdDefinicion_Ln"].ToString();
                            ls.IdEmpresa = data["NombreEmpresa"].ToString();
                            ls.iRenglon = data["NombreRenglon"].ToString();
                            ls.iElementonomina = data["Cg_Elemento_Nomina_id"].ToString();
                            ls.iTipodeperiodo = data["Valor"].ToString();
                            ls.iIdperiodo = data["Periodo_id"].ToString();
                            ls.iIdAcumulado = data["Acumulado_id"].ToString();
                            ls.iEsespejo = data["Es_Espejo"].ToString();

                        };
                        list.Add(ls);
                    }
                }
                else
                {
                    list = null;
                }
                data.Close(); cmd.Dispose(); conexion.Close(); //cmd.Parameters.Clear();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;
        }
        public List<TipoEmpleadoBean> sp_Cgeneral_Retrieve_TipoEmpleadosBajas()
        {
            List<TipoEmpleadoBean> list = new List<TipoEmpleadoBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Cgeneral_Retrieve_TipoEmpleadosBajas", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        TipoEmpleadoBean ls = new TipoEmpleadoBean();
                        {
                            ls.IdTipo_Empleado = int.Parse(data["IdValor"].ToString());
                            ls.Descripcion = data["Valor"].ToString();
                        };
                        list.Add(ls);
                    }
                }
                else
                {
                    list = null;
                }
                data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;
        }
        public List<MotivoBajaBean> sp_Cgeneral_Retrieve_MotivoBajas()
        {
            List<MotivoBajaBean> list = new List<MotivoBajaBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Cgeneral_Retrieve_MotivoBajas", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        MotivoBajaBean ls = new MotivoBajaBean();
                        
                        ls.IdMotivo_Baja = int.Parse(data["IdValor"].ToString());
                        ls.Descripcion = data["Valor"].ToString();
                        
                        list.Add(ls);
                    }
                }
                else
                {
                    list = null;
                }
                data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;
        }
        public List<MotivoBajaBean> sp_Cgeneral_Retrieve_MotivoBajasxTe()
        {
            List<MotivoBajaBean> list = new List<MotivoBajaBean>();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Cgeneral_Retrieve_MotivoBajas", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader data = cmd.ExecuteReader();
                cmd.Dispose();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        MotivoBajaBean ls = new MotivoBajaBean();
                        

                        switch (int.Parse(data["IdValor"].ToString()))
                        {
                            case 0:
                            case 3: 
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 20:
                            case 21:
                            case 22:
                                ls.IdMotivo_Baja = int.Parse(data["IdValor"].ToString());
                                ls.TipoEmpleado_id = 21;
                                ls.Descripcion = data["Valor"].ToString();
                                break;
                            case 4:
                            case 5:
                                ls.IdMotivo_Baja = int.Parse(data["IdValor"].ToString());
                                ls.TipoEmpleado_id = 22;
                                ls.Descripcion = data["Valor"].ToString();
                                break;
                            case 18:
                                ls.IdMotivo_Baja = int.Parse(data["IdValor"].ToString());
                                ls.TipoEmpleado_id = 25;
                                ls.Descripcion = data["Valor"].ToString();
                                break;
                            case 19:
                                ls.IdMotivo_Baja = int.Parse(data["IdValor"].ToString());
                                ls.TipoEmpleado_id = 27;
                                ls.Descripcion = data["Valor"].ToString();
                                break;
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                                ls.IdMotivo_Baja = int.Parse(data["IdValor"].ToString());
                                ls.TipoEmpleado_id = 29;
                                ls.Descripcion = data["Valor"].ToString();
                                break;
                            case 17:
                            case 23:
                                ls.IdMotivo_Baja = int.Parse(data["IdValor"].ToString());
                                ls.TipoEmpleado_id = 30;
                                ls.Descripcion = data["Valor"].ToString();
                                break;
                            case 1:
                            case 2:
                                ls.IdMotivo_Baja = int.Parse(data["IdValor"].ToString());
                                ls.TipoEmpleado_id = 31;
                                ls.Descripcion = data["Valor"].ToString();
                                break;
                        }
                        
                        
                        list.Add(ls);
                    }
                }
                else
                {
                    list = null;
                }
                data.Close(); conexion.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return list;
        }
    }
}

