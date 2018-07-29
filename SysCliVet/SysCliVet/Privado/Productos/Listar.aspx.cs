using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.Productos
{
    public partial class Ver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Mascota_Listar()
        {
            clsBaseEntidad baseEntidad = new clsBaseEntidad();
            DataTable dt = null;
            List<Object> lst = new List<Object>();
            try
            {
                dt = clsLogica.Instance.Mascota_Listar(ref baseEntidad);

                foreach (DataRow item in dt.Rows)
                {
                    var Mascota = new
                    {
                        Id = HttpUtility.UrlEncode(clsEncriptacion.Encriptar(item["ID"].ToString())),
                        Nombre = item["Nombre"],
                        Propietario = item["Nombre_Propietario"],
                        Progreso = 0,                        
                        Estado = item["Estado"]
                    };
                    lst.Add(Mascota);
                }

                hfListadoProductos.Value = (new JavaScriptSerializer()).Serialize(lst);

            }
            catch (Exception ex)
            {

            }
        }

        [WebMethod]
        public static Object EliminarMascota(String id)
        {
            Boolean resultado = false;

            try
            {
                Int32 idMascota = Convert.ToInt32(clsEncriptacion.Desencriptar(HttpUtility.UrlDecode(id)));

                clsBaseEntidad baseEntidad = new clsBaseEntidad();

                resultado = clsLogica.Instance.Mascota_EliminarPorId(ref baseEntidad, idMascota);

                if (resultado)
                    return new { Lista = ObtenerMascotas(), correcto = true, mensaje = "Productos Eliminada Correctamente" };
                else
                    return new { Lista = new List<Object>(), correcto = false, mensaje = "Ha ocurrido un Error Eliminando el Productos" };

            }
            catch (Exception)
            {
                return new { Lista = new List<Object>(), correcto = false, mensaje = "Ha ocurrido un error eliminando el producto [1]" };
            }
        }

        [WebMethod]
        public static List<Object> ObtenerMascotas()
        {
            List<Object> lst = new List<Object>();
            try
            {
                clsBaseEntidad baseEntidad = new clsBaseEntidad();
                DataTable dt = clsLogica.Instance.Mascota_Listar(ref baseEntidad);
                if (baseEntidad.Errores.Count == 0)
                {
                    if (dt != null)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            lst.Add(new
                            {
                                Id = HttpUtility.UrlEncode(clsEncriptacion.Encriptar(item["ID"].ToString())),
                                Nombre = item["Nombre"],
                                Propietario = item["Nombre_Propietario"],
                                Progreso = 0,                             
                                Estado = item["Estado"]
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                lst = null;
            }
            return lst;
        }
    }
}