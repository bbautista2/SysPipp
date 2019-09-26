using CapaEntidad;
using CapaEntidad.TipoTabla;
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
    public class PermisoNavegacionDao
    {
        #region Singleton
        private static PermisoNavegacionDao instance = null;
        public static PermisoNavegacionDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new PermisoNavegacionDao();
                return instance;
            }
        }
        #endregion

        #region Llenar Entidades
        public PermisoNavegacion SetEntidad(SqlDataReader dr)
        {
            PermisoNavegacion permisoNavegacion = new PermisoNavegacion();
            permisoNavegacion.NavegacionId = dr.ObtenerValorColumna<Int32>("NavegacionId");
            permisoNavegacion.PermisoId = dr.ObtenerValorColumna<Int32>("PermisoId"); 
            permisoNavegacion.Estado = dr.ObtenerValorColumna<Byte>("Estado");          
            return permisoNavegacion;
        }
        #endregion

        #region Crear Metodos
        public List<PermisoNavegacion> porPermiso(ref BaseEntidad entidad, Int32 permisoId)
        {
            List<PermisoNavegacion> lstPermisoNavegacion = new List<PermisoNavegacion>();
            PermisoNavegacion permisoNavegacion;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("Navegacion_ObtenerPorPermisoId", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@permisoId", permisoId);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        permisoNavegacion = new PermisoNavegacion();
                        permisoNavegacion = SetEntidad(dr);
                        lstPermisoNavegacion.Add(permisoNavegacion);
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
            return lstPermisoNavegacion;
        }

        #endregion

        public Boolean Guardar(Int32 permisoId,Int32 userId,TListaPermisoNavegacion lstPermisosNavegacion)
        {
            Boolean Resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Permiso_Navegacion_GuardarMasivo", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@permisoId", permisoId);
                cmd.Parameters.AddWithValue("@userId", userId);
                if (lstPermisosNavegacion.Count > 0)
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@typePermisosNavegacion", Value = lstPermisosNavegacion, SqlDbType = SqlDbType.Structured, TypeName = "[dbo].[Type_PermisosNavegacion]" });                
                cmd.ExecuteReader();
                Resultado = true;
            }
            catch (Exception ex)
            {
                Resultado = false;
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return Resultado;
        }


    }
}
