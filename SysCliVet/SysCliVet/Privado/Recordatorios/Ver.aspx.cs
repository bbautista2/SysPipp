using CapaEntidad;
using CapaLibreria.Base;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.Recordatorios
{
    public partial class Ver : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Object Recordatorio_Listar()
        {
            clsBaseEntidad baseEntidad = new clsBaseEntidad();
            List<Recordatorio> lstRecordatorios = new List<Recordatorio>();
            List<Object> lstObject = new List<object>();
            try
            {
                lstRecordatorios = clsLogica.Instance.Recordatorio_ObtenerTodo(ref baseEntidad);
                foreach (Recordatorio recordatorio in lstRecordatorios)
                {
                    lstObject.Add(new
                    {
                        title = recordatorio.Descripcion + " - " + recordatorio.Mascota.Nombre,
                        start = recordatorio.Fecha,
                        allDay = true
                    });
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            return lstObject;
        }

    }
}