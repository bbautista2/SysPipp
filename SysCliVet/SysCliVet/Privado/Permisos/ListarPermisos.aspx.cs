using CapaEntidad;
using CapaLibreria.Base;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.Permisos
{
    public partial class ListarPermisos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar();
            }
        }

        private void Listar() {
            BaseEntidad entidad = new BaseEntidad();
            List<Permiso> permisos =new  List<Permiso>();
            try
            {
                permisos = PermisoBl.Instance.Obtener(ref entidad);
                if (permisos != null && permisos.Count > 0) {
                    hfListadoPermisos.Value= (new JavaScriptSerializer()).Serialize(permisos);
                }
            } catch (Exception exception) { }

        }
    }
}