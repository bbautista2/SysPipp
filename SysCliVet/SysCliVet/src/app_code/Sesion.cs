using System.Web;
using CapaEntidad;
using CapaLibreria.General;

namespace SysCliVet.src.app_code
{
    public class Sesion
    {        
        public static Usuario SsUsuario
        {
            get { return Extension.ObtenerSesion<Usuario>("NombreUsuario") ?? RedirectUsuario<Usuario>(); }
            set { HttpContext.Current.Session["NombreUsuario"] = value; }
        }
        private static T RedirectUsuario<T>()
        {
            HttpContext.Current.Response.Redirect("~/Publico/Acceso.aspx?back_url=" + HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri));
            return default(T);
        }
    }
}