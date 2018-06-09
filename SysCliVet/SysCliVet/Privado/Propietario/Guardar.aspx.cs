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

namespace SysCliVet.Privado.Propietario
{
    public partial class Guardar : System.Web.UI.Page
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
                    try {
                        clsBaseEntidad baseEntidad = new clsBaseEntidad();
                        clsPropietario objPropietario = new clsPropietario();
                        objPropietario = clsLogica.Instance.Propietario_PorId(ref baseEntidad, vsId);
                        if (objPropietario.Id == 0) { Volver(); }
                        MostrarInformacion(objPropietario);
                    } catch (Exception ex) {

                    }

                }
                else
                {
                    Volver();
                }
            }
        }
       

        private void MostrarInformacion(clsPropietario objPropietario)
        {
            txtNombre.Value = objPropietario.NombreCompleto;
            txtEmail.Value = objPropietario.Email;
            txtDireccion.Value = objPropietario.Direccion;
            txtTelefono.Value = objPropietario.Telefono;
            txtFechaNac.Value = objPropietario.FechaNacimiento.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        }           

        public void Volver()
        {
            Response.Redirect("Listar.aspx");
        }

   


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            clsBaseEntidad baseEntidad = new clsBaseEntidad();
            Boolean resultado = false;
            clsPropietario objPropietario = new clsPropietario();
            objPropietario.Id = vsId;
            objPropietario.Dni = Convert.ToInt32(txtDireccion.Value);
            objPropietario.Nombre = txtNombre.Value;
            objPropietario.Email = txtEmail.Value;
            objPropietario.Direccion = txtDireccion.Value;
            objPropietario.Telefono = txtTelefono.Value;
            objPropietario.FechaNacimiento = Convert.ToDateTime(txtFechaNac.Value, CultureInfo.InvariantCulture);

            try
            {
                resultado = clsLogica.Instance.Propietario_Guardar(ref baseEntidad, objPropietario);
                if (resultado) { ObtenerInformacion(); }
            }
            catch (Exception ex) { }
        }
    }
}