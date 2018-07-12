using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using SysCliVet.src.app_code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.Mascota
{
    public partial class Ver : System.Web.UI.Page
    {

        public Int32 mascotaId
        {
            get { return ViewState["ID"] != null ? (Int32)ViewState["ID"] : default(Int32); }
            set { ViewState["ID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["i"]))
            {
                String id = clsEncriptacion.Desencriptar(Request.QueryString["i"]);
                if (id != String.Empty)
                {
                    clsBaseEntidad baseEntidad = new clsBaseEntidad();
                    clsMascota objMascota = new clsMascota();
                    objMascota = clsLogica.Instance.Mascota_PorId(ref baseEntidad, Convert.ToInt32(id));
                    Mascota_MostrarInformacion(objMascota);
                }
            }
        }

        private void Mascota_MostrarInformacion(clsMascota objMascota) {
            lblNombreMascota.Text = objMascota.Nombre;
            lblRazaMascota.Text = objMascota.Raza;
            lblPesoMascota.Text = objMascota.Peso;
            lblEdadMascota.Text = objMascota.getEdad().ToString();
            ImgFotoMascota.ImageUrl = Config.MascotaRutaVirtual + "imagenes/" + objMascota.Foto;

        }
         

    }
}