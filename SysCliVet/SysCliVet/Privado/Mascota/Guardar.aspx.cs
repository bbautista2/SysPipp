using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.Mascota
{
    public partial class Guardar : Page
    {
        public Int32 vsId
        {
            get { return ViewState["ID"] != null ? (Int32)ViewState["ID"] : default(Int32); }
            set { ViewState["ID"] = value; }
        }
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
                String id = clsEncriptacion.Desencriptar(Request.QueryString["i"]);
                if (id != String.Empty)
                {
                    vsId = Convert.ToInt32(id);
                    try
                    {
                        clsBaseEntidad baseEntidad = new clsBaseEntidad();
                        clsMascota objMascota = new clsMascota();
                        objMascota = clsLogica.Instance.Mascota_PorId(ref baseEntidad, vsId);
                        if (objMascota.Id == 0) { Volver(); }
                        MostrarInformacion(objMascota);
                    }
                    catch (Exception ex)
                    {

                    }

                }
                else
                {
                    Volver();
                }
            }
        }

        public void Volver()
        {
            Response.Redirect("Listar.aspx");
        }

        private void MostrarInformacion(clsMascota objMascota)
        {
            txtNombre.Value = objMascota.Nombre;
            txtFechaNac.Value = objMascota.FechaNacimiento.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            txtRaza.Value = objMascota.Raza;
            txtColor.Value = objMascota.Color;
            txtEspecie.Value = objMascota.Especie;
            txtGenero1.Checked = objMascota.Sexo==1;
            txtGenero2.Checked = objMascota.Sexo==2;
            //txtIntac.Value = objMascota.Intac;
            //txtCast.Value = objMascota.Cast;
            txtPeso.Value = objMascota.Peso;
            txtMarcaDist.Value = objMascota.MarcaDistintiva;
            txtPropietario.Value = objMascota.Propietario.Nombre;
            ImageMain.Src = objMascota.Foto;
        }

        public void Message(String title, String text, String tipo)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>Fn_Mensaje('" + title + "', '" + text + "','" + tipo + "');</script>", false);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            clsBaseEntidad baseEntidad = new clsBaseEntidad();
            Boolean resultado = false;
            clsMascota objMascota = new clsMascota();
            objMascota.Id = vsId;
            objMascota.Nombre = txtNombre.Value;
            objMascota.Raza = txtRaza.Value;
            objMascota.Color = txtColor.Value;
            objMascota.Especie = txtEspecie.Value;
            objMascota.Peso = txtPeso.Value;
            objMascota.MarcaDistintiva = txtMarcaDist.Value;
            objMascota.Propietario.Id = 1;
            objMascota.Foto = hfMain.Value;
            objMascota.FechaNacimiento = Convert.ToDateTime(txtFechaNac.Value, CultureInfo.InvariantCulture);

            try
            {
                resultado = clsLogica.Instance.Mascota_Guardar(ref baseEntidad, objMascota);
                if (resultado) { ObtenerInformacion(); }
            }
            catch (Exception ex)
            {

            }
        }
    }
}