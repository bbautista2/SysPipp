using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using System;
using System.Data;
using System.Data.SqlClient;
using CapaLibreria.Conexiones;

namespace CapaDatos
{
    public class PropietarioDao
    {
        #region Singleton
        private static PropietarioDao instance = null;
        public static PropietarioDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new PropietarioDao();
                return instance;
            }
        }
        #endregion

        #region Llenar Entidades
        public Propietario SetEntidad(SqlDataReader dr)
        {
            Propietario Propietario = new Propietario();
            Propietario.Id = dr.ObtenerValorColumna<Int32>("ID");
            Propietario.Nombre = dr.ObtenerValorColumna<String>("Nombre");
            Propietario.Apellidos = dr.ObtenerValorColumna<String>("Apellidos");
            Propietario.FechaNacimiento = dr.ObtenerValorColumna<DateTime>("FechaNacimiento");
            Propietario.Direccion = dr.ObtenerValorColumna<String>("Direccion");
            Propietario.Telefono = dr.ObtenerValorColumna<String>("Telefono");
            Propietario.Email = dr.ObtenerValorColumna<String>("Email");
            Propietario.Celular = dr.ObtenerValorColumna<String>("Celular");
            Propietario.Estado = dr.ObtenerValorColumna<Int16>("Estado");
            Propietario.Dni = dr.ObtenerValorColumna<String>("Dni");
            return Propietario;
        }
        #endregion

        #region Crud
        public Propietario porID(ref BaseEntidad baseEntidad, Int32 id)
        {
            Propietario Propietario = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Propietario_PorID", Conexion.GetConexion())
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
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return Propietario;
        }

        public Boolean Guardar(ref BaseEntidad baseEntidad,Propietario objPropietario) {

            Boolean Resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Propietario_Guardar", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter outputParametro = cmd.Parameters.Add("@NuevoId", SqlDbType.Int);
                outputParametro.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@ID", objPropietario.Id);
                cmd.Parameters.AddWithValue("@Nombre", objPropietario.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", objPropietario.Apellidos);
                cmd.Parameters.AddWithValue("@Dni", objPropietario.Dni);
                cmd.Parameters.AddWithValue("@FechaNacimiento", objPropietario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Direccion", objPropietario.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", objPropietario.Telefono);
                cmd.Parameters.AddWithValue("@Email", objPropietario.Email);
                cmd.Parameters.AddWithValue("@Estado", objPropietario.Estado);
                cmd.Parameters.AddWithValue("@Celular", objPropietario.Celular);
                cmd.ExecuteReader();
                Resultado = true;
            }
            catch (Exception ex)
            {
                Resultado = false;
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return Resultado;
        }

        public DataTable Listar(ref BaseEntidad baseEntidad)
        {

            DataTable dt = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Propietario_Listar", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };

                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return dt;
        }

        public DataTable ObtenerPorDni(ref BaseEntidad baseEntidad, String dni, Int16 tipoBusqueda)
        {
            DataTable dt = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Propietario_ObtenerPorDni", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Dni", dni);
                cmd.Parameters.AddWithValue("@Tipo", tipoBusqueda);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return dt;
        }

        public Boolean EliminarPorId(ref BaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Propietario_EliminarPorId", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);
                resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return resultado;
        }

        #endregion
    }
}
