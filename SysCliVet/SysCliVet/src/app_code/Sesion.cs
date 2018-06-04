using System.Web;
using CapaEntidad;
using CapaLibreria.General;

namespace SysCliVet.src.app_code
{
    public class Sesion
    {        
        public static clsUsuario SsUsuario
        {
            get { return clsExtension.ObtenerSesion<clsUsuario>("Usuario") ?? RedirectUsuario<clsUsuario>(); }
            set { HttpContext.Current.Session["Usuario"] = value; }
        }
        private static T RedirectUsuario<T>()
        {
            HttpContext.Current.Response.Redirect("~/Publico/Acceso.aspx?back_url=" + HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri));
            return default(T);
        }
    }
}