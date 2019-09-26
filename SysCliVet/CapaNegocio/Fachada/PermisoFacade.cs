using CapaDatos;
using CapaEntidad;
using CapaEntidad.TipoTabla;
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
                    navegacion.Accesso = permisos.Exists(p=>p.NavegacionId==navegacion.Id &&p.Estado==1 );
                }
            }


            catch (Exception exception) { }

            return navegaciones;
        }

        public Boolean Save(Permiso permiso,Int32 userId)
        {
            Boolean exitoso = false;
            try {               
                if (permiso.LstNavegaciones!=null && permiso.LstNavegaciones.Count>0)
                {
                    TListaPermisoNavegacion permisoNavegacion = new TListaPermisoNavegacion();
                    Int32 permisoId;
                    if (permiso.Id == 0)
                    {
                        permisoId = PermisoDao.Instance.Crear(permiso, userId);
                    }
                    else {
                        permisoId = PermisoDao.Instance.Actualizar(permiso,userId);
                    }
                    foreach (Navegacion nav in permiso.LstNavegaciones) {
                        TPermisoNavegacion permisoNav = new TPermisoNavegacion();
                        permisoNav.NavegacionId = nav.Id;
                        permisoNavegacion.Add(permisoNav);
                    }
                    exitoso = PermisoNavegacionDao.Instance.Guardar(permisoId,userId,permisoNavegacion);
                }
            } catch (Exception ex) {

            }
            return exitoso;
        }
    }
}
