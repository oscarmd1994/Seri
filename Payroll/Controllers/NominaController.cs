using Payroll.Models.Beans;
using Payroll.Models.Daos;
using System.Collections.Generic;
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

    
        public PartialViewResult Consulta()
        {
            return PartialView();
        }

        public PartialViewResult Ejecucion( )
        {
          
            return PartialView();
        }


        //Guarda los datos de la Definicion
        [HttpPost]
        public JsonResult DefiNomina(string sNombreDefinicion, string sDescripcion, int iAno, int iCancelado)
        {
            NominahdBean bean = new NominahdBean();
            FuncionesNomina dao = new FuncionesNomina();
            int usuario = int.Parse(Session["iIdUsuario"].ToString());
            bean   =  dao.sp_DefineNom_insert_DefineNom(sNombreDefinicion, sDescripcion, iAno, iCancelado,usuario);
         
            return Json(bean);
        }

        // llena  listado de empresas
        public JsonResult LisEmpresas()
        {
            List<EmpresasBean> LE = new List<EmpresasBean>();
            FuncionesNomina Dao = new FuncionesNomina();
            LE = Dao.sp_CEmpresas_Retrieve_Empresas();
            return Json(LE);
        }

        // regresa el listado del periodo
        [HttpPost]
        public JsonResult LisTipPeriodo(string Ctrsvalor)
        {
            List<CTipoPeriodoBean> LTP = new List<CTipoPeriodoBean>();
            FuncionesNomina Dao = new FuncionesNomina();
            LTP = Dao.sp_CTipoPeriod_Retrieve_TiposPeriodos(Ctrsvalor);
            return Json(LTP);
        }
        // regresa el listado de renglon
        [HttpPost]
        public JsonResult LisRenglon(string sNombreEmpresa)
        {
            List<CRenglonesBean> LR = new List<CRenglonesBean>();
            FuncionesNomina Dao = new FuncionesNomina();
            LR = Dao.sp_CRenglones_Retrieve_CRenglones(sNombreEmpresa);
            return Json(LR);
        }

        // regresa el listado de acumulado 
        [HttpPost]
        public JsonResult LisAcumulado(string sNombreEmpresa, int iIdRenglon)
        {
            List<CAcumuladosRenglon> LAc = new List<CAcumuladosRenglon>();
            FuncionesNomina Dao = new FuncionesNomina();
            LAc = Dao.sp_CAcumuladoREnglones_Retrieve_CAcumuladoREnglones(sNombreEmpresa, iIdRenglon);
            return Json(LAc);
        }

        // devuelve el ultimo ID
        public JsonResult IdmaxDefiniconNom()
        {
            List<NominahdBean> Idmax = new List<NominahdBean>();
            FuncionesNomina Dao = new FuncionesNomina();
            Idmax = Dao.sp_IdDefinicionNomina_Retrieve_IdDefinicionNomina();
            return Json(Idmax);
        }
        
        //Devuelve el valor de la columna cancelado del ultimo regristro 
        public JsonResult DefCancelado(int iIdFinicion)
        {
            List<NominahdBean> DefCancelado = new List<NominahdBean>();
            FuncionesNomina Dao = new FuncionesNomina();
            DefCancelado = Dao.sp_DefCancelados_Retrieve_DefCancelados(iIdFinicion);
            return Json(DefCancelado);
        }

        //Guarda los datos de la DefinicionLn
        [HttpPost]
        public JsonResult insertDefinicioNl(int iIdDefinicionHd, int iIdEmpresa, int iTipodeperiodo, int iIdperiodo,int iRenglon,int iCancelado, int iElementonomina,int iEsespejo,int iIdAcumulado)
        {
            NominaLnBean bean = new NominaLnBean();
            FuncionesNomina dao = new FuncionesNomina();
            int usuario = int.Parse(Session["iIdUsuario"].ToString());
            bean = dao.sp_CDefinicionLN_insert_CDefinicionLN(iIdDefinicionHd, iIdEmpresa, iTipodeperiodo, iIdperiodo, iRenglon, iCancelado, usuario, iElementonomina, iEsespejo, iIdAcumulado);

            return Json(bean);
        }

        // Regresa el listado de perido
        [HttpPost]

        public JsonResult ListPeriodo(int iIdEmpresesas, int ianio, int iTipoPeriodo)
        {
            List<CInicioFechasPeriodoBean> LPe = new List<CInicioFechasPeriodoBean>();       
            FuncionesNomina dao = new FuncionesNomina();       
            LPe= dao.sp_Cperiodo_Retrieve_Cperiodo(iIdEmpresesas, ianio, iTipoPeriodo);
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
            if (Dt != null) {
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

        public JsonResult ListadoNomDefinicion() {

            List<NominahdBean> LNND= new List<NominahdBean>();
            FuncionesNomina Dao = new FuncionesNomina();
            LNND = Dao.sp_DefinicionNombresHd_Retrieve_DefinicionNombresHd();
            return Json(LNND);
        }

        public JsonResult TpDefinicionNomina() {

            List<NominahdBean> LNH = new List<NominahdBean>();
            FuncionesNomina dao = new FuncionesNomina();
            LNH = dao.sp_TpDefinicionesNom_Retrieve_TpDefinicionNom();

            for (int i = 0; i < LNH.Count; i++) {

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
        public JsonResult TpDefinicionNominaQry(string sNombreDefinicion , int iCancelado) {
            if (sNombreDefinicion == "Selecciona") {
                sNombreDefinicion = "";
            }

            List<NominahdBean> TD = new List<NominahdBean>();
            FuncionesNomina dao = new FuncionesNomina();
            TD = dao.sp_DeficionNominaCancelados_Retrieve_DeficionNominaCancelados(sNombreDefinicion, iCancelado);

            if (TD != null) { 

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
        public JsonResult UpdatePtDefinicionNl(int iIdDefinicionln, int iIdEmpresa, int iTipodeperiodo, int iIdperiodo, int iRenglon , int iEsespejo,int iIdAcumulado)
        {
            NominaLnBean bean = new NominaLnBean();
            FuncionesNomina dao = new FuncionesNomina();
            bean = dao.sp_TpDefinicionNomLn_Update_TpDefinicionNomLn(iIdDefinicionln, iIdEmpresa, iTipodeperiodo, iIdperiodo, iRenglon, iEsespejo, iIdAcumulado);
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


        public JsonResult TpDefinicionnl()
        {
            List<NominaLnDatBean> Dta = new List<NominaLnDatBean>();
            List<NominaLnDatBean> DA = new List<NominaLnDatBean>();
            FuncionesNomina dao = new FuncionesNomina();
            Dta = dao.sp_TpDefinicionNomins_Retrieve_TpDefinicionNomins();
            if (Dta != null)
            {
                for (int i = 0; i < Dta.Count; i++)
                {
                    if (Dta[i].iElementonomina == "39")
                    {
                        Dta[i].iElementonomina = "Percepciones";
                    }

                    if (Dta[i].iElementonomina == "40")
                    {
                        Dta[i].iElementonomina = "Deducciones";
                    }


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


    }
}