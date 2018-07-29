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
    public class clsMascotaDAO
    {
        #region Singleton
        private static clsMascotaDAO instance = null;
        public static clsMascotaDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsMascotaDAO();
                return instance;
            }
        }
        #endregion

        #region Llenar Entidades
        public clsMascota SetEntidad(SqlDataReader dr)
        {
            clsMascota Mascota = new clsMascota();
            Mascota.Id = dr.ObtenerValorColumna<Int32>("ID");
            Mascota.Nombre = dr.ObtenerValorColumna<String>("Nombre");
            Mascota.FechaNacimiento = dr.ObtenerValorColumna<DateTime>("FechaNacimiento");
            Mascota.Raza = dr.ObtenerValorColumna<String>("Raza");
            Mascota.Color = dr.ObtenerValorColumna<String>("Color");
            Mascota.Especie = dr.ObtenerValorColumna<String>("Especie");
            Mascota.Sexo = dr.ObtenerValorColumna<Int16>("Sexo");
            Mascota.Intac = dr.ObtenerValorColumna<Boolean>("Intac");
            Mascota.Cast = dr.ObtenerValorColumna<Boolean>("Cast");
            Mascota.Peso = dr.ObtenerValorColumna<String>("Peso");
            Mascota.MarcaDistintiva = dr.ObtenerValorColumna<String>("MarcaDistintiva");
            Mascota.Estado = dr.ObtenerValorColumna<Int16>("Estado");
            Mascota.Foto = dr.ObtenerValorColumna<String>("Foto");
            Mascota.Propietario.Id= dr.ObtenerValorColumna<Int32>("PropetarioID");
            Mascota.Propietario.Nombre = dr.ObtenerValorColumna<String>("Nombre_Propietario");
            Mascota.Propietario.Apellidos = dr.ObtenerValorColumna<String>("Apellido_Propietario");
            Mascota.Propietario.Dni = dr.ObtenerValorColumna<Int32>("Dni_Propietario");
            Mascota.Propietario.FechaNacimiento = dr.ObtenerValorColumna<DateTime>("Propietario_FechaNacimiento");
            Mascota.Propietario.Direccion = dr.ObtenerValorColumna<String>("Propietario_Direccion");
            Mascota.Propietario.Telefono = dr.ObtenerValorColumna<String>("Propietario_Telefono");
            Mascota.Propietario.Celular = dr.ObtenerValorColumna<String>("Propietario_Celular");
            Mascota.Propietario.Email =  dr.ObtenerValorColumna<String>("Propietario_Email");
            Mascota.Propietario.Estado = dr.ObtenerValorColumna<Int16>("Propietario_Estado");

            return Mascota;
        }
        #endregion

        #region Crud
        public List<clsMascota> porNombre(ref clsBaseEntidad baseEntidad, String nombre)
        {
            List<clsMascota> lstMascota = new List<clsMascota>();
            clsMascota objMascota;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("Mascota_ObtenerPorNombre", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        objMascota = new clsMascota();
                        objMascota = SetEntidad(dr);
                        lstMascota.Add(objMascota);
                    }

                }
            }
            catch (Exception ex)
            {               
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return lstMascota;
        }

        public clsMascota porID(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            clsMascota Mascota = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Mascota_PorID", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    Mascota = SetEntidad(dr);
            }
            catch (Exception ex)
            {
                Mascota = null;
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return Mascota;
        }

        public Boolean Guardar(ref clsBaseEntidad baseEntidad,clsMascota objMascota) {

            Boolean Resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Mascota_Guardar", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter outputParametro = cmd.Parameters.Add("@NuevoId", SqlDbType.Int);
                outputParametro.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@ID", objMascota.Id);
                cmd.Parameters.AddWithValue("@PropietarioId", objMascota.Propietario.Id);
                cmd.Parameters.AddWithValue("@Nombre", objMascota.Nombre);
                cmd.Parameters.AddWithValue("@FechaNacimiento", objMascota.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Raza", objMascota.Raza);
                cmd.Parameters.AddWithValue("@Color",objMascota.Color);
                cmd.Parameters.AddWithValue("@Especie", objMascota.Especie);
                cmd.Parameters.AddWithValue("@Sexo", objMascota.Sexo);
                cmd.Parameters.AddWithValue("@Intac", objMascota.Intac);
                cmd.Parameters.AddWithValue("@Cast", objMascota.Cast);
                cmd.Parameters.AddWithValue("@Peso", objMascota.Peso);
                cmd.Parameters.AddWithValue("@MarcaDistintiva", objMascota.MarcaDistintiva);
                cmd.Parameters.AddWithValue("@Foto", objMascota.Foto);
                cmd.Parameters.AddWithValue("@Estado", objMascota.Estado);
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
                cmd = new SqlCommand("Mascota_Listar", clsConexion.GetConexion())
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

        public Boolean EliminarPorId(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Mascota_EliminarPorId", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);
                resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return resultado;
        }

        #endregion
    }
}
