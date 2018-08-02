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

        #region Llenar Entidades
        public clsHistoriaClinica SetEntidad(SqlDataReader dr)
        {
            clsHistoriaClinica objHistoria = new clsHistoriaClinica();
            objHistoria.Id = dr.ObtenerValorColumna<Int32>("ID");
            objHistoria.Fecha = dr.ObtenerValorColumna<DateTime>("Fecha");
            objHistoria.NumeroFicha = dr.ObtenerValorColumna<Int32>("NumeroFicha");
            objHistoria.Agitacion = dr.ObtenerValorColumna<Boolean>("Agitacion");
            objHistoria.AgitacionDescripcion = dr.ObtenerValorColumna<String>("AgitacionDescripcion");
            objHistoria.Depresion = dr.ObtenerValorColumna<Boolean>("Depresion");
            objHistoria.DepresionDescripcion = dr.ObtenerValorColumna<String>("DepresionDescripcion");
            objHistoria.Apetito = dr.ObtenerValorColumna<Int16>("Apetito");
            objHistoria.CondicionCuerpo = dr.ObtenerValorColumna<Int16>("CondicionCuerpo");
            objHistoria.PesoActual = dr.ObtenerValorColumna<String>("PesoActual");
            objHistoria.PerdidaPeso = dr.ObtenerValorColumna<String>("PerdidaPeso");
            objHistoria.Sintomas = dr.ObtenerValorColumna<String>("Sintomas");
            objHistoria.Descarte = dr.ObtenerValorColumna<String>("Descarte");
            objHistoria.Resultados = dr.ObtenerValorColumna<String>("Resultados");
            objHistoria.PresuntivoDefinitivo = dr.ObtenerValorColumna<String>("PresuntivoDefinitivo");
            return objHistoria;
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

        public clsHistoriaClinica porID(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            clsHistoriaClinica objHistoria = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("HistoriaClinica_PorID", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        objHistoria = SetEntidad(dr);
                    }
                    if (dr.NextResult())
                    {
                        objHistoria.LstAnalisis = new List<clsAnalisis>();
                        while (dr.Read())
                        {
                            objHistoria.LstAnalisis.Add(
                                new clsAnalisis
                                {
                                    Id = dr.ObtenerValorColumna<Int32>("Id"),
                                    TipoId = dr.ObtenerValorColumna<Int16>("TipoAnalisisId"),
                                    Descripcion = dr.ObtenerValorColumna<String>("Descripcion")
                                });
                        }
                    }
                    if (dr.NextResult())
                    {
                        objHistoria.LstTratamientos = new List<clsTratamiento>();
                        while (dr.Read())
                        {
                            objHistoria.LstTratamientos.Add(
                                new clsTratamiento
                                {
                                    Id = dr.ObtenerValorColumna<Int32>("Id"),
                                    FechaTratamiento = dr.ObtenerValorColumna<DateTime>("FechaTratamiento"),
                                    Droga = dr.ObtenerValorColumna<String>("Droga"),
                                    Dosis = dr.ObtenerValorColumna<String>("Dosis"),
                                    Observacion = dr.ObtenerValorColumna<String>("Observacion")
                                });
                        }
                    }
                }                    
            }
            catch (Exception ex)
            {
                objHistoria = null;
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return objHistoria;
        }

        public Boolean EliminarPorId(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("HistoriaClinica_EliminarPorId", clsConexion.GetConexion())
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
