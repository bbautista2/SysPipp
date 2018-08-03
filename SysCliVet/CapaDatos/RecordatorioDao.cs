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
    public class RecordatorioDao
    {
        #region Singleton
        private static RecordatorioDao instance = null;
        public static RecordatorioDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new RecordatorioDao();
                return instance;
            }
        }
        #endregion

        #region Llenar Entidades
        public Recordatorio SetEntidad(SqlDataReader dr)
        {
            Recordatorio recordatorio = new Recordatorio();
            recordatorio.Descripcion = dr.ObtenerValorColumna<String>("Descripcion");
            recordatorio.Fecha = dr.ObtenerValorColumna<DateTime>("Fecha");
            recordatorio.Mascota.Nombre = dr.ObtenerValorColumna<String>("Nombre_Mascota");
            return recordatorio;
        }
        #endregion

        public List<Recordatorio> ObtenerTodo(ref BaseEntidad baseEntidad)
        {
            List<Recordatorio> lstRecordatorios = new List<Recordatorio>();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("Recordatorio_Listar", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Recordatorio objRecordatorio = new Recordatorio();
                        objRecordatorio = SetEntidad(dr);
                        lstRecordatorios.Add(objRecordatorio);
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
            return lstRecordatorios;
        }

    }
}
