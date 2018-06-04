using System;
using System.Web.Configuration;

namespace SysCliVet.src.app_code
{
    public class Config
    {
        public static String PacienteRutaFisica { get { return WebConfigurationManager.AppSettings["prFisica"]; } }
    }
}