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
    public class PermisoBl
    {
        #region Singleton
        private static PermisoBl instance = null;
        public static PermisoBl Instance
        {
            get
            {
                if (instance == null)
                    instance = new PermisoBl();
                return instance;
            }
        }
        #endregion

        public List<Permiso> Obtener(ref BaseEntidad entidad)
        {
            List<Permiso> lstPermisos = new List<Permiso>();
            try {
                lstPermisos = PermisoDao.Instance.Obtener(ref entidad);
            } catch (Exception exception) { }
            return lstPermisos;
        }
         
        }
}
