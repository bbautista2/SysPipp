using System;
using System.Data.SqlClient;
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

        /// <summary>
        /// Obtiene el valor.
        /// </summary>
        /// <typeparam name="T">El tipo de dato almacenado en el registro.</typeparam>
        /// <param name="record">El registro.</param>
        /// <param name="columnName">Nombre de la columna.</param>
        /// <returns></returns>
        public static T ObtenerValorColumna<T>(this SqlDataReader registro, String nombreColumna)
        {
            return ObtenerValorColumna<T>(registro, nombreColumna, default(T));
        }


        /// <summary>
        /// Obtiene el valor.
        /// </summary>
        /// <typeparam name="T">El tipo de dato almacenado en el registro</typeparam>
        /// <param name="record">El registro.</param>
        /// <param name="columnName">Nombre de la columna.</param>
        /// <param name="defaultValue">El valor que devuelve si la columna contiene un <value>DBNull.Value</value> value.</param>
        /// <returns></returns>
        public static T ObtenerValorColumna<T>(this SqlDataReader objRegistro, String nombreColumna, T valorPorDefecto)
        {
            try
            {
                Object value = objRegistro[nombreColumna];
                if (value == null || value == DBNull.Value)
                {
                    return valorPorDefecto;
                }
                else
                {
                    if (valorPorDefecto == null && objRegistro[nombreColumna] is DateTime)
                    {
                        DateTime date = (DateTime)value;
                        Object sdate = date.ToString("MM/dd/yyyy");
                        return (T)sdate;
                    }
                    else

                        return (T)value;
                }
            }
            catch (Exception)
            {
                return valorPorDefecto;
            }

        }

    }
}
