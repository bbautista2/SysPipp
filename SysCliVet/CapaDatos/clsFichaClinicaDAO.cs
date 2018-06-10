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
                //cmd.Parameters.AddWithValue("@ID", objPropietario.Id);
                //cmd.Parameters.AddWithValue("@Nombre", objPropietario.Nombre);
                //cmd.Parameters.AddWithValue("@Apellidos", objPropietario.Apellidos);
                //cmd.Parameters.AddWithValue("@FechaNacimiento", objPropietario.FechaNacimiento);
                //cmd.Parameters.AddWithValue("@Direccion", objPropietario.Direccion);
                //cmd.Parameters.AddWithValue("@Telefono", objPropietario.Telefono);
                //cmd.Parameters.AddWithValue("@Email", objPropietario.Email);
                //cmd.Parameters.AddWithValue("@Estado", objPropietario.Estado);
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
