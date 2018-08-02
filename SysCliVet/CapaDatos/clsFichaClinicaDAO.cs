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
    public  class clsFichaClinicaDAO
    {
        #region Singleton
        private static clsFichaClinicaDAO instance = null;
        public static clsFichaClinicaDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsFichaClinicaDAO();
                return instance;
            }
        }
        #endregion

        public clsFichaClinica ObtenerPorMascotaID(ref clsBaseEntidad baseEntidad, Int32 MascotaID)
        {
            SqlCommand cmd = null;
            clsFichaClinica objFichaClinica = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("FichaClinica_GetByID", clsConexion.GetConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MascotaID", MascotaID);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    objFichaClinica = new clsFichaClinica();
                    while (dr.Read())
                    {
                        objFichaClinica.Id = dr.ObtenerValorColumna<Int32>("Id");
                        objFichaClinica.Descripcion = dr.ObtenerValorColumna<String>("Descripcion");
                        objFichaClinica.Fecha = dr.ObtenerValorColumna<DateTime>("Fecha");
                        objFichaClinica.InformacionMedica = dr.ObtenerValorColumna<String>("InformacionMedica");
                        objFichaClinica.MedioAmbiente = dr.ObtenerValorColumna<Int16>("MedioAmbiente");
                        objFichaClinica.Motivo = dr.ObtenerValorColumna<String>("Motivo");
                        objFichaClinica.NumeroFicha= dr.ObtenerValorColumna<Int32>("NumeroFicha");
                        objFichaClinica.Observaciones = dr.ObtenerValorColumna<String>("Observaciones");
                        objFichaClinica.TipoDieta = dr.ObtenerValorColumna<Int16>("TipoDieta");
                    }
                   
                    if (dr.NextResult())
                    {
                        objFichaClinica.LstVacunas = new List<clsVacuna>();
                        while (dr.Read())
                        {
                            objFichaClinica.LstVacunas.Add(
                                new clsVacuna
                                {
                                    Id =  dr.ObtenerValorColumna< Int32>("ID"),
                                    Fecha = dr.ObtenerValorColumna<DateTime>("Fecha"),
                                    Nombre = dr.ObtenerValorColumna<String>("Nombre"),
                                    Descripcion = dr.ObtenerValorColumna<String>("Descripcion")
                                                                       
                                });
                        }
                    }

                    if (dr.NextResult())
                    {
                        objFichaClinica.LstDesparasitaciones = new List<clsDesparasitacion>();
                        while (dr.Read())
                        {
                            objFichaClinica.LstDesparasitaciones.Add(
                                new clsDesparasitacion
                                {
                                    Id = dr.ObtenerValorColumna<Int32>("ID"),
                                    Fecha = dr.ObtenerValorColumna<DateTime>("Fecha"),
                                    Nombre = dr.ObtenerValorColumna<String>("Nombre"),
                                    Descripcion = dr.ObtenerValorColumna<String>("Descripcion")
                                });
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                objFichaClinica = null;
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return objFichaClinica;
        }

        public Boolean Guardar(ref clsBaseEntidad baseEntidad, clsFichaClinica objFichaClinica)
        {
            Boolean Resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("FichaClinica_Guardar", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (objFichaClinica.ListaVacunas.Count > 0)
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@TYPE_VACUNAS", Value = objFichaClinica.ListaVacunas, SqlDbType = SqlDbType.Structured, TypeName = "dbo.TY_VACUNAS" });
                if (objFichaClinica.ListaDesparasitaciones.Count > 0)
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@TYPE_DESPARASITACIONES", Value = objFichaClinica.ListaDesparasitaciones, SqlDbType = SqlDbType.Structured, TypeName = "dbo.TY_DESPARASITACIONES" });
                //Datos Ficha Clínica
                SqlParameter outputId = cmd.Parameters.Add("@NuevoId", SqlDbType.Int);
                outputId.Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@ID", objFichaClinica.Id);
                cmd.Parameters.AddWithValue("@Fecha", objFichaClinica.Fecha);
                cmd.Parameters.AddWithValue("@InformacionMedica", objFichaClinica.InformacionMedica);
                cmd.Parameters.AddWithValue("@MedioAmbiente", objFichaClinica.MedioAmbiente);
                cmd.Parameters.AddWithValue("@TipoDieta", objFichaClinica.TipoDieta);
                cmd.Parameters.AddWithValue("@Motivo", objFichaClinica.Motivo);
                cmd.Parameters.AddWithValue("@Observaciones", objFichaClinica.Observaciones);
                cmd.Parameters.AddWithValue("@Estado", objFichaClinica.Estado);
                cmd.Parameters.AddWithValue("@NumeroFicha", objFichaClinica.NumeroFicha);
                //Datos Propietario
                cmd.Parameters.AddWithValue("@ProiId", objFichaClinica.Propietario.Id);
                cmd.Parameters.AddWithValue("@ProiDni", objFichaClinica.Propietario.Dni);
                cmd.Parameters.AddWithValue("@ProNombre", objFichaClinica.Propietario.Nombre);
                cmd.Parameters.AddWithValue("@ProApellidos", objFichaClinica.Propietario.Apellidos);
                cmd.Parameters.AddWithValue("@ProFechaNacimiento", objFichaClinica.Propietario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@ProDireccion", objFichaClinica.Propietario.Direccion);
                cmd.Parameters.AddWithValue("@ProCelular", objFichaClinica.Propietario.Celular);
                cmd.Parameters.AddWithValue("@ProTelefono", objFichaClinica.Propietario.Telefono);
                cmd.Parameters.AddWithValue("@ProEmail", objFichaClinica.Propietario.Email);
                cmd.Parameters.AddWithValue("@ProEstado", objFichaClinica.Propietario.Estado);
                //Datos Mascota
                cmd.Parameters.AddWithValue("@MasId", objFichaClinica.Mascota.Id);
                cmd.Parameters.AddWithValue("@MasNombre", objFichaClinica.Mascota.Nombre);
                cmd.Parameters.AddWithValue("@MasFechaNacimiento", objFichaClinica.Mascota.FechaNacimiento);
                cmd.Parameters.AddWithValue("@MasRaza", objFichaClinica.Mascota.Raza);
                cmd.Parameters.AddWithValue("@MasColor", objFichaClinica.Mascota.Color);
                cmd.Parameters.AddWithValue("@MasEspecie", objFichaClinica.Mascota.Especie);
                cmd.Parameters.AddWithValue("@MasSexo", objFichaClinica.Mascota.Sexo);
                cmd.Parameters.AddWithValue("@MasIntac", objFichaClinica.Mascota.Intac);
                cmd.Parameters.AddWithValue("@MasCast", objFichaClinica.Mascota.Cast);
                cmd.Parameters.AddWithValue("@MasPeso", objFichaClinica.Mascota.Peso);
                cmd.Parameters.AddWithValue("@MasMarcaDistintiva", objFichaClinica.Mascota.MarcaDistintiva);
                cmd.Parameters.AddWithValue("@MasEstado", objFichaClinica.Mascota.Estado);
                
                cmd.ExecuteReader();
                objFichaClinica.NumeroFicha = Convert.ToInt32(cmd.Parameters["@NuevoId"].Value);
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

        public Boolean Actualizar (ref clsBaseEntidad baseEntidad, clsFichaClinica objFichaClinica)
        {
            Boolean Resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("FichaClinica_Actualizar", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (objFichaClinica.ListaVacunas.Count > 0)
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@TYPE_VACUNAS", Value = objFichaClinica.ListaVacunas, SqlDbType = SqlDbType.Structured, TypeName = "dbo.TY_VACUNAS" });
                if (objFichaClinica.ListaDesparasitaciones.Count > 0)
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@TYPE_DESPARASITACIONES", Value = objFichaClinica.ListaDesparasitaciones, SqlDbType = SqlDbType.Structured, TypeName = "dbo.TY_DESPARASITACIONES" });
                //Datos Ficha Clínica
                cmd.Parameters.AddWithValue("@ID", objFichaClinica.Id);

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

    }
}
