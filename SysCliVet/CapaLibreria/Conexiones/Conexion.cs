using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CapaLibreria.Conexiones
{
    public class Conexion
    {
        public static void DisposeCommand(SqlCommand cmd)
        {
            try
            {
                if (cmd != null)
                {
                    if (cmd.Connection != null)
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                    }
                    cmd.Dispose();
                }
            }
            catch { }
        }
        public static void DisposeCommand(SqlConnection conect)
        {
            try
            {

                if (conect != null)
                {
                    conect.Close();
                    conect.Dispose();
                }

            }
            catch { } //don't blow up
        }


        #region Conexion
        /// <summary>
        /// MODE 
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConexion()
        {
            String connString = "";

            if (ConfigurationManager.ConnectionStrings["sisclivet_db"] != null)
            {
                connString = ConfigurationManager.ConnectionStrings["sisclivet_db"].ConnectionString;
            }

            SqlConnection objConexion = new SqlConnection(connString);

            objConexion.Open();
            return objConexion;
        }
        #endregion
    }
}
