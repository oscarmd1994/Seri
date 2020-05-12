﻿using Payroll.Models.Beans;
using Payroll.Models.Daos;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Payroll.Controllers
{
    public class NominaController : Controller
    {
        
        // GET: Nomina
        public PartialViewResult AltaDefinicion()
        {
            return PartialView();
        }
<<<<<<< HEAD


        public PartialViewResult Consulta()
        {
            return PartialView();
        }

        public PartialViewResult Ejecucion()
        {

=======
        public PartialViewResult BajasEmpleados()
        {
            return PartialView();
        }
        public PartialViewResult Consulta()
        {
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400
            return PartialView();
        }
        public PartialViewResult Ejecucion()
        {

<<<<<<< HEAD
        public PartialViewResult MonitorProcesos()
        {
            return PartialView();
        
        }
<<<<<<< HEAD


=======
            return PartialView();
        }
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400
=======
        public PartialViewResult MonitorProcesos()
        {
            return PartialView();

        }

        public PartialViewResult Dispersion()
        {
            return PartialView();
        }


>>>>>>> 372449f08200e247f5d4c46af2d806e69867fc5a
        //Guarda los datos de la Definicion
        [HttpPost]
        public JsonResult DefiNomina(string sNombreDefinicion, string sDescripcion, int iAno, int iCancelado)
        {
            NominahdBean bean = new NominahdBean();
            FuncionesNomina dao = new FuncionesNomina();
            int usuario = int.Parse(Session["iIdUsuario"].ToString());
            bean = dao.sp_DefineNom_insert_DefineNom(sNombreDefinicion, sDescripcion, iAno, iCancelado, usuario);

            return Json(bean);
        }
        // llena  listado de empresas
        [HttpPost]
        public JsonResult LisEmpresas()
        {
            List<EmpresasBean> LE = new List<EmpresasBean>();
            FuncionesNomina Dao = new FuncionesNomina();
            LE = Dao.sp_CEmpresas_Retrieve_Empresas();
            if (LE.Count > 0)
            {
                for (int i = 0; i < LE.Count - 1; i++)
                {
                    LE[i].sNombreEmpresa = LE[i].iIdEmpresa + " " + LE[i].sNombreEmpresa;
                }
            }

            return Json(LE);
        }
        // regresa el listado del periodo
        [HttpPost]
        public JsonResult LisTipPeriodo(int IdEmpresa)
        {
          
            
            List<CTipoPeriodoBean> LTP = new List<CTipoPeriodoBean>();
            FuncionesNomina Dao = new FuncionesNomina();
            LTP = Dao.sp_CTipoPeriod_Retrieve_TiposPeriodos(IdEmpresa);
            return Json(LTP);
        }
        // regresa el listado de renglon
        [HttpPost]
        public JsonResult LisRenglon(int IdEmpresa)
        {
            List<CRenglonesBean> LR = new List<CRenglonesBean>();
            FuncionesNomina Dao = new FuncionesNomina();
            LR = Dao.sp_CRenglones_Retrieve_CRenglones(IdEmpresa);
            return Json(LR);
        }
        // regresa el listado de acumulado 
        [HttpPost]
        public JsonResult LisAcumulado(int iIdEmpresa, int iIdRenglon)
        {
            List<CAcumuladosRenglon> LAc = new List<CAcumuladosRenglon>();
            FuncionesNomina Dao = new FuncionesNomina();
            LAc = Dao.sp_CAcumuladoREnglones_Retrieve_CAcumuladoREnglones(iIdEmpresa, iIdRenglon);
            return Json(LAc);
        }
        // devuelve el ultimo ID
        [HttpPost]
        public JsonResult IdmaxDefiniconNom()
        {
            List<NominahdBean> Idmax = new List<NominahdBean>();
            FuncionesNomina Dao = new FuncionesNomina();
            Idmax = Dao.sp_IdDefinicionNomina_Retrieve_IdDefinicionNomina();
            return Json(Idmax);
        }
<<<<<<< HEAD

=======
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400
        //Devuelve el valor de la columna cancelado del ultimo regristro 
        [HttpPost]
        public JsonResult DefCancelado(int iIdFinicion)
        {
            List<NominahdBean> DefCancelado = new List<NominahdBean>();
            FuncionesNomina Dao = new FuncionesNomina();
            DefCancelado = Dao.sp_DefCancelados_Retrieve_DefCancelados(iIdFinicion);
            return Json(DefCancelado);
        }
        //Guarda los datos de la DefinicionLn
        [HttpPost]
<<<<<<< HEAD
        public JsonResult insertDefinicioNl(int iIdDefinicionHd, int iIdEmpresa, int iTipodeperiodo, /*int iIdperiodo,*/ int iRenglon, int iCancelado, int iElementonomina, int iEsespejo, int iIdAcumulado)
=======
        public JsonResult insertDefinicioNl(int iIdDefinicionHd, int iIdEmpresa, int iTipodeperiodo, int iRenglon, int iCancelado, int iElementonomina, int iEsespejo, int iIdAcumulado)
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400
        {
            NominaLnBean bean = new NominaLnBean();
            FuncionesNomina dao = new FuncionesNomina();
            int usuario = int.Parse(Session["iIdUsuario"].ToString());
<<<<<<< HEAD
            bean = dao.sp_CDefinicionLN_insert_CDefinicionLN(iIdDefinicionHd, iIdEmpresa, iTipodeperiodo, /*iIdperiodo,*/ iRenglon, iCancelado, usuario, iElementonomina, iEsespejo, iIdAcumulado);
=======
            bean = dao.sp_CDefinicionLN_insert_CDefinicionLN(iIdDefinicionHd, iIdEmpresa, iTipodeperiodo, iRenglon, iCancelado, usuario, iElementonomina, iEsespejo, iIdAcumulado);
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400

            return Json(bean);
        }
        // Regresa el listado de periodo
        [HttpPost]
        public JsonResult ListPeriodo(int iIdEmpresesas, int ianio, int iTipoPeriodo)
        {
            List<CInicioFechasPeriodoBean> LPe = new List<CInicioFechasPeriodoBean>();
            FuncionesNomina dao = new FuncionesNomina();
            LPe = dao.sp_Cperiodo_Retrieve_Cperiodo(iIdEmpresesas, ianio, iTipoPeriodo);
            return Json(LPe);
        }
        // llena datos de la tabla de Percepciones
        [HttpPost]
        public JsonResult listdatosPercesiones(int iIdDefinicionln)
        {
            List<NominaLnDatBean> Dt = new List<NominaLnDatBean>();
            List<NominaLnDatBean> DA = new List<NominaLnDatBean>();
            FuncionesNomina dao = new FuncionesNomina();
            Dt = dao.sp_DefinicionesNomLn_Retrieve_DefinicionesNomLn(iIdDefinicionln);
            if (Dt != null)
            {
                for (int i = 0; i < Dt.Count; i++)
                {

                    if (Dt[i].iEsespejo == "True")
                    {
                        Dt[i].iEsespejo = "Si";
                    }

                    else if (Dt[i].iEsespejo == "False")
                    {
                        Dt[i].iEsespejo = "No";
                    }

                    if (Dt[i].iIdAcumulado == "0")
                    {

                        Dt[i].iIdAcumulado = "";
                    }

                    if (Dt[i].iIdAcumulado != "0" && Dt[i].iIdAcumulado != "" && Dt[i].iIdAcumulado != " ")
                    {

                        int num = int.Parse(Dt[i].iIdAcumulado);
                        DA = dao.sp_DescripAcu_Retrieve_DescripAcu(num);
                        Dt[i].iIdAcumulado = DA[0].iIdAcumulado;

                    }

                }

            }



            return Json(Dt);
        }
        [HttpPost]
        public JsonResult listdatosDeducuiones(int iIdDefinicionln)
        {
            List<NominaLnDatBean> Dta = new List<NominaLnDatBean>();
            List<NominaLnDatBean> DA = new List<NominaLnDatBean>();
            FuncionesNomina dao = new FuncionesNomina();
            Dta = dao.sp_DefinicionesDeNomLn_Retrieve_DefinicionesDeNomLn(iIdDefinicionln);
            if (Dta != null)
            {
                for (int i = 0; i < Dta.Count; i++)
                {

                    if (Dta[i].iEsespejo == "True")
                    {
                        Dta[i].iEsespejo = "Si";
                    }

                    else if (Dta[i].iEsespejo == "False")
                    {
                        Dta[i].iEsespejo = "No";
                    }

                    if (Dta[i].iIdAcumulado == "0")
                    {

                        Dta[i].iIdAcumulado = "";
                    }



                    if (Dta[i].iIdAcumulado != "0" && Dta[i].iIdAcumulado != "" && Dta[i].iIdAcumulado != " ")
                    {

                        int num = int.Parse(Dta[i].iIdAcumulado);
                        DA = dao.sp_DescripAcu_Retrieve_DescripAcu(num);
                        Dta[i].iIdAcumulado = DA[0].iIdAcumulado;

                    }

                }
            }


            return Json(Dta);
        }
        [HttpPost]
        public JsonResult ListadoNomDefinicion()
        {

<<<<<<< HEAD
        public JsonResult ListadoNomDefinicion()
        {

=======
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400
            List<NominahdBean> LNND = new List<NominahdBean>();
            FuncionesNomina Dao = new FuncionesNomina();
            LNND = Dao.sp_DefinicionNombresHd_Retrieve_DefinicionNombresHd();
            return Json(LNND);
        }
<<<<<<< HEAD

=======
        [HttpPost]
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400
        public JsonResult TpDefinicionNomina()
        {

            List<NominahdBean> LNH = new List<NominahdBean>();
            FuncionesNomina dao = new FuncionesNomina();
            LNH = dao.sp_TpDefinicionesNom_Retrieve_TpDefinicionNom();

            for (int i = 0; i < LNH.Count; i++)
            {

                if (LNH[i].iCancelado == "True")
                {
                    LNH[i].iCancelado = "Si";
                }

                else if (LNH[i].iCancelado == "False")
                {
                    LNH[i].iCancelado = "No";
                }

            }

            return Json(LNH);
        }
        [HttpPost]
        public JsonResult TpDefinicionNominaQry(string sNombreDefinicion, int iCancelado)
        {
            if (sNombreDefinicion == "Selecciona")
            {
                sNombreDefinicion = "";
            }

            List<NominahdBean> TD = new List<NominahdBean>();
            FuncionesNomina dao = new FuncionesNomina();
            TD = dao.sp_DeficionNominaCancelados_Retrieve_DeficionNominaCancelados(sNombreDefinicion, iCancelado);

            if (TD != null)
            {

                for (int i = 0; i < TD.Count; i++)
                {

                    if (TD[i].iCancelado == "True")
                    {
                        TD[i].iCancelado = "Si";
                    }

                    else if (TD[i].iCancelado == "False")
                    {
                        TD[i].iCancelado = "No";
                    }
                }
            }

            return Json(TD);
        }
        [HttpPost]
        public JsonResult UpdatePtDefinicion(string sNombreDefinicion, string sDescripcion, int iAno, int iCancelado, int iIdDefinicionhd)
        {
            NominahdBean bean = new NominahdBean();
            FuncionesNomina dao = new FuncionesNomina();
            bean = dao.sp_TpDefinicion_Update_TpDefinicion(sNombreDefinicion, sDescripcion, iAno, iCancelado, iIdDefinicionhd);
            return Json(bean);
        }
        [HttpPost]
        public JsonResult DeleteDefinicion(int iIdDefinicionhd)
        {
            NominahdBean bean = new NominahdBean();
            FuncionesNomina dao = new FuncionesNomina();
            bean = dao.sp_EliminarDefinicion_Delete_EliminarDefinicion(iIdDefinicionhd);
            return Json(bean);

        }
        [HttpPost]
        public JsonResult UpdatePtDefinicionNl(int iIdDefinicionln, int iIdEmpresa, int iTipodeperiodo, int iRenglon, int iEsespejo, int iIdAcumulado)
        {
            NominaLnBean bean = new NominaLnBean();
            FuncionesNomina dao = new FuncionesNomina();
            bean = dao.sp_TpDefinicionNomLn_Update_TpDefinicionNomLn(iIdDefinicionln, iIdEmpresa, iTipodeperiodo, iRenglon, iEsespejo, iIdAcumulado);
            return Json(bean);
        }
        [HttpPost]
        public JsonResult DeleteDefinicionNl(int iIdDefinicionln)
        {
            NominaLnBean Bean = new NominaLnBean();
            FuncionesNomina dao = new FuncionesNomina();
            Bean = dao.sp_EliminarDefinicionNl_Delete_EliminarDefinicionNl(iIdDefinicionln);
            return Json(Bean);
        }
        [HttpPost]
        public JsonResult CompruRegistroExit(int iIdDefinicionHd)
        {
            List<TpCalculosHd> LNND = new List<TpCalculosHd>();
            FuncionesNomina Dao = new FuncionesNomina();
            LNND = Dao.sp_ExiteDefinicionTpCalculo_Retrieve_ExiteDefinicionTpCalculo(iIdDefinicionHd);
            return Json(LNND);

        }
        //Guarda los datos de TpCalculos
        [HttpPost]
        public JsonResult InsertDatTpCalculos(int iIdDefinicionHd, int iNominaCerrada)
        {
            TpCalculosHd bean = new TpCalculosHd();
            FuncionesNomina dao = new FuncionesNomina();
            bean = dao.sp_TpCalculos_Insert_TpCalculos(iIdDefinicionHd, iNominaCerrada);
            return Json(bean);
<<<<<<< HEAD

        }
=======
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400

        }
        // Actualiza PTCalculoshd
        [HttpPost]
        public JsonResult UpdateCalculoshd(int iIdDefinicionHd, int iNominaCerrada)
        {
            TpCalculosHd bean = new TpCalculosHd();
            FuncionesNomina dao = new FuncionesNomina();
            bean = dao.sp_TpCalculos_update_TpCalculos(iIdDefinicionHd, iNominaCerrada);
            return Json(bean);
        }
<<<<<<< HEAD
<<<<<<< HEAD

        [HttpPost]
        public JsonResult ListTpCalculoln(int iIdEmpresa)
        {      
            List<TpCalculosLn> Dta = new List<TpCalculosLn>();
            //List<NominaLnDatBean> DA = new List<NominaLnDatBean>();
=======
=======
        



>>>>>>> 372449f08200e247f5d4c46af2d806e69867fc5a
        [HttpPost]
        public JsonResult TpDefinicionnl()
        {
            List<NominaLnDatBean> Dta = new List<NominaLnDatBean>();
            List<NominaLnDatBean> DA = new List<NominaLnDatBean>();
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400
            FuncionesNomina dao = new FuncionesNomina();
            Dta = dao.sp_IdEmpresasTPCalculoshd_Retrieve_IdEmpresasTPCalculoshd(iIdEmpresa);
            //if (Dta != null)
            //{
            //    for (int i = 0; i < Dta.Count; i++)
            //    {
            //        if (Dta[i].iElementonomina == "39")
            //        {
            //            Dta[i].iElementonomina = "Percepciones";
            //        }

            //        if (Dta[i].iElementonomina == "40")
            //        {
            //            Dta[i].iElementonomina = "Deducciones";
            //        }


            //        if (Dta[i].iEsespejo == "True")
            //        {
            //            Dta[i].iEsespejo = "Si";
            //        }

            //        else if (Dta[i].iEsespejo == "False")
            //        {
            //            Dta[i].iEsespejo = "No";
            //        }

            //        if (Dta[i].iIdAcumulado == "0")
            //        {

            //            Dta[i].iIdAcumulado = "";
            //        }



            //        if (Dta[i].iIdAcumulado != "0" && Dta[i].iIdAcumulado != "" && Dta[i].iIdAcumulado != " ")
            //        {

            //            int num = int.Parse(Dta[i].iIdAcumulado);
            //            DA = dao.sp_DescripAcu_Retrieve_DescripAcu(num);
            //            Dta[i].iIdAcumulado = DA[0].iIdAcumulado;

            //        }

            //    }
            //}


            //Startup obj = new Startup();

            //int op = 1, iIdjobs = 2, iIdTarea = 0;
            //obj.ConsultaTpJobs(op, iIdjobs, iIdTarea);

            //int iNominaCerrada = 1, idNum = 39;
            //obj.ActualizaCalculoshd(iNominaCerrada, idNum);
            //int IdJobs = 458;
            //obj.Reprocesos(IdJobs);

            return Json(Dta);
        }
<<<<<<< HEAD

        public JsonResult ListTBProcesosJobs()
        {
            int op1 = 0,op2=0, op3 = 0,CrtliIdJobs=0, CtrliIdTarea=0;
            List<TPProcesos> LTbProc = new List<TPProcesos>();
            FuncionesNomina dao = new FuncionesNomina();
            LTbProc = dao.sp_TPProcesosJobs_Retrieve_TPProcesosJobs(op1, op2, op3, CrtliIdJobs, CtrliIdTarea);
            return Json(LTbProc);
        }

        public JsonResult ListStatusProcesosJobs()
        {
            List<TPProcesos> LTbProc = new List<TPProcesos>();
            FuncionesNomina dao = new FuncionesNomina();
            LTbProc = dao.sp_EstatusJobsTbProcesos_retrieve_EstatusJobsTbProcesos();
            Startup obj = new Startup();
            obj.ActBDTbJobs();
            return Json(LTbProc);
        }

        public JsonResult ProcesosPots()
        {
            Startup obj = new Startup();
            int iNominaCerrada = 1, idNum = 39;
            obj.ActualizaCalculoshd(iNominaCerrada, idNum);
            return null;
        }


=======
        //Carga motivos de baja para select
        [HttpPost]
        public JsonResult LoadMotivoBaja()
        {
            List<MotivoBajaBean> bean;
            FuncionesNomina dao = new FuncionesNomina();
            bean = dao.sp_Cgeneral_Retrieve_MotivoBajas();
            return Json(bean);
        }
        //Carga tipos empleado para select
        [HttpPost]
        public JsonResult LoadTipoBaja()
        {
            List<TipoEmpleadoBean> bean;
            FuncionesNomina dao = new FuncionesNomina();
            bean = dao.sp_Cgeneral_Retrieve_TipoEmpleadosBajas();
            return Json(bean);
        }
        //Carga tipos empleado para select x tipo de empleado
        [HttpPost]
        public JsonResult LoadMotivoBajaxTe()
        {
            List<MotivoBajaBean> bean;
            FuncionesNomina dao = new FuncionesNomina();
            bean = dao.sp_Cgeneral_Retrieve_MotivoBajasxTe();
            return Json(bean);
        }
        [HttpPost]
        public JsonResult LoadDatosBaja()
        {
            List<string> bean;
            FuncionesNomina dao = new FuncionesNomina();
            var Empresa_id = int.Parse(Session["IdEmpresa"].ToString());
            var Empleado_id = int.Parse(Session["Empleado_id"].ToString());
            bean = dao.sp_TEmpleado_Nomina_Retrieve_DatosBaja(Empresa_id,Empleado_id);
            return Json(bean);
        }
<<<<<<< HEAD
>>>>>>> 6bfed6518806f6e6fa7b15ca26995c0c48d54400
=======



        [HttpPost]
        public JsonResult ListTpCalculoln(int iIdEmpresa)
        {
            List<TpCalculosLn> Dta = new List<TpCalculosLn>();
            //List<NominaLnDatBean> DA = new List<NominaLnDatBean>();
            FuncionesNomina dao = new FuncionesNomina();
            Dta = dao.sp_IdEmpresasTPCalculoshd_Retrieve_IdEmpresasTPCalculoshd(iIdEmpresa);
            //if (Dta != null)
            //{
            //    for (int i = 0; i < Dta.Count; i++)
            //    {
            //        if (Dta[i].iElementonomina == "39")
            //        {
            //            Dta[i].iElementonomina = "Percepciones";
            //        }

            //        if (Dta[i].iElementonomina == "40")
            //        {
            //            Dta[i].iElementonomina = "Deducciones";
            //        }


            //        if (Dta[i].iEsespejo == "True")
            //        {
            //            Dta[i].iEsespejo = "Si";
            //        }

            //        else if (Dta[i].iEsespejo == "False")
            //        {
            //            Dta[i].iEsespejo = "No";
            //        }

            //        if (Dta[i].iIdAcumulado == "0")
            //        {

            //            Dta[i].iIdAcumulado = "";
            //        }



            //        if (Dta[i].iIdAcumulado != "0" && Dta[i].iIdAcumulado != "" && Dta[i].iIdAcumulado != " ")
            //        {

            //            int num = int.Parse(Dta[i].iIdAcumulado);
            //            DA = dao.sp_DescripAcu_Retrieve_DescripAcu(num);
            //            Dta[i].iIdAcumulado = DA[0].iIdAcumulado;

            //        }

            //    }
            //}


            //Startup obj = new Startup();

            //int op = 1, iIdjobs = 2, iIdTarea = 0;
            //obj.ConsultaTpJobs(op, iIdjobs, iIdTarea);

            //int iNominaCerrada = 1, idNum = 39;
            //obj.ActualizaCalculoshd(iNominaCerrada, idNum);
            //int IdJobs = 458;
            //obj.Reprocesos(IdJobs);

            return Json(Dta);
        }

        public JsonResult ListTBProcesosJobs()
        {
            int op1 = 0, op2 = 0, op3 = 0, CrtliIdJobs = 0, CtrliIdTarea = 0;
            List<TPProcesos> LTbProc = new List<TPProcesos>();
            FuncionesNomina dao = new FuncionesNomina();
            LTbProc = dao.sp_TPProcesosJobs_Retrieve_TPProcesosJobs(op1, op2, op3, CrtliIdJobs, CtrliIdTarea);
            return Json(LTbProc);
        }

        public JsonResult ListStatusProcesosJobs()
        {
            List<TPProcesos> LTbProc = new List<TPProcesos>();
            FuncionesNomina dao = new FuncionesNomina();
            LTbProc = dao.sp_EstatusJobsTbProcesos_retrieve_EstatusJobsTbProcesos();
            Startup obj = new Startup();
            obj.ActBDTbJobs();
            return Json(LTbProc);
        }

        public JsonResult ProcesosPots()
        {
            Startup obj = new Startup();
            string NomProceso = "CNomina";
            obj.Proceso(NomProceso);

            return null;
        }



>>>>>>> 372449f08200e247f5d4c46af2d806e69867fc5a
    }

}