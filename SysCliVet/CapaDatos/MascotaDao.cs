using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaLibreria.Conexiones;

namespace CapaDatos
{
    public class MascotaDao
    {
        #region Singleton
        private static MascotaDao instance = null;
        public static MascotaDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new MascotaDao();
                return instance;
            }
        }
        #endregion

        #region Llenar Entidades
        public Mascota SetEntidad(SqlDataReader dr)
        {
            Mascota Mascota = new Mascota();
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
        public List<Mascota> porNombre(ref BaseEntidad baseEntidad, String nombre)
        {
            List<Mascota> lstMascota = new List<Mascota>();
            Mascota objMascota;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("Mascota_ObtenerPorNombre", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        objMascota = new Mascota();
                        objMascota = SetEntidad(dr);
                        lstMascota.Add(objMascota);
                    }

                }
            }
            catch (Exception ex)
            {               
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return lstMascota;
        }

        public Mascota porID(ref BaseEntidad baseEntidad, Int32 id)
        {
            Mascota Mascota = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Mascota_PorID", Conexion.GetConexion())
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
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return Mascota;
        }

        public Boolean Guardar(ref BaseEntidad baseEntidad,Mascota objMascota) {

            Boolean Resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Mascota_Guardar", Conexion.GetConexion())
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
                cmd = new SqlCommand("Mascota_Listar", Conexion.GetConexion())
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

        public Boolean EliminarPorId(ref BaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Mascota_EliminarPorId", Conexion.GetConexion())
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

        public List<Mascota> ObtenerPorCumpleMesActual(ref BaseEntidad baseEntidad)
        {
            List<Mascota> lstMascotas = new List<Mascota>();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("Mascota_Listar_PorCumpleMesActual", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Mascota objMascota = new Mascota();
                        objMascota = SetEntidad(dr);
                        lstMascotas.Add(objMascota);
                    }

                }
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return lstMascotas;
        }

        #endregion
    }
}
