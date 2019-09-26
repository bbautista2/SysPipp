using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio.Fachada;
using SysCliVet.src.app_code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.Permisos
{
    public partial class Administrar : System.Web.UI.Page
    {
        public Int32 permisoId
        {
            get { return ViewState["ID"] != null ? (Int32)ViewState["ID"] : default(Int32); }
            set { ViewState["ID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["i"]))
                {
                    permisoId = Convert.ToInt32(Request.QueryString["i"]);
                }
                CargarMenuNavegacion(permisoId);
            }
        }

        private void CargarMenuNavegacion(Int32 Id) {
            try {
               

                BaseEntidad entidad = new BaseEntidad();
                List<Navegacion> navegaciones = new List<Navegacion>();
                navegaciones = PermisoFacade.Instance.ObtenerMenus(ref entidad, Id);
                if(navegaciones!=null && navegaciones.Count > 0)
                {
                    hfListadoPermisos.Value = (new JavaScriptSerializer()).Serialize(navegaciones);
                }
            } catch (Exception ex) {
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean exitoso = false;
                Permiso permiso = new Permiso
                {
                    Nombre = txtNombre.Value,
                    Descripcion = txtDescripcion.Value,
                    Estado = rbActivo.Checked ? (Int16)EnumEstadoUsuario.Active : (Int16)EnumEstadoUsuario.Inactive,
                    LstNavegaciones = new List<Navegacion>(),
                    Id = permisoId,
                };

                if (hfListaNavegacion.Value != null)
                {
                    permiso.LstNavegaciones = ((new JavaScriptSerializer()).Deserialize<List<Navegacion>>(hfListaNavegacion.Value));
                    exitoso = PermisoFacade.Instance.Save(permiso, Sesion.SsUsuario.Id);
                }

                if (!exitoso)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"El permiso no se guardo correctamente\"" + ");</script>", false);
                }
                else {
                    CargarMenuNavegacion(permiso.Id);
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"s\"" + ", " + "\"El permiso se guardo correctamente\"" + ");</script>", false);
                }
            }

            catch (Exception exception) { }
        }
    }
}