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
   public class NavegacionDao
    {

        #region Singleton
        private static NavegacionDao instance = null;
        public static NavegacionDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new NavegacionDao();
                return instance;
            }
        }
        #endregion

        #region Llenar Entidades
        public Navegacion SetEntidad(SqlDataReader dr)
        {
            Navegacion navegacion = new Navegacion();
            navegacion.Id = dr.ObtenerValorColumna<Int32>("NavegacionId");
            navegacion.PadreId = dr.ObtenerValorColumna<Int32>("PadreId");
            navegacion.Nombre = dr.ObtenerValorColumna<String>("Nombre");
            navegacion.Descripcion = dr.ObtenerValorColumna<String>("Descripcion");
            navegacion.Url = dr.ObtenerValorColumna<String>("Url");
            navegacion.Mostrar = dr.ObtenerValorColumna<Boolean>("Mostrar");
            navegacion.Estado = dr.ObtenerValorColumna<Int16>("Estado");
            return navegacion;
        }
        #endregion

        #region Crear Metodos
        public List<Navegacion> Obtener(ref BaseEntidad entidad)
        {
            List<Navegacion> lstNavegaciones = new List<Navegacion>();
            Navegacion navegacion;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("Navegacion_Obtener", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        navegacion = new Navegacion();
                        navegacion = SetEntidad(dr);
                        lstNavegaciones.Add(navegacion);
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
            return lstNavegaciones;
        }

        #endregion
    }
}
