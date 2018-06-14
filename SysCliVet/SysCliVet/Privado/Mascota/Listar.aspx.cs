using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using SysCliVet.src.app_code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.Mascota
{
    public partial class Listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Mascota_Listar();
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
                        Id = clsEncriptacion.Encriptar(item["ID"].ToString()),
                        Nombre = item["Nombre"],
                        Propietario = item["Nombre_Propietario"],
                        Progreso = 0,                        
                        Foto = Config.MascotaRutaVirtual + "imagenes/"+ item["Foto"],
                        Estado = item["Estado"]
                    };
                    lst.Add(Mascota);
                }

                hfListadoMascotas.Value = (new JavaScriptSerializer()).Serialize(lst);

            }
            catch (Exception ex)
            {

            }




        }
    }
}