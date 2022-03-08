using Microsoft.Extensions.Configuration;
using Sauron_Monitor_Integraciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Helpers
{
    public class Leer_JSON
    {

        public static string leerJson_strConexion()
        {

            //Leer archivo appsettings.json
            var builder = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            //logFile = configuration["Logging:LogFile"] //Ejemplo para leer los nodos del archivo Json; 

            return configuration["strConexionSQL"];

        }


        public static string leerJson_strConexion_WMS()
        {
            //Leer archivo appsettings.json
            var builder = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            //logFile = configuration["Logging:LogFile"] //Ejemplo para leer los nodos del archivo Json; 

            return configuration["strConexionWMS"];

        }

        public static string strConexion_Commercial_Effectiveness()
        {
            //Leer archivo appsettings.json
            var builder = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            //logFile = configuration["Logging:LogFile"] //Ejemplo para leer los nodos del archivo Json; 

            return configuration["strConexion_Commercial_Effectiveness"];

        }


        public static string leerJson_rutaPlantillasExcel()
        {
            try
            {
                //Leer archivo appsettings.json
                var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                var configuration = builder.Build();
                //logFile = configuration["Logging:LogFile"] //Ejemplo para leer los nodos del archivo Json; 

                return configuration["rutaPlantillasExcel"];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static string leerJson_rutaPlanos()
        {
            //Leer archivo appsettings.json
            var builder = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            //logFile = configuration["Logging:LogFile"] //Ejemplo para leer los nodos del archivo Json; 

            return configuration["rutaPlanos"];

        }

        public static UNOEE_Peticion_Model leerJson_configUNOEE_CE()
        {

            UNOEE_Peticion_Model objDatos = new UNOEE_Peticion_Model();

            //Leer archivo appsettings.json
            var builder = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            objDatos.IdCia = configuration["UNOEE_Model_CE:IdCia"];
            objDatos.NombreConexion = configuration["UNOEE_Model_CE:NombreConexion"].ToString();
            objDatos.Usuario = configuration["UNOEE_Model_CE:Usuario"];
            objDatos.Clave = configuration["UNOEE_Model_CE:Clave"];         

            return objDatos;

        }

    }
}
