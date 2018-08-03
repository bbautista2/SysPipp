using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using SysCliVet.src.app_code;
using System;
using System.Web.UI;

namespace SysCliVet.Publico.InformacionQR
{
    public partial class Mascota : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObtenerInformacion();
            }
        }

        private void ObtenerInformacion()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["i"]))
            {
                String id = Encriptacion.Desencriptar(Request.QueryString["i"]);
                if (id != String.Empty)
                {
                    Int32 idMascota = Convert.ToInt32(id);
                    try
                    {
                        BaseEntidad baseEntidad = new BaseEntidad();
                        CapaEntidad.Mascota objMascota = new CapaEntidad.Mascota();
                        objMascota = Logica.Instance.Mascota_PorId(ref baseEntidad, idMascota);
                        if (baseEntidad.Errores.Count > 0)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error al mostrar el Paciente\"" + ");</script>", false);
                        }
                        MostrarInformacion(objMascota);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        private void MostrarInformacion(CapaEntidad.Mascota objMascota)
        {
            lblNombre.InnerText = objMascota.Nombre;
            lblFechaNac.InnerText = objMascota.FechaNacimiento.ToStringDate();
            lblRaza.InnerText = objMascota.Raza;
            lblColor.InnerText = objMascota.Color;
            lblSexo.InnerText = objMascota.Sexo == (Int16)EnumGeneroMascota.Macho ? "Macho" : "Hembra";
            hfNroPropietario.Value = objMascota.Propietario.Celular;
            ImgFotoMascota.ImageUrl = Config.MascotaRutaVirtual + "imagenes/" + objMascota.Foto;
        }

    }
}