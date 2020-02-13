using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Payroll.Models.Utilerias
{
    public class Conexion
    {

        //static readonly string Server = "GSERIPROD01";
        //static readonly string Db = "IPSNet";
        //static readonly string User = "IPSNet";
        //static readonly string Pass = "IPSNet2";
        //*
        //static readonly string Server = "192.168.51.9";
        //static readonly string Db = "IPSNet";
        //static readonly string User = "IPSNet";
        //static readonly string Pass = "IPSNet2";

        static readonly string Server = "201.149.34.185,15002";
        static readonly string Db = "IPSNet";
        static readonly string User = "sa";
        static readonly string Pass = "S3R2017.t3";
        protected SqlConnection conexion { get; set; }

        protected SqlConnection Conectar()
        {
            try
            {
                conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + Db + ";User ID=" + User + ";Password=" + Pass + ";Integrated Security=False");
                conexion.Open();
                return conexion;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return null;
            }
        }

    }
}