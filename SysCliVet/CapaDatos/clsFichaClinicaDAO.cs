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
                //Datos Ficha Clínica
                cmd.Parameters.AddWithValue("@ID", objFichaClinica.Id);
                cmd.Parameters.AddWithValue("@InformacionMedica", objFichaClinica.InformacionMedica);
                cmd.Parameters.AddWithValue("@MedioAmbiente", objFichaClinica.MedioAmbiente);
                cmd.Parameters.AddWithValue("@TipoDieta", objFichaClinica.TipoDieta);
                cmd.Parameters.AddWithValue("@Motivo", objFichaClinica.Motivo);
                cmd.Parameters.AddWithValue("@Observaciones", objFichaClinica.Observaciones);
                cmd.Parameters.AddWithValue("@Estado", objFichaClinica.Estado);
                //Datos Propietario
                cmd.Parameters.AddWithValue("@ProiId", objFichaClinica.Propietario.Id);
                cmd.Parameters.AddWithValue("@ProiDni", objFichaClinica.Propietario.Dni);
                cmd.Parameters.AddWithValue("@ProNombre", objFichaClinica.Propietario.Nombre);
                cmd.Parameters.AddWithValue("@ProApellidos", objFichaClinica.Propietario.Apellidos);
                cmd.Parameters.AddWithValue("@ProFechaNacimiento", objFichaClinica.Propietario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@ProDireccion", objFichaClinica.Propietario.Direccion);
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
