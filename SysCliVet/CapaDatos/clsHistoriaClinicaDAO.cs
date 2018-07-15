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
    public class clsHistoriaClinicaDAO
    {
        #region Singleton
        private static clsHistoriaClinicaDAO instance = null;
        public static clsHistoriaClinicaDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsHistoriaClinicaDAO();
                return instance;
            }
        }
        #endregion

        public Boolean Guardar(ref clsBaseEntidad baseEntidad, clsHistoriaClinica objHistoriaClinica)
        {
            Boolean Resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("HistoriaClinica_Guardar", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (objHistoriaClinica.ListaAnalisis.Count > 0)
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@TYPE_ANALISIS", Value = objHistoriaClinica.ListaAnalisis, SqlDbType = SqlDbType.Structured, TypeName = "dbo.TY_ANALISIS" });
                if (objHistoriaClinica.ListaTratamientos.Count > 0)
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@TYPE_TRATAMIENTO", Value = objHistoriaClinica.ListaTratamientos, SqlDbType = SqlDbType.Structured, TypeName = "dbo.TY_TRATAMIENTO" });
                //Datos Historia Clínica
                SqlParameter outputId = cmd.Parameters.Add("@NuevoId", SqlDbType.Int);
                outputId.Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@ID", objHistoriaClinica.Id);
                cmd.Parameters.AddWithValue("@FichaClinicaID", objHistoriaClinica.FichaClinica.NumeroFicha);
                cmd.Parameters.AddWithValue("@Fecha", objHistoriaClinica.Fecha);
                cmd.Parameters.AddWithValue("@Agitacion", objHistoriaClinica.Agitacion);
                cmd.Parameters.AddWithValue("@AgitacionDescripcion", objHistoriaClinica.AgitacionDescripcion);
                cmd.Parameters.AddWithValue("@Depresion", objHistoriaClinica.Depresion);
                cmd.Parameters.AddWithValue("@DepresionDescripcion", objHistoriaClinica.DepresionDescripcion);
                cmd.Parameters.AddWithValue("@Apetito", objHistoriaClinica.Apetito);
                cmd.Parameters.AddWithValue("@CondicionCuerpo", objHistoriaClinica.CondicionCuerpo);
                cmd.Parameters.AddWithValue("@PesoActual", objHistoriaClinica.PesoActual);
                cmd.Parameters.AddWithValue("@PerdidaPeso", objHistoriaClinica.PerdidaPeso);
                cmd.Parameters.AddWithValue("@Sintomas", objHistoriaClinica.Sintomas);
                cmd.Parameters.AddWithValue("@Descarte", objHistoriaClinica.Descarte);
                cmd.Parameters.AddWithValue("@PresuntivoDefinitivo", objHistoriaClinica.PresuntivoDefinitivo);
                cmd.Parameters.AddWithValue("@Resultados", objHistoriaClinica.Resultados);
                cmd.Parameters.AddWithValue("@Estado", objHistoriaClinica.Estado);

                cmd.ExecuteReader();
                objHistoriaClinica.Id = Convert.ToInt32(cmd.Parameters["@NuevoId"].Value);
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

        public List<clsHistoriaClinica> ObtenerPorMascotaID(ref clsBaseEntidad baseEntidad, Int32 MascotaID)
        {
            SqlCommand cmd = null;
            List<clsHistoriaClinica> lstObjHistoriaClinica = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("HistoriaClinica_GetByMascotaID", clsConexion.GetConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MascotaID", MascotaID);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    lstObjHistoriaClinica = new List<clsHistoriaClinica>();
                    while (dr.Read())
                    {
                        lstObjHistoriaClinica.Add(
                            new clsHistoriaClinica
                            {
                                Id = dr.ObtenerValorColumna<Int32>("Id"),
                                NumeroFicha = dr.ObtenerValorColumna<Int32>("NumeroFicha"),
                                Fecha = dr.ObtenerValorColumna<DateTime>("Fecha"),
                                Apetito = dr.ObtenerValorColumna<Int16>("Apetito"),
                                CondicionCuerpo = dr.ObtenerValorColumna<Int16>("CondicionCuerpo"),
                                PesoActual = dr.ObtenerValorColumna<String>("PesoActual")
                            });
                    }
                }
            }
            catch (Exception ex)
            {
                lstObjHistoriaClinica = null;
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return lstObjHistoriaClinica;
        }

    }
}
