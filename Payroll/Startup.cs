﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Payroll.Models.Beans;
using Payroll.Models.Utilerias;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;
using Payroll.Models.Daos;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(Payroll.Startup))]

namespace Payroll 
{
    public class Startup : Conexion
    {
        /// <summary>
        ///  configuracion del hangfire 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            // Para obtener más información sobre cómo configurar la aplicación, visite https://go.microsoft.com/fwlink/?LinkID=316888
<<<<<<< HEAD
            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source = DESKTOP-CNPFA5C; Initial Catalog=IPSNet; Integrated Security = true");
            app.UseHangfireDashboard();
       
=======
           // GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source = DESKTOP-CNPFA5C; Initial Catalog=IPSNet; Integrated Security = true");
            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source = 201.149.34.185,15002; Initial Catalog=IPSNet; User ID= IPSNet;Password= IPSNet2;Integrated Security= False");
            app.UseHangfireDashboard();
>>>>>>> 372449f08200e247f5d4c46af2d806e69867fc5a
            app.UseHangfireServer();
        }

        public void ConsultaTpJobs(int op, int iIdjobs,int iIdTarea)
        {
            // fecha del procesos 
            string FechaProceso = Fecha();
            // realiza la tarea 
            BackgroundJob.Enqueue(() => Proceso(op, iIdjobs, iIdTarea, FechaProceso));

            // guarda en la BD el proceso 
            List<HangfireJobs> id = new List<HangfireJobs>();
            FuncionesNomina Dao = new FuncionesNomina();
            id = Dao.sp_IdJobsHangfireJobs_Retrieve_IdJobsHangfireJobs(FechaProceso);
            int Idjobs = Convert.ToInt16(id[0].iId.ToString());
            string StatusJobs = "En Cola";
            string Nombrejobs = "ConsultaTpJobs";
            string Parametros =  op +","+ iIdjobs+"," + iIdTarea+","+ FechaProceso;
            Dao.Sp_TPProcesosJobs_insert_TPProcesosJobs(Idjobs, StatusJobs, Nombrejobs, Parametros);
        }

        /// <summary>
        ///  Actualiza  TPCalculosHdLn
        /// </summary>
        /// <param name="iNominaCerrada"></param>
        /// <param name="idNum"></param>
        public void ActualizaCalculoshd(int iNominaCerrada, int idNum)
        {
            // fecha del procesos 
            string FechaProceso = Fecha();
            // realiza la tarea 
            var jobId = BackgroundJob.Schedule(() => Actu(iNominaCerrada, idNum, FechaProceso), TimeSpan.FromMinutes(2));
           // var jobId = BackgroundJob.Enqueue(() => Actu(iNominaCerrada, idNum, FechaProceso));
            // guarda en la BD el proceso 
            List<HangfireJobs> id = new List<HangfireJobs>();
            FuncionesNomina Dao = new FuncionesNomina();
            id = Dao.sp_IdJobsHangfireJobs_Retrieve_IdJobsHangfireJobs(FechaProceso);
            int Idjobs = Convert.ToInt16(id[0].iId.ToString());
            string StatusJobs = "En Cola";
            string Nombrejobs = "ActualizaCalculoshd";
            string Parametros = iNominaCerrada + ","+ idNum+"," + FechaProceso;
            Dao.Sp_TPProcesosJobs_insert_TPProcesosJobs(Idjobs, StatusJobs, Nombrejobs, Parametros);
        }

        ///Procoeso cunsulta BD en la tabla TPProcesosJobs
        public List<TPProcesos> Proceso(int op,int iIdjobs, int iIdTarea, string tiempo)
        {
            int op1=0, op2=0, op3=0;
            if (op == 1) {
                op1 = 1;
                op2 = 0;
                op3 = 0;
            }

            if (op == 2)
            {
                op1 = 0;
                op2 = 1;
                op3 = 0;
            }

            if (op == 3)
            {
                op1 = 0;
                op2 = 0;
                op3 = 1;
            }

            List<TPProcesos> LE = new List<TPProcesos>();
            FuncionesNomina Dao = new FuncionesNomina();
            LE =Dao.sp_TPProcesosJobs_Retrieve_TPProcesosJobs(op1, op2, op3, iIdjobs, iIdTarea);
            return LE;
         
        }
        // Proceso, Actualiza BD Tp CalculosHd Ln
        public void Actu(int iNominaCerrada,int idNum, string fecha )
        {
            Controllers.NominaController obj = new Controllers.NominaController();
            obj.UpdateCalculoshd(idNum, iNominaCerrada);        
        }

