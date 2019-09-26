using CapaEntidad;
using CapaLibreria.Base;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NavegacionBl
    {
        #region Singleton
        private static NavegacionBl instance = null;
        public static NavegacionBl Instance
        {
            get
            {
                if (instance == null)
                    instance = new NavegacionBl();
                return instance;
            }
        }
        #endregion
        public List<Navegacion> Obtener(ref BaseEntidad entidad)
        {
            List<Navegacion> lstNavegaciones = new List<Navegacion>();

            try {
                lstNavegaciones = NavegacionDao.Instance.Obtener(ref entidad);
            } catch (Exception exception) { }
            return lstNavegaciones;
        }

    }
}
