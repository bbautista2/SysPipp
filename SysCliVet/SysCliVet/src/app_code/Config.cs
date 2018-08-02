using System;
using System.Web.Configuration;

namespace SysCliVet.src.app_code
{
    public class Config
    {
        public static String MascotaRutaFisica { get { return WebConfigurationManager.AppSettings["mrFisica"]; } }
        public static String MascotaRutaVirtual { get { return WebConfigurationManager.AppSettings["mrVirtual"]; } }

        public static String UrlPaginaPorDefecto { get { return WebConfigurationManager.AppSettings["UrlPaginaPorDefecto"]; } }
        public static String PacienteRutaFisica { get { return WebConfigurationManager.AppSettings["prFisica"]; } }
        public static String NombreCookie { get { return WebConfigurationManager.AppSettings["cNombre"]; } }
    }
}