        // vuelve a realizar la tarea selecionada 
        public void Reprocesos(int IdJobs)
        {
            // fecha del procesos 
            string FechaProceso = Fecha();
            int op = 1;
            int iIdTarea = 0;
            List<TPProcesos> LProce = new List<TPProcesos>();
            LProce = Proceso(op, IdJobs, iIdTarea, FechaProceso);
            string Nombrejobs = LProce[0].sNombre;
            string Parametros = LProce[0].sParametros;
            string[] valores = Parametros.Split(',');        

            if (Nombrejobs == "ActualizaCalculoshd") {
                ActualizaCalculoshd(Convert.ToInt16(valores[0]),Convert.ToInt16(valores[1]));
            }

        }

        // proceso actualiza en BD TpProcesosJons cada 30 segundos 
        public void ActBDTbJobs() {
            RecurringJob.AddOrUpdate(() => ProcesosContinuos(), Cron.Minutely);
            //var jobId = BackgroundJob.Enqueue(() => ProcesosContinuos());
        }
<<<<<<< HEAD
        public void ProcesosContinuos() 
        {
=======

        public void ProcesosContinuos() 
       {
>>>>>>> 372449f08200e247f5d4c46af2d806e69867fc5a
             FuncionesNomina Dao = new FuncionesNomina();
             Dao.sp_EstatusTpProcesosJobs_Update_EstatusTpProcesosJobs();     
        }
  
        public string Fecha() 
        {
            // fecha del procesos 
            string tiempo = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff");
            DateTime fecha = new DateTime();
            fecha = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff"));
            string day = fecha.Day.ToString();
            string month = fecha.Month.ToString();
            string year = fecha.Year.ToString();
            string hora = fecha.Hour.ToString();
            string minutos = fecha.Minute.ToString();
            string segundos = fecha.Second.ToString();
            string milsegundos = fecha.Millisecond.ToString();
            string fechajobs = year + "-" + month + "-" + day + " " + hora + ":" + minutos + ":" + segundos + ":" + milsegundos;
            return fechajobs;
        }

<<<<<<< HEAD
=======
        public void  Proceso( string NomProceso)
        {
            string FechaProceso = Fecha();

            if (NomProceso == "CNomina")
            {
             
                int anio = 2020;
                int TipoPeriodo = 3;
                int Periodo = 3;
                int IdDefinicion = 1;
                 var jobId = BackgroundJob.Enqueue(() => Cnomia(anio, TipoPeriodo, Periodo, IdDefinicion, FechaProceso));
                 List<HangfireJobs> id = new List<HangfireJobs>();
                 FuncionesNomina Dao = new FuncionesNomina();
                 id = Dao.sp_IdJobsHangfireJobs_Retrieve_IdJobsHangfireJobs(FechaProceso);
                int Idjobs = Convert.ToInt16(id[0].iId.ToString());
                string StatusJobs = "En Cola";
                string Nombrejobs = "CNomina1";
                string Parametros = anio + "," + TipoPeriodo + "," + Periodo + "," + IdDefinicion + "," + FechaProceso;
                Dao.Sp_TPProcesosJobs_insert_TPProcesosJobs(Idjobs, StatusJobs, Nombrejobs, Parametros);

            }

        }

        public void Cnomia(int anio, int TipoPeriodo, int Periodo, int IdDefinicion, string fecha) {

            FuncionesNomina Dao2 = new FuncionesNomina();
            Dao2.sp_CNomina_1(anio, TipoPeriodo, Periodo, IdDefinicion);


        }


>>>>>>> 372449f08200e247f5d4c46af2d806e69867fc5a

    }
}
