using System.Web;

namespace CapaLibreria.General
{
    public static class clsExtension
    {
        public static T ObtenerSesion<T>(string nombreSesion)
        {
            T obj = default(T);
            try
            {
                if (HttpContext.Current != null)
                {
                    obj = (T)HttpContext.Current.Session[nombreSesion];
                }
                return (T)obj;

            }
            catch { return default(T); }
        }
    }
}
