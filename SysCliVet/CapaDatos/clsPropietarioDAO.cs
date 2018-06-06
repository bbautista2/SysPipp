using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.Conexion;
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
    public class clsPropietarioDAO
    {
        #region Singleton
        private static clsPropietarioDAO instance = null;
        public static clsPropietarioDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsPropietarioDAO();
                return instance;
            }
        }
        #endregion

        #region Llenar Entidades
        public clsPropietario SetEntidad(SqlDataReader dr)
        {
            clsPropietario Propietario = new clsPropietario();
            Propietario.Id = dr.ObtenerValorColumna<Int32>("ID");
            Propietario.Nombre = dr.ObtenerValorColumna<String>("Nombre");
            Propietario.Apellidos = dr.ObtenerValorColumna<String>("Apellidos");
            Propietario.FechaNacimiento = dr.ObtenerValorColumna<DateTime>("FechaNacimiento");
            Propietario.Direccion = dr.ObtenerValorColumna<String>("Direccion");
            Propietario.Telefono = dr.ObtenerValorColumna<String>("Telefono");
            Propietario.Email = dr.ObtenerValorColumna<String>("Email");
            Propietario.Estado = dr.ObtenerValorColumna<Int16>("Estado");
            return Propietario;
        }
        #endregion

        #region Crud
        public clsPropietario porID(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            clsPropietario Propietario = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Propietario_PorID", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    Propietario = SetEntidad(dr);
            }
            catch (Exception ex)
            {
                Propietario = null;
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return Propietario;
        }

        public Boolean Guardar(ref clsBaseEntidad baseEntidad,clsPropietario objPropietario) {

            Boolean Resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Propietario_Guardar", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", objPropietario.Id);
                cmd.Parameters.AddWithValue("@Nombre", objPropietario.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", objPropietario.Apellidos);
                cmd.Parameters.AddWithValue("@FechaNacimiento", objPropietario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Direccion", objPropietario.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", objPropietario.Telefono);
                cmd.Parameters.AddWithValue("@Email", objPropietario.Email);
                cmd.Parameters.AddWithValue("@Estado", objPropietario.Estado);               
                cmd.ExecuteReader();
                Resultado = true;
            }
            catch (Exception ex)
            {
                Resultado = false;
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return Resultado;
        }

        public DataTable Listar(ref clsBaseEntidad baseEntidad)
        {

            DataTable dt = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Propietario_Listar", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };

                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return dt;
        }


        #endregion
    }
}
