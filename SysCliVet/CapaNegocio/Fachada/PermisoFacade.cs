using CapaEntidad;
using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Fachada
{
    public class PermisoFacade
    {
        #region Singleton
        private static PermisoFacade instance = null;
        public static PermisoFacade Instance
        {
            get
            {
                if (instance == null)
                    instance = new PermisoFacade();
                return instance;
            }
        }
        #endregion
        public List<Navegacion> ObtenerMenus(ref BaseEntidad entidad,Int32 permisoId) {
            List<Navegacion> navegaciones = new List<Navegacion>();
            try
            {
                List<PermisoNavegacion> permisos = new List<PermisoNavegacion>();
                permisos = PermisoNavegacionBl.Instance.porPermiso(ref entidad,permisoId);
                navegaciones = NavegacionBl.Instance.Obtener(ref entidad);
                foreach (Navegacion navegacion in navegaciones) {
                    navegacion.Accesso = permisos.Exists(p=>p.NavegacionId==navegacion.Id);
                }
            }


            catch (Exception exception) { }

            return navegaciones;
        }
    }
}
