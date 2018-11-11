using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using System;
using System.Data;
using System.Data.SqlClient;
using CapaLibreria.Conexiones;

namespace CapaDatos
{
    public class UsuarioDao
    {
        #region Singleton
        private static UsuarioDao instance = null;
        public static UsuarioDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new UsuarioDao();
                return instance;
            }
        }
        #endregion

        #region Llenar Entidades
        public Usuario SetEntidad(SqlDataReader dr)
        {
            Usuario Usuario = new Usuario();
            Usuario.Id = dr.ObtenerValorColumna<Int32>("ID");
            Usuario.Nombres = dr.ObtenerValorColumna<String>("Nombres");
            Usuario.Apellidos = dr.ObtenerValorColumna<String>("Apellidos");
            Usuario.NombreUsuario = dr.ObtenerValorColumna<String>("Usuario");
            Usuario.Email = dr.ObtenerValorColumna<String>("Email");
            Usuario.Estado = dr.ObtenerValorColumna<Int16>("Estado");
            return Usuario;
        }
        #endregion

        #region Acceso
        public Usuario ValidarAcceso(ref BaseEntidad baseEntidad, String usuario, String password)
        {
            Usuario Usuario = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Usuario_ValidarAcceso", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Password", password);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    Usuario = SetEntidad(dr);
            }
            catch (Exception ex)
            {
                Usuario = null;
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return Usuario;
        }
        #endregion

    }
}
