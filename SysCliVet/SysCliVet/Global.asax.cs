using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using CapaLibreria;
using SysCliVet.src.app_code;

namespace SysCliVet
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            CapaLibreria.General.clsUtilidades.SessionStateServerSharedHelper.ChangeAppDomainAppId(Config.NombreCookie);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            try
            {
                Exception exc = Server.GetLastError();
                HttpContext.Current.Items["gasax_error"] = exc;
            }
            catch (Exception)
            {

            }
        }

    }
}