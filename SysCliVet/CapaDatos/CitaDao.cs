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
    public class CitaDao
    {
        #region Singleton
        private static CitaDao instance = null;
        public static CitaDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new CitaDao();
                return instance;
            }
        }
        #endregion
        #region Llenar Entidades
        public Cita SetEntidad(SqlDataReader dr)
        {
            Cita cita = new Cita();
            cita.Id = dr.ObtenerValorColumna<Int32>("ID");
            cita.Motivo = dr.ObtenerValorColumna<String>("Motivo");      
            cita.Fecha = dr.ObtenerValorColumna<DateTime>("Fecha"); 
            cita.Estado = dr.ObtenerValorColumna<Int16>("Estado");
            cita.TipoCita.Id = dr.ObtenerValorColumna<Int32>("TipoCitaID");
            cita.TipoCita.Nombre = dr.ObtenerValorColumna<String>("TipoCita_Nombre");
            cita.Mascota.Id= dr.ObtenerValorColumna<Int32>("MascotaID");
            cita.Mascota.Nombre = dr.ObtenerValorColumna<String>("Nombre_Mascota");
            cita.Mascota.Propietario.Nombre = dr.ObtenerValorColumna<String>("Nombre_Propietario");
            return cita;
        }
        #endregion
        public Boolean Guardar(ref clsBaseEntidad baseEntidad, Cita objCita)
        {
            Boolean Resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Cita_Guardar", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };               
                cmd.Parameters.AddWithValue("@ID", objCita.Id);
                cmd.Parameters.AddWithValue("@MascotaID", objCita.Mascota.Id);
                cmd.Parameters.AddWithValue("@TipoCitaID", objCita.TipoCita.Id);
                cmd.Parameters.AddWithValue("@Motivo", objCita.Motivo);
                cmd.Parameters.AddWithValue("@Fecha", objCita.Fecha);

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

        public List<Cita> ObtenerTodo(ref clsBaseEntidad baseEntidad)
        {
            List<Cita> lstCitas = new List<Cita>();
            Cita objCita;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("Cita_Listar", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        objCita = new Cita();
                        objCita = SetEntidad(dr);
                        lstCitas.Add(objCita);
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
            return lstCitas;
        }

        public Boolean EliminarPorId(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Cita_EliminarPorId", clsConexion.GetConexion())
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

    }
}
