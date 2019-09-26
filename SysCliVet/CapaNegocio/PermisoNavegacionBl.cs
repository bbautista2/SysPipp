using CapaDatos;
using CapaEntidad;
using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class PermisoNavegacionBl
    {
        #region Singleton
        private static PermisoNavegacionBl instance = null;
        public static PermisoNavegacionBl Instance
        {
            get
            {
                if (instance == null)
                    instance = new PermisoNavegacionBl();
                return instance;
            }
        }
        #endregion
        public List<PermisoNavegacion> porPermiso(ref BaseEntidad entidad, Int32 permisoId)
        {
            List<PermisoNavegacion> lstPermisosNavegacion = new List<PermisoNavegacion>();
            try
            {
                lstPermisosNavegacion = PermisoNavegacionDao.Instance.porPermiso(ref entidad, permisoId);
            }
            catch (Exception exception) { }
            return lstPermisosNavegacion;
        }

        }
}
