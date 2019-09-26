using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio.Fachada;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarMenuNavegacion();
        }

        private void CargarMenuNavegacion() {
            try {
                BaseEntidad entidad = new BaseEntidad();
                List<Navegacion> navegaciones = new List<Navegacion>();
                navegaciones = PermisoFacade.Instance.ObtenerMenus(ref entidad,0);
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
                Permiso permiso = new Permiso();
                permiso.Nombre = txtNombre.Value;
                permiso.Descripcion = txtDescripcion.Value;
                permiso.Estado = rbActivo.Checked ? (Int16)EnumEstadoUsuario.Active : (Int16)EnumEstadoUsuario.Inactive;


                if (hfListaNavegacion.Value != null)
                {
                    permiso.LstNavegaciones = ((new JavaScriptSerializer()).Deserialize<List<Navegacion>>(hfListaNavegacion.Value));
                }
            }

            catch (Exception exception) { }
        }
    }
}