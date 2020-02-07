﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll.Models.Beans
{
    public class NominaBean
    {



    }

    public class NominahdBean
    {

        public int iIdDefinicionhd { get; set; }
        public string sNombreDefinicion { get; set; }
        public string sDescripcion { get; set; }
        public int iAno { get; set; }
        public string iCancelado { get; set; }
        public int iUsuarioAlta { get; set; }
        public string sFechaAlta { get; set; }

        public string sMensaje { get; set; }

    }

    public class NominaLnBean
    {
        public int iIdDefinicionln { get; set; }
        public int iIdDefinicionHd { get; set; }
        public int iIdEmpresa { get; set; }
        public int iTipodeperiodo { get; set; }
        public int iIdperiodo { get; set; }
        public int iRenglon { get; set; }
        public int iCancelado { get; set; }
        public int iIdusuarioalta { get; set; }
        public string sFechaalta { get; set; }
        public int iElementonomina { get; set; }
        public int iEsespejo { get; set; }

        public int iIdAcumulado { get; set; }

        public string sMensaje { get; set; }

    }

    public class CTipoPeriodoBean
    {
        public int iId { get; set; }
        public string sValor { get; set; }

        public string sMensaje { get; set; }
    }

    public class CRenglonesBean
    {
        public int iIdEmpresa { get; set; }
        public int iIdRenglon { get; set; }
        public string sNombreRenglon { get; set; }
        public int iIdElementoNomina { get; set; }
        public int iIdSeccionReporte { get; set; }
        public int iIdAcumulado { get; set; }
        public int iCancelado { get; set; }
        public string sMensaje { get; set; }
    }


    public class CAcumuladosRenglon
    { 
     public int iIdEmpresa { get; set; }
     public int iIdRenglon { get; set; }
     public int iIdAcumulado { get; set; } 
     public string sDesAcumulado { get; set; }
     public string sCuentaContable { get; set; }
     public string sDesConcepto { get; set; }
     public string sMensaje { get; set; }

    }

    public class CInicioFechasPeriodoBean
    { 
        public int iId { get; set; }
        public int iIdEmpresesas { get; set; }
        public int ianio { get; set; }
        public int iTipoPeriodo { get; set; }
        public int iPeriodo { get; set; }
        public int iNominaCerrada { get; set; }
        public string sFechaInicio { get; set; }
        public string sFechaFinal { get; set; }
        public string sFechaProceso { get; set; }
        public string sFechaPago { get; set; }
        public int iDiasEfectivos { get; set; }
       
    
    }

    public class NominaLnDatBean
    {
        public string iIdDefinicionln { get; set; }
        public string iIdDefinicionHd { get; set; }
        public string IdEmpresa { get; set; }
        public string iTipodeperiodo { get; set; }
        public string iIdperiodo { get; set; }
        public string iRenglon { get; set; }
        public string iCancelado { get; set; }
        public string iIdusuarioalta { get; set; }
        public string sFechaalta { get; set; }
        public string iElementonomina { get; set; }
        public string iEsespejo { get; set; }

        public string iIdAcumulado { get; set; }

        public string sMensaje { get; set; }

    }

    public class NominasHdDatBean
    {
        public string iIdDefinicionhd { get; set; }
        public string sNombreDefinicion { get; set; }
        public string sDescripcion { get; set; }
        public string iAno { get; set; }
        public string iCancelado { get; set; }
        public string iUsuarioAlta { get; set; }
        public string sFechaAlta { get; set; }
        public string sMensaje { get; set; }


    }
}