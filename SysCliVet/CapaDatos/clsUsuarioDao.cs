using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class clsUsuarioDao
    {
        #region Singleton
        private static clsUsuarioDao instance = null;
        public static clsUsuarioDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsUsuarioDao();
                return instance;
            }
        }
        #endregion

        #region Llenar Entidades
        public clsUsuario SetEntidad(SqlDataReader dr)
        {
            clsUsuario Usuario = new clsUsuario();
            return Usuario;
        }
        #endregion

        #region Acceso
        public clsUsuario ValidarAcceso(ref clsBaseEntidad baseEntidad, String usuario, String password)
        {
            clsUsuario Usuario = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Usuario_ValidarAcceso", clsConexion.GetConexion())
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
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "User not found"));
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return Usuario;
        }
        #endregion

    }
}
