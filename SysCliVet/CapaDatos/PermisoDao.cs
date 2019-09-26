using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.Conexiones;
using CapaLibreria.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class PermisoDao
    {
        #region Singleton
        private static PermisoDao instance = null;
        public static PermisoDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new PermisoDao();
                return instance;
            }
        }
        #endregion
        #region Llenar Entidades
        public Permiso SetEntidad(SqlDataReader dr)
        {
            Permiso permiso = new Permiso();
            permiso.Id = dr.ObtenerValorColumna<Int32>("PermisoId");
            permiso.Nombre = dr.ObtenerValorColumna<String>("Nombre");
            permiso.Descripcion = dr.ObtenerValorColumna<String>("Descripcion");
            permiso.Estado = dr.ObtenerValorColumna<Byte>("Estado");           
            return permiso;
        }
        #endregion
       #region Crear Metodos
        public List<Permiso> Obtener(ref BaseEntidad entidad)
        {
            List<Permiso> lstPermisos = new List<Permiso>();
            Permiso permiso;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("Permiso_Obtener", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        permiso = new Permiso();
                        permiso = SetEntidad(dr);
                        lstPermisos.Add(permiso);
                    }
                }
            }
            catch (Exception ex)
            {
                entidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return lstPermisos;
        }

        public Boolean Crear(ref BaseEntidad entidad,Permiso permiso)
        {
            Boolean exitoso = false; 
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Permiso_Crear", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@nombre", permiso.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", permiso.Descripcion);
                cmd.Parameters.AddWithValue("@estado", permiso.Estado);
                cmd.Parameters.AddWithValue("@creadoPor", permiso.CreadoPor);
                cmd.ExecuteReader();
                
            }
            catch (Exception ex)
            {
                entidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }


            return exitoso;
        }

        #endregion

    }
}
