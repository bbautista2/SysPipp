using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using System;
using System.Globalization;
using System.Web.UI;

namespace SysCliVet.Privado.Propietario
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
                String id = Encriptacion.Desencriptar(Request.QueryString["i"]);
                if (id != String.Empty)
                {
                    vsId = Convert.ToInt32(id);
                    try {
                        BaseEntidad baseEntidad = new BaseEntidad();
                        CapaEntidad.Propietario objPropietario = new CapaEntidad.Propietario();
                        objPropietario = Logica.Instance.Propietario_PorId(ref baseEntidad, vsId);
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
       
        private void MostrarInformacion(CapaEntidad.Propietario objPropietario)
        {
            txtDni.Value = objPropietario.Dni.ToString();
            txtNombre.Value = objPropietario.NombreCompleto;
            txtEmail.Value = objPropietario.Email;
            txtDireccion.Value = objPropietario.Direccion;
            txtCelular.Value = objPropietario.Celular;
            txtTelefono.Value = objPropietario.Telefono;
            txtFechaNac.Value = objPropietario.FechaNacimiento.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        }           

        public void Volver()
        {
            Response.Redirect("Listar.aspx");
        }


        public void Message(String title,String text,String tipo)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>Fn_Mensaje('" + title + "', '"+text+"','"+tipo+"');</script>", false);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BaseEntidad baseEntidad = new BaseEntidad();
            Boolean resultado = false;
            CapaEntidad.Propietario objPropietario = new CapaEntidad.Propietario();
            objPropietario.Id = vsId;
            objPropietario.Dni = Convert.ToInt32(txtDni.Value);
            objPropietario.Nombre = txtNombre.Value;
            objPropietario.Email = txtEmail.Value;
            objPropietario.Direccion = txtDireccion.Value;
            objPropietario.Telefono = txtTelefono.Value;
            objPropietario.Celular = txtCelular.Value;
            objPropietario.FechaNacimiento = !String.IsNullOrEmpty(txtFechaNac.Value) ? Convert.ToDateTime(txtFechaNac.Value, CultureInfo.InvariantCulture) : DateTime.Now;
            objPropietario.Estado = 1;

            try
            {
                resultado = Logica.Instance.Propietario_Guardar(ref baseEntidad, objPropietario);
                if (resultado)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"s\"" + ", " + "\"Propietario guardado correctamente\"" + ");</script>", false);
                    ObtenerInformacion();
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error guardando el Propietario\"" + ");</script>", false);
                }
            }
            catch (Exception ex) {
                ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error guardando el Propietario [1]\"" + ");</script>", false);
            }
        }
    }
}