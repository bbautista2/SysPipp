using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.Propietario
{
    public partial class Listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Propietario_Listar();
        }

        public void Propietario_Listar()
        {
            clsBaseEntidad baseEntidad = new clsBaseEntidad();
            DataTable dt = null;
            List<Object> lst = new List<Object>();
            try
            {
                dt = clsLogica.Instance.Propietario_Listar(ref baseEntidad);

                foreach (DataRow item in dt.Rows)
                {
                    var Propietario = new
                    {
                        Id = clsEncriptacion.Encriptar(item["ID"].ToString()),
                        Nombre = item["Nombre"] + " " + item["Apellidos"],
                        FechaNacimiento = DateTime.ParseExact(item["FechaNacimiento"].ToString(), "d", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd"),
                        Direccion = item["Direccion"],
                        Telefono = item["Telefono"],
                        Email = item["Email"],
                    };
                    lst.Add(Propietario);
                }

                hfListadoPropietarios.Value = (new JavaScriptSerializer()).Serialize(lst);

            } catch (Exception ex) {

            }
            

            

        }


    }
}