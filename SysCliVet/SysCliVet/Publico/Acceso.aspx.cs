using CapaEntidad;
using CapaLibreria.Base;
using CapaNegocio;
using SysCliVet.src.app_code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Publico
{
    public partial class Acceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String message = String.Empty;
            BaseEntidad baseEntidad = new BaseEntidad();
            Usuario objUsuario = Logica.Instance.Usuario_ValidarAcceso(ref baseEntidad, txtUsuario.Text, txtPassword.Text);

            if (baseEntidad.Errores.Count == 0)
            {
                Sesion.SsUsuario = objUsuario;

                if (!String.IsNullOrEmpty(Request.QueryString["back_url"]))
                    Response.Redirect(Request.QueryString["back_url"].ToString());
                else
                    Response.Redirect(Config.UrlPaginaPorDefecto);
            }
            else
                lblMessage.Text = baseEntidad.Errores[0].MensajeCliente;
        }
        

    }
}